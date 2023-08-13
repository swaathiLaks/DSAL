namespace treeViewAssignment2
{
    public partial class Form1 : Form
    {
        public static BuildTree btree = new BuildTree();
        public Form1()
        {
            InitializeComponent();
            if (btree.root_node == null)
            {
                btree.root_node = new Node();
                btree.root_node = btree.fakeTree();
                btree.e_root_node = new Node();
                btree.e_root_node = btree.fakeEmployeeTree();
            }
            read_only_box.Enabled = false;
            btree.role_createTree(treeView1, btree.root_node);
            treeView1.ExpandAll();
            btree.for_tree_view(treeView1, this);

            btree.updateTree += Btree_updateTree;
        }

        private void Btree_updateTree(object? sender, EventArgs e)
        {
            btree.role_createTree(treeView1, btree.root_node);
            treeView1.ExpandAll();
        }

        private void expand_all_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void collapse_all_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
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