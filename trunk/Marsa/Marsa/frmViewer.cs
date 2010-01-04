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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Marsa.Properties;
using ZedGraph;

namespace Marsa
{
    public partial class frmViewer : Form
    {
        private frmConnectionSettings   connectionSettingsForm;
        private StatisticsManager       statisticsManager;

        public frmViewer()
        {
            InitializeComponent();
            statisticsManager = new StatisticsManager();

        }

        private void iPSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            connectionSettingsForm = new frmConnectionSettings();
            result = connectionSettingsForm.ShowDialog();
            if (DialogResult.OK == result)
            {
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.Reload();
            }
        }

        private void mnuConnectDisconnect_Click(object sender, EventArgs e)
        {
            int i;
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            /* The user intend to connect to the embedded part */
            if(menuItem.Text.Equals("Connect"))
            {
                i = statisticsManager.Connect();

                /*If connection succeeded*/
                if (0 == i)
                {
                    PopulateStatisticsGrid(this.dgvStatistics,
                                           statisticsManager.groupsList,
                                           statisticsManager.subgroupsList,
                                           statisticsManager.countersList);

                    menuItem.Text = "Disconnect";
                    /* Populate the filter menus (groups and subgroups) */

                    foreach (StatisticsEntity entity in statisticsManager.groupsList)
                    {
                        PopulateFilterMenus(mnuFilterGroups, entity);
                    }
                    foreach (StatisticsEntity entity in statisticsManager.subgroupsList)
                    {
                        PopulateFilterMenus(mnuFilterSubGroups, entity);
                    }
                    foreach (StatisticsEntity entity in statisticsManager.countersList)
                    {
                        PopulateFilterMenus(mnuFilterCounters, entity);
                    }
                }
            }
            else /* The user intend to disconnect to the embedded part */
            {
                /* Stop collecting statistics*/
                tmrCollectStatistics.Enabled = false;
                /* Disconnect from the embedded part */
                statisticsManager.Disconnect();

                /*Clear the data grid*/
                ClearStatisticsGrid(dgvStatistics);

                /*Set the menu option to start */
                mnuStartStop.Text = "Start";
                menuItem.Text = "Connect";

                /* Remove all the groups/subgroups filters menu items */


                /* Skip the first two menu items (select all, select none) */
                for (i = 2; i < mnuFilterGroups.DropDownItems.Count; )
                {
                    /* Note that we skipped the increment in the for loop, as each iteration
                     * will result in removing the current item, and then the 
                     * next item will have the same index as the current item.
                     * 
                     * So, we'll keep iterating untill the item count = 2.
                     */
                    mnuFilterGroups.DropDownItems.RemoveAt(i);
                }
                for (i = 2; i < mnuFilterSubGroups.DropDownItems.Count; )
                {
                    /* Note that we skipped the increment in the for loop, as each iteration
                     * will result in removing the current item, and then the 
                     * next item will have the same index as the current item.
                     * 
                     * So, we'll keep iterating untill the item count = 2.
                     */
                    mnuFilterSubGroups.DropDownItems.RemoveAt(i);
                }
            }

            /*Enable the start menu only if the system is connected (i.e. caption is "Disconnect")*/
            mnuStartStop.Enabled = menuItem.Text.Equals("Disconnect");
        }

        private void ClearStatisticsGrid(DataGridView dgvStatistics)
        {
            dgvStatistics.Rows.Clear();
        }

        private void PopulateFilterMenus(ToolStripMenuItem parentMenu, StatisticsEntity entity)
        {
            ToolStripMenuItem newMenuItem;
            newMenuItem = new ToolStripMenuItem(entity.Name);
            newMenuItem.CheckOnClick = true;
            newMenuItem.CheckState = CheckState.Checked;
            newMenuItem.Click += new EventHandler(newMenuItem_Click);
            parentMenu.DropDownItems.Add(newMenuItem);
        }

