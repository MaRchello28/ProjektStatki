using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektStatki.Views
{
    public partial class ChooseGameModeView : Form
    {
        public ChooseGameModeView()
        {
            InitializeComponent();
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
        }

        private void ChooseGameModeView_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                TreeNode parentNode = selectedNode.Parent;
                if (parentNode != null)
                {
                    if (parentNode.Name == "normal" || parentNode.Name == "specjalne")
                    {
                        panel1.Visible = true;
                        panel2.Visible = false;
                        label1.Text = selectedNode.Text;
                    }
                    else
                    {
                        panel1.Visible = false;
                        panel2.Visible = true;
                        panel2.Location = panel1.Location;
                        label4.Text = selectedNode.Text;
                    }
                }
            }
        }
    }
}
