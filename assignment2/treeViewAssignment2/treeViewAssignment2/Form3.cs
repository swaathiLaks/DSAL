using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace treeViewAssignment2
{
    public partial class Form3 : Form
    {
        BuildTree btree = Form1.btree;
        public Form3()
        {
            InitializeComponent();
            treeView1.Enabled = false;
            if (btree.root_node == null)
            {
                btree.root_node = btree.fakeTree();
                MessageBox.Show("As Role Form is not open, the default tree structure will be used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (btree.e_root_node == null)
            {
                Node newnode = new Node();
                newnode.create_employee("Root", null, 0, "Root", null, false, true, btree.root_node);
                btree.e_root_node = newnode;
            }
            if(btree.projects != null) 
            {
                btree.update_listview(listView1);
            }
            btree.for_projects(this);
            btree.updateTree += Btree_updateTree;
        }

        private void Btree_updateTree(object? sender, EventArgs e)
        {
            btree.role_createTree(treeView1, btree.e_root_node);
            btree.update_listview(listView1);
            treeView1.ExpandAll();
        }

        private void save_Click(object sender, EventArgs e)
        {
            btree.savefileio();
        }

        private void load_Click(object sender, EventArgs e)
        {
            btree.loadfileio();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            btree.reset_pressed();
        }

        private void expand_all_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void collapse_all_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
    }
}
