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
using System.Diagnostics;

namespace Marsa
{
    class StatisticsCounter : StatisticsEntity
    {
        #region Private Members Variables
        private int     value;
        private int     subGroupID;
        private string  unit;
        private int     delta;
        private int     minimumDelta;
        private int     maximumDelta;
        private int     averageDelta;
        private int     sampleCount;
        private int     []valueList;
        private int     valueListIndex;
        private const int valueListSize = 16;
        #endregion /*Private Members Variables*/

        #region Properties
        public int Value
        {
            get { return this.value; }
            set
            {
                int delta;
                delta               = value - this.value;
                this.sampleCount++;
                this.value          = value;
                this.delta          = delta;
                this.minimumDelta   = (delta < minimumDelta) ? (delta) : (minimumDelta);
                this.maximumDelta   = (delta > maximumDelta) ? (delta) : (maximumDelta);
                this.averageDelta   = ((delta / sampleCount)) + (((sampleCount - 1)* averageDelta / sampleCount) );
                this.valueList[valueListIndex++] = value;
                valueListIndex      &= (valueListSize - 1);

            }
        }
        public int SubGroupID
        {
            get { return this.subGroupID; }
            set { this.subGroupID = value; }
        }      
        public string Unit
        {
            get { return this.unit; }
            set { this.unit = value; }
        }
        public int Delta      
        {
            get { return this.delta; }
        }
        public int MinimumDelta
        {
            get { return this.minimumDelta; }
        }
        public int MaximumDelta
        {
            get { return this.maximumDelta; }
        }
        public int AverageDelta
        {
            get { return this.averageDelta; }
        }
        public int SampleCount
        {
            get { return this.sampleCount; }
        }
        public int[] Values
        {
            get { return this.valueList; }
        }
        public int ValuesIndex
        {
            get { return this.valueListIndex; }
        }
        #endregion /*Properties*/

        #region Member Functions
        public StatisticsCounter(int     id,
                                 string  unit,
                                 string  name,
                                 string  description)
        {
            this.ID             = id;
            this.Name           = name;
            this.Description    = description;
            this.unit           = unit;
            this.value          = 0;
            this.delta          = 0;
            this.minimumDelta   = 0;
            this.maximumDelta   = 0;
            this.sampleCount    = 0;
            this.valueList      = new int[valueListSize];
            this.valueListIndex = 0;
            Debug.Assert(0 == (valueListSize & (valueListSize - 1)),
                         "The valueListSize constant shall be a power of two");
        }
        #endregion /*Member Functions*/
    }
}
