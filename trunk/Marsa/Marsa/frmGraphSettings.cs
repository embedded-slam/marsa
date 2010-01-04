using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Marsa
{
    public partial class frmGraphSettings : Form
    {
        private enum NodeLevel  
        { 
            NODE_LEVEL_GRAPH_VIEW_PARENT    = 0,
            NODE_LEVEL_GRAPH_VIEW           = 1,
            NODE_LEVEL_GRAPH                = 2,
            NODE_LEVEL_SERIES               = 3
        };

        public frmGraphSettings()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*
             * Depending on the currently selected level, the code decide what kind of node to add
             */
            TreeNode    currentNode     = tvGraph.SelectedNode;
            string      newNodeCaption  = "";

            switch ((NodeLevel)tvGraph.SelectedNode.Level)
            {
                case NodeLevel.NODE_LEVEL_GRAPH_VIEW_PARENT:
                    newNodeCaption = "New Graph View";
                    break;
                case NodeLevel.NODE_LEVEL_GRAPH_VIEW:
                    newNodeCaption = "New Graph";
                    break;
                case NodeLevel.NODE_LEVEL_GRAPH:
                    newNodeCaption = "New Series";
                    break;
                case NodeLevel.NODE_LEVEL_SERIES:
                    return;
                default:
                    Debug.Assert(false);
                    return;
            }
            currentNode.Nodes.Add(newNodeCaption);
            currentNode.Expand();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = tvGraph.SelectedNode;
            // Remove the currently selected node, except if it is the top level node.
            if (currentNode.Level > 0)
            {
                currentNode.Remove();
            }
        }

        private void tvGraph_AfterSelect(object sender, TreeViewEventArgs e)
        {

            btnRemove.Enabled   = (NodeLevel.NODE_LEVEL_GRAPH_VIEW_PARENT != (NodeLevel)tvGraph.SelectedNode.Level);
            btnAdd.Enabled      = (NodeLevel.NODE_LEVEL_SERIES != (NodeLevel)tvGraph.SelectedNode.Level);
        }
    }
}