/***************************************************************************************************
 *
 * Marsa is a C# GUI viewer program for the eStatiC library.
 *
 * Copyright © 2009  Mohamed Galal El-Din, Karim Emad Morsy.
 *
 ***************************************************************************************************
 *
 * This file is part of Marsa program.
 *
 * Marsa is free software: you can redistribute it and/or modify it under the terms of the GNU
 * General Public License as published by the Free Software Foundation, either version 3 of the
 * License, or any later version.
 *
 * Marsa is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
 * even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with Marsa. If not, see
 * <http://www.gnu.org/licenses/>.
 *
 ***************************************************************************************************
 *
 * For more information, questions, or inquiries please contact:
 *
 * Mohamed Galal El-Din:    mohamed.g.ebrahim@gmail.com
 * Karim Emad Morsy:        karim.e.morsy@gmail.com
 *
 **************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Net.Sockets;
using Marsa.Properties;
using ConnectionTypes;

namespace Marsa
{
    class StatisticsManager
    {
        enum ConnectionStatus { CONNECTED, DISCONNECTED };
        private tcpClient                   client;
        private ConnectionStatus            connectionStatus;
        public List <StatisticsCounter>     countersList;
        public List <StatisticsSubGroup>    subgroupsList;
        public List <StatisticsGroup>       groupsList;
        private int                         countersCount;


        public StatisticsManager()
        {
            this.client                     = new tcpClient();

            this.countersList               = new List <StatisticsCounter> ();
            this.subgroupsList              = new List <StatisticsSubGroup> ();
            this.groupsList                 = new List <StatisticsGroup> ();
            this.connectionStatus           = ConnectionStatus.DISCONNECTED;

        }

        public int Connect()
        {
            int i;
            int rxDataLength;
            int rxDataOffset = 0;
            byte[] request = new byte[1];
            byte[] response = new byte[4]; 
            
            /**************************************************************************************
             * 
             * Request/populate groups, sub groups, and counters information 
             * 
             *************************************************************************************/
            try
            {
                /* Connect to the embedded part */
                client.connect(System.Net.IPAddress.Parse(Settings.Default.ServerIP), int.Parse(Settings.Default.ServerPort));

                /*Now set the connection status to connected*/
                connectionStatus = ConnectionStatus.CONNECTED;

                /* Send a request to get the total length of the information (execluding the 4-bytes long header). */
                request[0] = 1;
                client.send(ref request, request.Length);

                /* Receive the header (currently it contains the length only)*/
                client.receive(ref response, response.Length);

                rxDataLength = byteToInt32(response, ref rxDataOffset);

                /* Allocate enough space to hold the information */
                response = new byte[rxDataLength];

                /* Receive the informations about the groups, subgroups, and counters */
                client.receive(ref response, response.Length);

                /* Reset the offset to prepare for parsing the received information */
                rxDataOffset = 0;

                /* Read the counters count*/
                countersCount = byteToInt32(response, ref rxDataOffset);

                /* Start reading each counter information */
                for (i = 0; i < countersCount; i++)
                {
                    DecodeCounterInformation(response, ref rxDataOffset, countersList, i);
                }

                /*Success*/
                return 0;
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message, "Connection failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }

        public void Disconnect()
        {
            byte[] request = new byte[1];

            if (ConnectionStatus.CONNECTED == connectionStatus)
            {
                /* Send a request to terminate the server. */
                request[0] = 0;
                client.send(ref request, request.Length);
                client.disconnect();
                connectionStatus = ConnectionStatus.DISCONNECTED;
            }
        }

        public void CollectStatistics()
        {
            int rxDataOffset = 0;
            byte[] request = new byte[1];
            byte[] response = new byte[4]; 

            /* Reallocate the response array to fit the counter list */
            response = new byte[4 * countersCount];

            /**********************************************************************************
             * 
             * Collect statistics
             * 
             *********************************************************************************/
            /* 
             * Load the current period from the settings to be used as the delay between each 
             * two successive statistics request.
             * 
             * It is done inside the loope to allow the user to change the period during runtime.                 
             */
            

            /* Reset the offset */
            rxDataOffset = 0;

            /* Send a request to get the total length of the information (execluding the 4-bytes long header) */
            request[0] = 2;
            client.send(ref request, request.Length);

            /* Receive the counters values. */
            client.receive(ref response, 4 * countersCount);

            /* Populate the counter list with the received values */
            foreach (StatisticsCounter counter in countersList)
            {
                /* Extract the counter value from the received array */
                counter.Value = byteToInt32(response, ref rxDataOffset);
            }

        }



        private void DecodeGroupInformation(byte[] response, ref int rxDataOffset, List <StatisticsGroup> groupsList, int i)
        {
            StatisticsGroup           group;
            int             groupID;
            string          groupName;
            string          groupDescription;
            /*
             * typedef struct StatisticsGroupInfo
             * {
             *      uint32_t                    groupID;
             *      const char*                 groupName_Ptr;
             *      const char*                 groupDescription_Ptr;
             * #ifdef DEBUG
             *      bool_t                      isAssigned;
             * #endif 
             * } StatisticsGroupInfo_s;
             */

            /* Read the group ID*/
            groupID = byteToInt32(response, ref rxDataOffset);

            /* Read the group name */
            groupName = ExtractString(response, ref rxDataOffset);


            /* Read the group description */
            groupDescription = ExtractString(response, ref rxDataOffset);

            /* Create new group object and insert it in the array list, in the correct location*/
            group = new StatisticsGroup(groupID, groupName, groupDescription);
            groupsList.Add(group);

        }

        private void DecodeSubGroupInformation(byte[] response, ref int rxDataOffset, List <StatisticsSubGroup> subgroupsList, int i)
        {
            StatisticsSubGroup subgroup;
            int subgroupID;
            int groupID;
            string subgroupName;
            string subgroupDescription;

            /*
             * typedef struct StatisticsSubGroupInfo
             * {
             *      uint32_t                    subgroupID;
             *      uint32_t                    groupID;
             *      const char*                 subgroupName_Ptr;
             *      const char*                 subgroupDescription_Ptr;
             * #ifdef DEBUG
             *      bool_t                      isAssigned;
             * #endif 
             * } StatisticsSubGroupInfo_s;
             */

            /* Read the subgroup ID*/
            subgroupID = byteToInt32(response, ref rxDataOffset);

            /* Read the parent group ID*/
            groupID = byteToInt32(response, ref rxDataOffset);

            /* Read the subgroup name */
            subgroupName = ExtractString(response, ref rxDataOffset);

            /* Read the subgroup description */
            subgroupDescription = ExtractString(response, ref rxDataOffset);

            /* Create new subgroup object and insert it in the array list, in the correct location*/
            subgroup = new StatisticsSubGroup(subgroupID, groupID, subgroupName, subgroupDescription);
            subgroupsList.Add(subgroup);
        } 

        private void DecodeCounterInformation(byte[] response, ref int rxDataOffset, List <StatisticsCounter> countersList, int i)
        {
            StatisticsCounter counter;
            int     counterID;
            string  counterUnit;
            string  counterName;
            string  counterDescription;

            /*
             * typedef struct StatisticsCounterInfo
             * {
             *      uint32_t                    counterID;
             *      const char*                 unit_Ptr;
             *      const char*                 counterName_Ptr;
             *      const char*                 counterDescription_Ptr;
             * #ifdef DEBUG
             *      bool_t                      isAssigned;
             * #endif 
             * } StatisticsCounterInfo_s;
             */

            /* Read the counter ID*/
            counterID = byteToInt32(response, ref rxDataOffset);

            /* Read the counter counterUnit */
            counterUnit = ExtractString(response, ref rxDataOffset);
            
            /* Read the counter name */
            counterName = ExtractString(response, ref rxDataOffset);

            /* Read the counter description */
            counterDescription = ExtractString(response, ref rxDataOffset);

            /* Create new counter object and insert it in the array list, in the correct location*/
            counter = new StatisticsCounter(counterID, counterUnit, counterName, counterDescription);
            countersList.Add(counter);
        }

        private string ExtractString(byte[] response, ref int rxDataOffset)
        {
            int i;
            int stringLength    = 0;
            Encoding ascii      = Encoding.ASCII;

            string retString = new string("".ToCharArray());

            /* Copy all the bytes into the new string */
            for (i = rxDataOffset; response[i] != '\0'; i++)
            {
                stringLength++;
            }

            retString = ascii.GetString(response, rxDataOffset, stringLength);

            /* Advance the offset by the amount of character read, and increment by additional byte for null terminator */
            rxDataOffset += stringLength + 1;

            /* Return the extracted string */
            return retString;
        }        
        
        int byteToInt32(byte[] rawInt, ref int offset)
        {
            int result;
            result = (int)(rawInt[offset]);
            result |= (int)(rawInt[offset + 1] << 8);
            result |= (int)(rawInt[offset + 2] << 16);
            result |= (int)(rawInt[offset + 3] << 24);

            offset += 4;

            return result;
        }
    }
}
