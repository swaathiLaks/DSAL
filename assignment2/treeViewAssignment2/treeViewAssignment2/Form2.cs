using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace treeViewAssignment2
{
    public partial class Form2 : Form
    {
        BuildTree btree = Form1.btree;
        public Form2()
        {
            InitializeComponent();
            if (btree.root_node == null)
            {
                btree.root_node = btree.fakeTree();
                MessageBox.Show("As Role Form is not open, the default tree structure will be used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btree.start_employee_form(treeView2);
            }
            else if (btree.e_root_node == null)
            {
                Node newnode = new Node();
                newnode.create_employee("Root", null, 0, "Root", null, false, true, btree.root_node);
                btree.e_root_node = newnode;
                Btree_updateTree(this, new EventArgs());
            }
            else
            {
                Btree_updateTree(this, new EventArgs());
            }
            btree.for_employee_tree_view(treeView2, this);
            btree.updateTree += Btree_updateTree;
        }

        private void Btree_updateTree(object? sender, EventArgs e)
        {
            btree.role_createTree(treeView2, btree.e_root_node);
            treeView2.ExpandAll();
        }

        private void expand_all_Click(object sender, EventArgs e)
        {
            treeView2.ExpandAll();
        }

        private void collapse_all_Click(object sender, EventArgs e)
        {
            treeView2.CollapseAll();
        }

        public bool is_form_open(Type formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == formType)
                {
                    return true;
                }
            }
            return false;
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
    }
}