        void newMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFiltering();
        }

        private void ApplyFiltering()
        {
            bool    isGroupEnabled;
            bool    isSubGroupEnabled;
            bool    isCounterEnabled;
            int     groupIndex;
            int     subgroupIndex;
            int     counterIndex;

            foreach (DataGridViewRow row in dgvStatistics.Rows)
            {
                counterIndex  = row.Index;
                subgroupIndex = statisticsManager.countersList[counterIndex].SubGroupID;
                groupIndex    = statisticsManager.subgroupsList[subgroupIndex].GroupID;


                isGroupEnabled      = ((ToolStripMenuItem)mnuFilterGroups.DropDownItems[groupIndex + 2]).Checked;
                isSubGroupEnabled   = ((ToolStripMenuItem)mnuFilterSubGroups.DropDownItems[subgroupIndex + 2]).Checked;
                isCounterEnabled    = ((ToolStripMenuItem)mnuFilterCounters.DropDownItems[counterIndex + 2]).Checked;
                row.Visible         = (isGroupEnabled) && (isSubGroupEnabled) && (isCounterEnabled);
            }
        }

        private void mnuStartStop_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            if (menuItem.Text.Equals("Start"))
            {
                tmrCollectStatistics.Interval = int.Parse(Settings.Default.Period) * 1000;
                tmrCollectStatistics.Enabled = true;
                menuItem.Text = "Stop";
            }
            else
            {
                tmrCollectStatistics.Enabled = false;
                menuItem.Text = "Start";
            }
        }

        private void mnuPeriod_TextChanged(object sender, EventArgs e)
        {

        }

        private void mnuFilterEnableAll_Click(object sender, EventArgs e)
        {
            SetFilterStatus((ToolStripMenuItem)sender, true);

            /* Reapply filtering to reflect the current status */
            ApplyFiltering();
        }

        private void mnuFilterDisableAll_Click(object sender, EventArgs e)
        {

            SetFilterStatus((ToolStripMenuItem)sender, false);

            /* Reapply filtering to reflect the current status */
            ApplyFiltering();
        }

        private void SetFilterStatus(ToolStripMenuItem toolStripMenuItem, bool isEnabled)
        {
            int i;
            ToolStripMenuItem parent = (ToolStripMenuItem)toolStripMenuItem.OwnerItem;
            ToolStripMenuItem child;
            /* Skip the first two menu items (select all, select none) */
            for (i = 2; i < parent.DropDownItems.Count; i++)
            {
                child = (ToolStripMenuItem)parent.DropDownItems[i];
                child.Checked = isEnabled;
            }
        }

        private void PopulateStatisticsGrid(DataGridView statisticsDataGridView, List<StatisticsGroup> groupsList, List<StatisticsSubGroup> subgroupsList, List<StatisticsCounter> countersList)
        {


            foreach (StatisticsCounter counter in countersList)
            {
                statisticsDataGridView.Rows.Add(counter.ID,
                                                counter.Name,
                                                subgroupsList[counter.SubGroupID].Name,
                                                groupsList[subgroupsList[counter.SubGroupID].GroupID].Name,
                                                counter.Value,
                                                counter.Unit,
                                                counter.Delta,
                                                counter.Description);

            }
        }



        private void tmrCollectStatistics_Tick(object sender, EventArgs e)
        {
            statisticsManager.CollectStatistics();

            UpdateStatisticsGrid(dgvStatistics, 
                                 statisticsManager.countersList);

            CreateGraph(zedGraphControl);

        }

        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane

            zgc.MasterPane = new MasterPane();
            zgc.GraphPane = new GraphPane();
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles

            //myPane.Title.Text = "My Test Graph\n(For CodeProject Sample)";
            //myPane.XAxis.Title.Text = "My X Axis";
            //myPane.YAxis.Title.Text = "My Y Axis";

            // Make up some data arrays based on the Sine function

            double x, y;
            PointPairList list1 = new PointPairList();
            StatisticsCounter counter = statisticsManager.countersList[0];


            for (int i = 0, j = counter.ValuesIndex; i < 16; i++, j = (++j) & 0xF)
            {

                x = (double)i + counter.SampleCount;
                y = counter.Values[j];
                
                list1.Add(x, y);
                
            }

            LineItem myCurve = myPane.AddCurve("Porsche",
                  list1, Color.Red, SymbolType.Diamond);


            // Tell ZedGraph to refigure the

            // axes since the data have changed
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.White;
            myPane.YAxis.MajorGrid.Color = Color.White;

            myPane.XAxis.IsVisible = false;
            myPane.YAxis.IsVisible = false;
            myPane.Chart.Fill = new Fill(Color.Black);

            zgc.AxisChange();
            zgc.Refresh();
            zgc.MasterPane.ReSize(zgc.CreateGraphics());
            
        }

        private void UpdateStatisticsGrid(DataGridView dgvStatistics, List<StatisticsCounter> countersList)
        {
            int counterID;
            foreach (DataGridViewRow row in dgvStatistics.Rows)
            {
                if (true == row.Visible)
                {
                    counterID = int.Parse(row.Cells["ID"].Value.ToString());
                    row.Cells["Value"].Value = countersList[counterID].Value;
                    row.Cells["Delta"].Value = countersList[counterID].Delta;
                }

            }
        }

        private void mnuPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                Settings.Default.Save();
                tmrCollectStatistics.Interval = int.Parse(((ToolStripTextBox)sender).Text) * 1000;
            }
        }

        private void mnuFilterAll_Click(object sender, EventArgs e)
        {
            SetFilterStatus(mnuFilterGroupsAll, true);
            SetFilterStatus(mnuFilterSubGroupsAll, true);
            SetFilterStatus(mnuFilterCountersAll, true);

            ApplyFiltering();
        }

        private void mnuFilterNone_Click(object sender, EventArgs e)
        {
            SetFilterStatus(mnuFilterGroupsNone, false);
            SetFilterStatus(mnuFilterSubGroupsNone, false);
            SetFilterStatus(mnuFilterCountersNone, false);

            ApplyFiltering();
        }

        private void frmViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrCollectStatistics.Enabled = false;

            statisticsManager.Disconnect();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout aboutForm;
            aboutForm = new frmAbout();
            aboutForm.ShowDialog();
        }

        private void mnuGraphSettings_Click(object sender, EventArgs e)
        {
            frmGraphSettings graphSettingsForm;
            graphSettingsForm = new frmGraphSettings();
            graphSettingsForm.ShowDialog();
        }
    }
}