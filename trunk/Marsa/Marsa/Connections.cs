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
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;


namespace ConnectionTypes
{
    interface Connections
    {
        void createConnection();
        void connect(System.Net.IPAddress hostAddress, int port);
        void send(ref byte[] buffer, int length);
        void receive(ref byte[] buffer, int length);
    }



    class tcpServer : Connections
    {
        int tcpPort;
        Socket connection;
        TcpListener serverListener;

        public tcpServer(int Port)
        {
            tcpPort = Port;
            serverListener = new TcpListener(System.Net.IPAddress.Parse("172.25.25.193"), tcpPort);
        }

        public void createConnection()
        {

            serverListener.Start();
            connection = serverListener.AcceptSocket();
            MessageBox.Show("Client connected el 7amd l Allah :)");
        }

        public void connect(System.Net.IPAddress hostAddress, int port)
        {

        }

        public void send(ref byte[] buffer, int length)
        {
            connection.Send(buffer, length, SocketFlags.None);
        }

        public void receive(ref byte[] buffer, int length)
        {
            connection.Receive(buffer, length, SocketFlags.None);
        }
    }

    class tcpClient : Connections
    {

        TcpClient client;

        public tcpClient()
        {
            client = new TcpClient();
        }

        public void createConnection()
        {

        }

        public void connect(System.Net.IPAddress hostAddress, int port)
        {
                client.Connect(hostAddress, port);
        }

        public void disconnect()
        {
            client.Close();
        }

        public void send(ref byte[] buffer, int length)
        {
            client.Client.Send(buffer, length, SocketFlags.None);
        }

        public void receive(ref byte[] buffer, int length)
        {
            client.Client.Receive(buffer, length, SocketFlags.None);
        }
    }
}


