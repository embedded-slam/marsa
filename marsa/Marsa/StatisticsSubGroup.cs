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

namespace Marsa
{
    class StatisticsSubGroup : StatisticsEntity
    {
        #region Private Members Variables
        private int groupID;
        #endregion /*Private Members Variables*/

        #region Properties
        public int GroupID
        {
            get { return this.groupID; }
            set { this.groupID = value; }
        }
        #endregion /*Properties*/

        #region Member Functions
        public StatisticsSubGroup(int id,
                        int groupID,
                        string name,
                        string description)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;

            this.groupID = groupID;
        }
        #endregion /*Member Functions*/
    }
}
