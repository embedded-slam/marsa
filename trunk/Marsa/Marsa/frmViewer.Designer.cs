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
namespace Marsa
{
    partial class frmViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIP_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPeriodSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPeriod = new System.Windows.Forms.ToolStripTextBox();
            this.mnuGroupSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGraphSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuActions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnectDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterGroupsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterGroupsNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterSubGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterSubGroupsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterSubGroupsNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterCounters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterCountersAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilterCountersNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrCollectStatistics = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageStatisticsCountersGrid = new System.Windows.Forms.TabPage();
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageStatisticsCountersGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuActions,
            this.mnuFilter,
            this.mnuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1175, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIP_Settings,
            this.mnuPeriodSettings,
            this.mnuGroupSettings,
            this.mnuGraphSettings});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(58, 20);
            this.mnuSettings.Text = "Settings";
            // 
            // mnuIP_Settings
            // 
            this.mnuIP_Settings.Name = "mnuIP_Settings";
            this.mnuIP_Settings.Size = new System.Drawing.Size(171, 22);
            this.mnuIP_Settings.Text = "IP...";
            this.mnuIP_Settings.Click += new System.EventHandler(this.iPSettingsToolStripMenuItem_Click);
            // 
            // mnuPeriodSettings
            // 
            this.mnuPeriodSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPeriod});
            this.mnuPeriodSettings.Name = "mnuPeriodSettings";
            this.mnuPeriodSettings.Size = new System.Drawing.Size(171, 22);
            this.mnuPeriodSettings.Text = "Period (milliSeconds)";
            // 
            // mnuPeriod
            // 
            this.mnuPeriod.Name = "mnuPeriod";
            this.mnuPeriod.Size = new System.Drawing.Size(100, 21);
            this.mnuPeriod.Text = "1";
            this.mnuPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mnuPeriod_KeyDown);
            // 
            // mnuGroupSettings
            // 
            this.mnuGroupSettings.Name = "mnuGroupSettings";
            this.mnuGroupSettings.Size = new System.Drawing.Size(171, 22);
            this.mnuGroupSettings.Text = "Groups...";
            this.mnuGroupSettings.Visible = false;
            this.mnuGroupSettings.Click += new System.EventHandler(this.mnuGroupSettings_Click);
            // 
            // mnuGraphSettings
            // 
            this.mnuGraphSettings.Name = "mnuGraphSettings";
            this.mnuGraphSettings.Size = new System.Drawing.Size(171, 22);
            this.mnuGraphSettings.Text = "Graphs...";
            this.mnuGraphSettings.Visible = false;
            this.mnuGraphSettings.Click += new System.EventHandler(this.mnuGraphSettings_Click);
            // 
            // mnuActions
            // 
            this.mnuActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnectDisconnect,
            this.mnuStartStop});
            this.mnuActions.Name = "mnuActions";
            this.mnuActions.Size = new System.Drawing.Size(54, 20);
            this.mnuActions.Text = "Actions";
            // 
            // mnuConnectDisconnect
            // 
            this.mnuConnectDisconnect.Name = "mnuConnectDisconnect";
            this.mnuConnectDisconnect.Size = new System.Drawing.Size(152, 22);
            this.mnuConnectDisconnect.Text = "Connect";
            this.mnuConnectDisconnect.Click += new System.EventHandler(this.mnuConnectDisconnect_Click);
            // 
            // mnuStartStop
            // 
            this.mnuStartStop.Enabled = false;
            this.mnuStartStop.Name = "mnuStartStop";
            this.mnuStartStop.Size = new System.Drawing.Size(152, 22);
            this.mnuStartStop.Text = "Start";
            this.mnuStartStop.Click += new System.EventHandler(this.mnuStartStop_Click);
            // 
            // mnuFilter
            // 
            this.mnuFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilterAll,
            this.mnuFilterNone,
            this.mnuFilterGroups,
            this.mnuFilterSubGroups,
            this.mnuFilterCounters});
            this.mnuFilter.Name = "mnuFilter";
            this.mnuFilter.Size = new System.Drawing.Size(43, 20);
            this.mnuFilter.Text = "Filter";
            this.mnuFilter.Visible = false;
            // 
            // mnuFilterAll
            // 
            this.mnuFilterAll.Name = "mnuFilterAll";
            this.mnuFilterAll.Size = new System.Drawing.Size(152, 22);
            this.mnuFilterAll.Text = "All";
            this.mnuFilterAll.Click += new System.EventHandler(this.mnuFilterAll_Click);
            // 
            // mnuFilterNone
            // 
            this.mnuFilterNone.Name = "mnuFilterNone";
            this.mnuFilterNone.Size = new System.Drawing.Size(152, 22);
            this.mnuFilterNone.Text = "None";
            this.mnuFilterNone.Click += new System.EventHandler(this.mnuFilterNone_Click);
            // 
            // mnuFilterGroups
            // 
            this.mnuFilterGroups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilterGroupsAll,
            this.mnuFilterGroupsNone});
            this.mnuFilterGroups.Name = "mnuFilterGroups";
            this.mnuFilterGroups.Size = new System.Drawing.Size(152, 22);
            this.mnuFilterGroups.Text = "Groups";
            // 
            // mnuFilterGroupsAll
            // 
            this.mnuFilterGroupsAll.Name = "mnuFilterGroupsAll";
            this.mnuFilterGroupsAll.Size = new System.Drawing.Size(99, 22);
            this.mnuFilterGroupsAll.Text = "All";
            this.mnuFilterGroupsAll.Click += new System.EventHandler(this.mnuFilterEnableAll_Click);
            // 
            // mnuFilterGroupsNone
            // 
            this.mnuFilterGroupsNone.Name = "mnuFilterGroupsNone";
            this.mnuFilterGroupsNone.Size = new System.Drawing.Size(99, 22);
            this.mnuFilterGroupsNone.Text = "None";
            this.mnuFilterGroupsNone.Click += new System.EventHandler(this.mnuFilterDisableAll_Click);
            // 
            // mnuFilterSubGroups
            // 
            this.mnuFilterSubGroups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilterSubGroupsAll,
            this.mnuFilterSubGroupsNone});
            this.mnuFilterSubGroups.Name = "mnuFilterSubGroups";
            this.mnuFilterSubGroups.Size = new System.Drawing.Size(152, 22);
            this.mnuFilterSubGroups.Text = "Subgroups";
            // 
            // mnuFilterSubGroupsAll
            // 
            this.mnuFilterSubGroupsAll.Name = "mnuFilterSubGroupsAll";
            this.mnuFilterSubGroupsAll.Size = new System.Drawing.Size(99, 22);
            this.mnuFilterSubGroupsAll.Text = "All";
            this.mnuFilterSubGroupsAll.Click += new System.EventHandler(this.mnuFilterEnableAll_Click);
            // 
            // mnuFilterSubGroupsNone
            // 
            this.mnuFilterSubGroupsNone.Name = "mnuFilterSubGroupsNone";
            this.mnuFilterSubGroupsNone.Size = new System.Drawing.Size(99, 22);
            this.mnuFilterSubGroupsNone.Text = "None";
            this.mnuFilterSubGroupsNone.Click += new System.EventHandler(this.mnuFilterDisableAll_Click);
            // 
            // mnuFilterCounters
            // 
            this.mnuFilterCounters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilterCountersAll,
            this.mnuFilterCountersNone});
            this.mnuFilterCounters.Name = "mnuFilterCounters";
            this.mnuFilterCounters.Size = new System.Drawing.Size(152, 22);
            this.mnuFilterCounters.Text = "Counters";
            this.mnuFilterCounters.Click += new System.EventHandler(this.mnuFilterEnableAll_Click);
            // 
            // mnuFilterCountersAll
            // 
            this.mnuFilterCountersAll.Name = "mnuFilterCountersAll";
            this.mnuFilterCountersAll.Size = new System.Drawing.Size(99, 22);
            this.mnuFilterCountersAll.Text = "All";
            this.mnuFilterCountersAll.Click += new System.EventHandler(this.mnuFilterAll_Click);
            // 
            // mnuFilterCountersNone
            // 
            this.mnuFilterCountersNone.Name = "mnuFilterCountersNone";
            this.mnuFilterCountersNone.Size = new System.Drawing.Size(99, 22);
            this.mnuFilterCountersNone.Text = "None";
            this.mnuFilterCountersNone.Click += new System.EventHandler(this.mnuFilterNone_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(135, 22);
            this.mnuAbout.Text = "About Marsa";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // tmrCollectStatistics
            // 
            this.tmrCollectStatistics.Interval = 1000;
            this.tmrCollectStatistics.Tick += new System.EventHandler(this.tmrCollectStatistics_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageStatisticsCountersGrid);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1175, 552);
            this.tabControl.TabIndex = 3;
            // 
            // tabPageStatisticsCountersGrid
            // 
            this.tabPageStatisticsCountersGrid.Controls.Add(this.dgvStatistics);
            this.tabPageStatisticsCountersGrid.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatisticsCountersGrid.Name = "tabPageStatisticsCountersGrid";
            this.tabPageStatisticsCountersGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatisticsCountersGrid.Size = new System.Drawing.Size(1167, 526);
            this.tabPageStatisticsCountersGrid.TabIndex = 0;
            this.tabPageStatisticsCountersGrid.Text = "Statistics Counters";
            this.tabPageStatisticsCountersGrid.UseVisualStyleBackColor = true;
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.AllowUserToAddRows = false;
            this.dgvStatistics.AllowUserToDeleteRows = false;
            this.dgvStatistics.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvStatistics.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Counter,
            this.Value,
            this.Unit,
            this.Delta,
            this.Description});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatistics.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatistics.Location = new System.Drawing.Point(3, 3);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.ReadOnly = true;
            this.dgvStatistics.Size = new System.Drawing.Size(1161, 520);
            this.dgvStatistics.TabIndex = 2;
            this.dgvStatistics.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStatistics_CellValueChanged);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // Counter
            // 
            this.Counter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Counter.HeaderText = "Counter";
            this.Counter.Name = "Counter";
            this.Counter.ReadOnly = true;
            this.Counter.Width = 69;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 59;
            // 
            // Unit
            // 
            this.Unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 51;
            // 
            // Delta
            // 
            this.Delta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delta.HeaderText = "Delta";
            this.Delta.Name = "Delta";
            this.Delta.ReadOnly = true;
            this.Delta.Width = 57;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 576);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marsa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewer_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageStatisticsCountersGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuIP_Settings;
        private System.Windows.Forms.ToolStripMenuItem mnuPeriodSettings;
        private System.Windows.Forms.ToolStripTextBox mnuPeriod;
        private System.Windows.Forms.ToolStripMenuItem mnuActions;
        private System.Windows.Forms.ToolStripMenuItem mnuConnectDisconnect;
        private System.Windows.Forms.ToolStripMenuItem mnuStartStop;
        private System.Windows.Forms.Timer tmrCollectStatistics;
        private System.Windows.Forms.ToolStripMenuItem mnuFilter;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterGroups;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterSubGroups;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterCounters;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterGroupsAll;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterGroupsNone;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterSubGroupsAll;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterSubGroupsNone;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterCountersAll;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterCountersNone;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterAll;
        private System.Windows.Forms.ToolStripMenuItem mnuFilterNone;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageStatisticsCountersGrid;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.ToolStripMenuItem mnuGraphSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuGroupSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Counter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;

    }
}

