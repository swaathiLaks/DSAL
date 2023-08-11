using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace treeViewAssignment2
{
    public class BuildTree
    {
        public RoleForm roleForm;
        public event EventHandler updateTree;
        public Node e_root_node = null;
        public Node root_node = null;
        public List<Node> projects = new List<Node>();
        public Tree BTree { get; set; }
        public Node fakeTree()
        {
            Node root_node = new Node();
            root_node.create_role("Root", false);
            Tree BTtree = new Tree(root_node);

            Node manager_node = new Node();
            manager_node.create_role("Manager", false);
            BTtree.addNode(root_node, manager_node);

            Node projmanager_node = new Node();
            projmanager_node.create_role("Project Manager", false);
            BTtree.addNode(manager_node, projmanager_node);

            Node projleader_node = new Node();
            projleader_node.create_role("Project Leader", true);
            BTtree.addNode(projmanager_node, projleader_node);

            Node BED_node = new Node();
            BED_node.create_role("Backend Developer", false);
            BTtree.addNode(projleader_node, BED_node);

            Node FED_node = new Node();
            FED_node.create_role("Frontend Developer", false) ;
            BTtree.addNode(projleader_node, FED_node);

            Node DB_node = new Node();
            DB_node.create_role("Database Engineer", false);
            BTtree.addNode(projleader_node, DB_node);

            Node sysanalyst_node = new Node();
            sysanalyst_node.create_role("System Analyst", false);
            BTtree.addNode(projleader_node, sysanalyst_node);

            return root_node;
            
        }

        public void role_createTree(TreeView treeview1, Node root_node1)
        {
            treeview1.Nodes.Clear();
            TreeNode root_treeView = new TreeNode(root_node1.display_name);
            treeview1.Nodes.Add(root_treeView);
            root_treeView.Tag = root_node1;
            role_addRemainingTree(treeview1, root_node1, root_treeView);
        }

        public void role_addRemainingTree(TreeView treeview1, Node parent_node, TreeNode form_node)
        {
            Tree ETree = new Tree(e_root_node);
            for (int i = 0; i < parent_node.childnodes.Count; i++)
            {
                TreeNode node_treeView = new TreeNode(parent_node.childnodes[i].display_name);
                if (parent_node.is_role) { parent_node.childnodes[i].reporting_officer = parent_node.role; }
                form_node.Nodes.Add(node_treeView);
                node_treeView.Tag = parent_node.childnodes[i];
                role_addRemainingTree(treeview1, parent_node.childnodes[i], node_treeView);

                if (!parent_node.childnodes[i].is_role && !parent_node.childnodes[i].proj_lead && !parent_node.childnodes[i].last_leaf) 
                {
                    List<string> cur_node_proj = ETree.get_all_projects(parent_node.childnodes[i]);
                    parent_node.childnodes[i].projects = string.Join(", ", cur_node_proj);
                }
                if (parent_node.childnodes[i].last_leaf)
                {
                    parent_node.childnodes[i].projects = parent_node.projects;
                    parent_node.childnodes[i].proj_revenue = parent_node.proj_revenue;
                }
            }
        }

        public void for_tree_view(TreeView treeview1, Form1 form1)
        {
            TreeNode current_node = null;
            Node cur_node = null;
            ContextMenuStrip cm = new ContextMenuStrip();
            ToolStripMenuItem addItem = new ToolStripMenuItem("Add Role");
            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Role");
            ToolStripMenuItem removeItem = new ToolStripMenuItem("Remove Role");
            cm.Items.Add(addItem);
            cm.Items.Add(editItem);
            cm.Items.Add(removeItem);

            addItem.Click += AddItem_Click;
            editItem.Click += EditItem_Click;
            removeItem.Click += RemoveItem_Click;

            treeview1.NodeMouseClick += for_each_node_clicked;
            void for_each_node_clicked(object sender, TreeNodeMouseClickEventArgs e)
            {
                if (e.Node.Tag is Node node1)
                {
                    form1.uuid_form1.Text = node1.display_id;
                    form1.name_form1.Text = node1.display_name;
                    form1.proj_leader_form1.Checked = node1.proj_lead;
                }
                
                if (e.Button == MouseButtons.Right)
                {
                    addItem.Enabled = true;
                    editItem.Enabled = true;
                    removeItem.Enabled = true;
                    current_node = e.Node;
                    cm.Show(treeview1, e.Location);
                    if (current_node.Tag is Node node)
                    {
                        cur_node = node;
                    }
                    if (cur_node.last_leaf)
                    {
                        addItem.Enabled = false;
                    }
                    if (cur_node.role == "Root")
                    {
                        editItem.Enabled = false;
                        removeItem.Enabled = false;
                    }
                }
            }

            void RemoveItem_Click(object? sender, EventArgs e)
            {
                Tree BTree = new Tree(root_node);
                if (cur_node.employee_nodes.Count() != 0)
                {
                    List<string> myList = new List<string> { };
                    foreach (Node i in cur_node.employee_nodes)
                    {
                        myList.Add(i.name);
                    }
                    MessageBox.Show($"You cannot remove this node because there are employees associated with this role.\nAssociate employees: {string.Join(", ", myList)}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    BTree.deleteNode(cur_node);
                    updateTree.Invoke(this, new EventArgs()); 
                }
            }

            void EditItem_Click(object? sender, EventArgs e)
            {
                Tree BTree = new Tree(root_node);
                roleForm = new RoleForm();
                roleForm.Show();
                roleForm.label1.Text = "Edit Role";
                roleForm.roleform_uuid.Text = cur_node.display_id;
                roleForm.roleform_uuid.Enabled = false;
                roleForm.roleform_parent.Enabled = false;
                roleForm.roleform_parent.Text = cur_node.reporting_officer;
                roleForm.roleform_name.Text = cur_node.role;
                roleForm.roleform_confirm.Click += roleform_click;
                if (cur_node.childnodes.Count > 0)
                {
                    roleForm.roleform_proj_lead.Enabled = false;
                }
                void roleform_click(object? sender, EventArgs e)
                {
                    try
                    {
                        if (roleForm.roleform_name.Text == "") { throw new Exception(); }
                        BTree.editNode(cur_node, new List<Object> { roleForm.roleform_name.Text, roleForm.roleform_proj_lead.Checked });
                        updateTree.Invoke(this, new EventArgs());
                        roleForm.Close();
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Please fill all text boxes.");
                    }
                    
                }

            }

            void AddItem_Click(object? sender, EventArgs e)
            {
                Tree BTree = new Tree(root_node);
                roleForm = new RoleForm();
                roleForm.Show();
                roleForm.label1.Text = "Add Role";
                roleForm.roleform_uuid.Text = "Not generated yet";
                roleForm.roleform_uuid.Enabled = false;
                roleForm.roleform_confirm.Click += roleform_click;
                roleForm.roleform_parent.Enabled = false;
                roleForm.roleform_parent.Text = cur_node.role;
                if (cur_node.proj_lead) { roleForm.roleform_proj_lead.Enabled = false; }
                void roleform_click(object? sender, EventArgs e)
                {
                    try
                    {
                        if (roleForm.roleform_name.Text == "") { throw new Exception(); }
                        Node newNode = new Node();
                        newNode.create_role(roleForm.roleform_name.Text, roleForm.roleform_proj_lead.Checked);
                        BTree.addNode(cur_node, newNode);
                        updateTree.Invoke(this, new EventArgs());
                        roleForm.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please fill all text boxes.");
                    }
                    
                }
                
            }

        }

        public void start_employee_form(TreeView treeView2)
        {
            Tree BTree = new Tree(root_node);
            BTree.delete_all_employees();
            e_root_node = new Node();
            e_root_node.create_employee("Root", null, 0, "Root", null, false, true, root_node);
            role_createTree(treeView2, e_root_node);
        }

        public void for_employee_tree_view(TreeView treeView2, Form2 form2)
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            ToolStripMenuItem adde = new ToolStripMenuItem("Add Employee");
            ToolStripMenuItem edite = new ToolStripMenuItem("Edit Employee");
            ToolStripMenuItem removee = new ToolStripMenuItem("Remove Employee");
            ToolStripMenuItem swape = new ToolStripMenuItem("Swap Employee");
            ToolStripMenuItem editdete = new ToolStripMenuItem("Edit Employee Details");
            ToolStripMenuItem chrole = new ToolStripMenuItem("Change Employee Role/ Reporting Officer");
            Node cur_node=null;
            TreeNode current_node = null;
            cm.Items.Add(adde);
            cm.Items.Add(edite);
            cm.Items.Add(removee);
            cm.Items.Add(swape);
            edite.DropDownItems.Add(editdete);
            edite.DropDownItems.Add(chrole);
            treeView2.NodeMouseClick += for_each_node_clicked;
            adde.Click += Adde_Click;
            removee.Click += Removee_Click;
            swape.Click += Swape_Click;
            editdete.Click += Editdete_Click;
            chrole.Click += Chrole_Click;
            form2.read_only_form2.Enabled = false;
            
            void for_each_node_clicked(object sender, TreeNodeMouseClickEventArgs e)
            {
                Tree ETree = new Tree(e_root_node);
                current_node = (TreeNode)e.Node;
                if (current_node.Tag is Node node)
                {
                    cur_node = node;
                    form2.uuid_form2.Text = cur_node.uuid;
                    form2.dummy_data_form2.Checked = cur_node.dummy_data;
                    form2.salary_acc_form2.Checked = cur_node.salary_accountable;
                    form2.salary_form2.Text = cur_node.salary.ToString();
                    form2.role_form2.Text = cur_node.role;
                    form2.name_form2.Text = cur_node.name;
                    form2.rofficer_form2.Text = cur_node.reporting_officer;
                    form2.projects_form2.Text = cur_node.projects;
                }
                if (e.Button == MouseButtons.Right)
                {
                    edite.Enabled = true;
                    editdete.Enabled = true;
                    adde.Enabled = true;
                    swape.Enabled = true;
                    removee.Enabled = true;

                    cm.Show(treeView2, e.Location);
                    
                    if (cur_node.name == "Root")
                    {
                        edite.Enabled = false;
                        removee.Enabled = false;
                    }
                    if (cur_node.last_leaf)
                    {
                        adde.Enabled = false;
                    }
                    if (cur_node.projects!= null)
                    {
                        adde.Enabled = false;
                    }
                }
            }

            void Chrole_Click(object? sender, EventArgs e)
            {
                if(!(cur_node.got_all_roles))
                {
                    Tree BTree = new Tree(root_node);
                    Tree ETree = new Tree(e_root_node);
                    EmployeeForm eform = new EmployeeForm();
                    eform.Show();
                    eform.eform_label1.Text = "Change Role and (/or) Reporting Officer";
                    eform.eform_salary.Enabled = false;
                    eform.eform_dummy_data.Enabled = false;
                    eform.eform_dummy_data.Checked = cur_node.dummy_data;
                    eform.eform_salary_acc.Enabled = false;
                    eform.eform_salary_acc.Checked = cur_node.salary_accountable;
                    eform.eform_name.Enabled = false;
                    eform.eform_name.Text = cur_node.name;
                    eform.eform_uuid.Enabled = false;
                    eform.eform_uuid.Text = cur_node.display_id;

                    eform.eform_salary.Text = cur_node.salary.ToString();
                    eform.eform_rofficer.Enabled = false;

                    getNode rolegetnode = new getNode();
                    getNode offgetnode = new getNode();
                    offgetnode.text = cur_node.reporting_officer;
                    offgetnode.node = cur_node.role_node;
                    eform.eform_rofficer.Items.Add(offgetnode);
                    eform.eform_role.SelectedItem = rolegetnode;
                    eform.eform_rofficer.SelectedItem = offgetnode;
                    bool isituser = false;
                    eform.eform_role.SelectedIndexChanged += Eform_role_SelectedIndexChanged;

                    List<getNode> all_roles = role_loop(root_node);
                    
                    foreach (getNode newgetnode in all_roles)
                    {
                        eform.eform_role.Items.Add(newgetnode);
                        if (newgetnode.text == cur_node.role_node.role)
                        {
                            eform.eform_role.SelectedIndex = eform.eform_role.Items.Count - 1;
                        }
                    }
                    isituser = true;
                    void Eform_role_SelectedIndexChanged(object? sender, EventArgs e)
                    {
                        eform.eform_rofficer.Text = null;
                        eform.eform_rofficer.Items.Clear();
                        eform.eform_rofficer.Enabled = true;
                        Node parent_node = BTree.recursive((eform.eform_role.SelectedItem as getNode).node);
                        List<getNode> rofficer_li = role_loop(e_root_node, parent_node.role);

                        foreach (getNode newgetnode in rofficer_li)
                        {
                            eform.eform_rofficer.Items.Add(newgetnode);
                            if (!isituser && cur_node.reporting_officer==newgetnode.text)
                            {
                               eform.eform_rofficer.SelectedIndex = eform.eform_rofficer.Items.Count - 1;
                            }
                        }

                    }

                    eform.eform_confirm.Click += Eform_confirm_Click;

                    void Eform_confirm_Click(object? sender, EventArgs e)
                    {
                        try
                        {
                            if (eform.eform_role.Text == "" || eform.eform_rofficer.Text == "") { throw new Exception(); }
                            Node employee = new Node();
                            employee.create_employee(cur_node.name, eform.eform_rofficer.Text, cur_node.salary, eform.eform_role.Text, null, cur_node.dummy_data, cur_node.salary_accountable, (eform.eform_role.SelectedItem as getNode).node);
                            ETree.addNode((eform.eform_rofficer.SelectedItem as getNode).node, employee, true);
                            eform.Close();
                            updateTree.Invoke(this, new EventArgs());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please fill all textboxes with appropriate values.");
                        }

                    }

                }
                else
                {
                    MessageBox.Show("This Employee node already has two roles. Please delete one to add another role.");
                }

            }

            List<getNode> role_loop(Node start_node, string role = null)
            {
                List<getNode> all_roles = new List<getNode>();
                if (start_node == e_root_node&& role== "Root")
                {
                    getNode newgetnode = new getNode();
                    newgetnode.text = e_root_node.name;
                    newgetnode.node = e_root_node;
                    all_roles.Add(newgetnode);
                }
                continue_role_loop(start_node, all_roles, start_node, role);
                return all_roles;
            }

            void continue_role_loop(Node x, List<getNode> all_roles, Node startnode, string role)
            {
                foreach (var childNode in x.childnodes)
                {
                    if (startnode == root_node)
                    {
                        if (x.employee_nodes.Count != 0)
                        {
                            getNode newgetnode = new getNode();
                            newgetnode.text = childNode.role;
                            newgetnode.node = childNode;
                            all_roles.Add(newgetnode);
                        } 
                    }
                    else
                    {
                        if (childNode.role == role)
                        {
                            getNode newgetnode = new getNode();
                            newgetnode.text = childNode.name;
                            newgetnode.node = childNode;
                            if (!all_roles.Contains(newgetnode))
                            {
                                all_roles.Add(newgetnode);
                            }
                        }
                    }
                    
                    continue_role_loop(childNode, all_roles, startnode, role);
                }
            }

            void Editdete_Click(object? sender, EventArgs e)
            {
                Tree BTree = new Tree(root_node);
                Tree ETree = new Tree(e_root_node);
                EmployeeForm eform = new EmployeeForm();
                eform.Show();
                eform.eform_label1.Text = "Edit Employee";
                eform.eform_rofficer.Text = cur_node.reporting_officer;
                eform.eform_rofficer.Enabled = false;
                eform.eform_salary_acc.Checked = true;
                eform.eform_salary_acc.Enabled = false;
                eform.eform_name.Text = cur_node.name;
                eform.eform_salary.Text = cur_node.salary.ToString();
                eform.eform_uuid.Text = cur_node.display_id;
                eform.eform_uuid.Enabled = false;
                eform.eform_role.Enabled = false;
                eform.eform_role.Text = cur_node.role;

                if (form2.projects_form2.Text!=null) { eform.eform_salary.Enabled = false; }

                eform.eform_confirm.Click += eform_click;

                void eform_click(object? sender, EventArgs e)
                {
                    try
                    {
                        Node Parent = ETree.recursive(cur_node);
                        if (eform.eform_name.Text == ""|| int.Parse(eform.eform_salary.Text)<1|| (Parent!= e_root_node && int.Parse(eform.eform_salary.Text)>Parent.salary)) { throw new Exception(); }
                        if (cur_node.projects != null&& cur_node.proj_lead)
                        {
                            string[] substrings = cur_node.projects.Split(new string[] { ", " }, StringSplitOptions.None);
                            foreach (string substring in substrings)
                            {
                                bool check_rev = calc_new_proj_rev(int.Parse(eform.eform_salary.Text), substring, cur_node.salary);
                                if (!check_rev) { throw new Exception(); }
                            }
                            
                        }
                        ETree.editNode(cur_node, new List<Object> { eform.eform_name.Text, eform.eform_salary.Text, eform.eform_dummy_data.Checked });
                        updateTree.Invoke(this, new EventArgs());
                        eform.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please fill all textboxes with appropriate values.");
                    }
                    
                }
            }

            void Swape_Click(object? sender, EventArgs e)
            {
                Tree BTree = new Tree(root_node);
                Tree ETree = new Tree(e_root_node);
                Node sform_node = null;
                SwapForm sform = new SwapForm();
                sform.Show();
                sform.swapform_name.Enabled = false;
                sform.swapform_salary.Enabled = false;
                sform.swapform_replacing.Enabled = false;
                sform.swapform_rofficer.Enabled = false;
                sform.swapform_role.Enabled = false;
                sform.swapform_uuid.Enabled = false;
                role_createTree(sform.swapform_tree, e_root_node);
                sform.swapform_tree.ExpandAll();
                sform.swapform_replacing.Text = cur_node.name;
                sform.swapform_tree.NodeMouseClick += Swapform_tree_NodeMouseClick;
                sform.swapform_confirm.Click += Swapform_confirm_Click;
                void Swapform_tree_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
                {
                    if (e.Node.Tag is Node node)
                    {
                        sform_node = node;
                        sform.swapform_name.Text = sform_node.name;
                        sform.swapform_rofficer.Text = sform_node.reporting_officer;
                        sform.swapform_salary.Text = sform_node.salary.ToString();
                        sform.swapform_uuid.Text = sform_node.uuid;
                        sform.swapform_role.Text = sform_node.role;
                    }
                }

                void Swapform_confirm_Click(object? sender, EventArgs e)
                {
                    if (cur_node!=sform_node&&cur_node.salary == sform_node.salary && cur_node.role==sform_node.role) 
                    {
                        Tree BTree = new Tree(root_node);
                        Tree ETree = new Tree(e_root_node);
                        List<Object> list = new List<Object> { cur_node.name, cur_node.salary, cur_node.dummy_data };
                        ETree.editNode(cur_node, new List<Object> { sform_node.name, sform_node.salary, sform_node.dummy_data });
                        ETree.editNode(sform_node, list);
                        string tempstr = cur_node.display_id;
                        cur_node.display_id = sform_node.display_id;
                        sform_node.display_id = tempstr;
                        foreach (Node childNode in cur_node.childnodes)
                        {
                            childNode.reporting_officer = cur_node.name;
                        }
                        foreach (Node childNode in sform_node.childnodes)
                        {
                            childNode.reporting_officer = sform_node.name;
                        }
                        updateTree.Invoke(this, new EventArgs());
                        sform.Close();
                    }
                    else
                    {
                        MessageBox.Show("Employee you are swapping with must have the same role and the same pay.", "Warning", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                    }
                    
                }


            }

            void Removee_Click(object? sender, EventArgs e)
            {
                Tree BTree = new Tree(root_node);
                Tree ETree = new Tree(e_root_node);
                if (!(cur_node.childnodes.Count==0 && cur_node.projects == null)) 
                {
                    DialogResult result = MessageBox.Show("The employee can only be removed if there are no subordinates or no assigned projects. Would you like to swap the employee with another first?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Swape_Click(sender, e);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you would like to remove this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ETree.deleteNode(cur_node);
                        Node another_node = ETree.namerecursive(cur_node);
                        if (another_node != null)
                        { 
                            another_node.display_name = another_node.name + " - " + another_node.role + " (S$" + another_node.salary.ToString() + ")";
                            another_node.got_all_roles = false;
                        }
                    }
                }

                updateTree.Invoke(this, new EventArgs());
            }

            bool calc_new_proj_rev(int new_s, string proj_name, int past_s = 0)
            {
                int rev = 0;
                int total = 0;
                void find_total(Node x)
                {
                    if (x.projects.Contains(proj_name))
                    {
                        total += x.salary;
                        if (x.proj_revenue != 0) { rev  = x.proj_revenue; }
                    }

                    foreach (Node childnode in x.childnodes)
                    {
                        find_total(childnode);
                    }
                }

                find_total(e_root_node);
                total -= past_s;
                total += new_s;
                if(rev<total)
                {
                    return false;
                }
                else { return true; }
            }

            void Adde_Click(object? sender, EventArgs e)
            {
                Tree BTree = new Tree(root_node);
                Tree ETree = new Tree(e_root_node);
                EmployeeForm eform = new EmployeeForm();
                eform.Show();
                eform.eform_label1.Text = "Add Employee";
                eform.eform_rofficer.Text = cur_node.name;
                eform.eform_rofficer.Enabled = false;
                eform.eform_salary_acc.Checked = true;
                eform.eform_salary_acc.Enabled = false;
                eform.eform_uuid.Text = "Not generated yet.";
                eform.eform_uuid.Enabled = false;

                foreach (Node child_node in cur_node.role_node.childnodes)
                {
                    getNode newnode = new getNode();
                    newnode.text = child_node.role;
                    newnode.node = child_node;
                    
                    
                    eform.eform_role.Items.Add(newnode);
                }

                eform.eform_confirm.Click += eform_click;
                void eform_click(object? sender, EventArgs e)
                {
                    try
                    {
                        bool more_than_sub(Node x)
                        {
                           foreach(Node childnode in x.childnodes)
                            {
                                if (childnode.salary < int.Parse(eform.eform_salary.Text))
                                {
                                    more_than_sub(childnode);
                                }
                                else { return false; }
                            }

                           return true;
                        }
                        int rev = 0;
                        foreach (Node childNode2 in cur_node.childnodes)
                        {
                            rev += childNode2.salary;
                        }

                        void calc_parent_sal(Node x)
                        {
                            Node parent = ETree.recursive(x);
                            if (parent != e_root_node)
                            {
                                rev += parent.salary;
                                calc_parent_sal(parent);
                            }
                        }
                        calc_parent_sal(cur_node);

                        bool sub_check = more_than_sub(cur_node);
                        if (eform.eform_name.Text == "" || int.Parse(eform.eform_salary.Text)<1 || eform.eform_role.Text=="" || int.Parse(eform.eform_salary.Text)>cur_node.salary || !sub_check) { throw new Exception(); }
                        if (cur_node.projects != null) 
                        {
                            bool check_rev = calc_new_proj_rev(int.Parse(eform.eform_salary.Text), cur_node.projects);
                            if (!check_rev) { throw new Exception(); }
                        }
                        Node employee = new Node();
                        employee.create_employee(eform.eform_name.Text, cur_node.name, int.Parse(eform.eform_salary.Text), eform.eform_role.Text, null, eform.eform_dummy_data.Checked, eform.eform_salary_acc.Checked, (eform.eform_role.SelectedItem as getNode).node);
                        ETree.addNode(cur_node, employee);
                        updateTree.Invoke(this, new EventArgs());
                        eform.Close();
                    }catch (Exception ex)
                    {
                        MessageBox.Show("Please fill all textboxes with appropriate values.");
                    }
                    
                }
            }

        }
        
        public void loadfileio()
        {
            FileIO fileIO = new FileIO();
            List<Object> list = fileIO.deserialize(fileIO.for_user);

            root_node = (Node)list[0];
            e_root_node = (Node)list[1];
            projects = (List<Node>)list[2];
            BTree = new Tree(root_node);

            if (e_root_node == null)
            {
                Node newnode = new Node();
                newnode.create_employee("Root", null, 0, "Root", null, false, true, root_node);
                e_root_node = newnode;
            }
            updateTree.Invoke(this, new EventArgs());
        }

        public void savefileio()
        {
            List<Object> list = new List<Object> { root_node, e_root_node, projects};

            FileIO fileIO = new FileIO();
            fileIO.serialize(fileIO.for_user, list);

        }

        public void for_projects(Form3 form3)
        {
            Node current_node = null;
            int err_rev = 0;
            int rev_val = 0;
            Node err_node = null;
            string err_projname = null;
            void make_view()
            {
                form3.mode_form3.Text = "View";
                form3.add_box.Enabled = false;
                form3.edit_box.Enabled = false;
                form3.tlead_add.Enabled = false;
                form3.tlead_add.Text = "";
                form3.tlead_add.Items.Clear();
                form3.uuid_edit.Enabled = false;
                form3.tlead_edit.Text = "";
                form3.tlead_edit.Items.Clear();
                form3.revenue_edit.Clear();
                form3.pname_edit.Clear();
                form3.uuid_edit.Clear();
            }

            role_createTree(form3.treeView1, e_root_node);
            make_view();
            form3.listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
            form3.sfe_add.Click += (sender, e) => search_button_clicked(sender, e,form3.tlead_add, form3.revenue_add, false);
            form3.sfe_edit.Click += (sender, e) => search_button_clicked(sender, e, form3.tlead_edit, form3.revenue_edit, true);
            form3.confirm_add.Click += (sender, e) => confirm_clicked(sender, e, form3.pname_add, form3.revenue_add, form3.tlead_add);
            form3.mode_form3.SelectedIndexChanged += Mode_form3_SelectedIndexChanged;
            form3.delete_edit.Click += Delete_edit_Click;
            form3.confirm_edit.Click += Confirm_edit_Click;
            void Mode_form3_SelectedIndexChanged(object? sender, EventArgs e)
            {
                if (form3.mode_form3.Text == "Add")
                {
                    make_view();
                    form3.add_box.Enabled = true;
                }
                else if(form3.mode_form3.Text == "Edit")
                {
                    make_view();
                    form3.edit_box.Enabled = true;
                }
                else
                {
                    make_view();
                }
                
            }

            void confirm_clicked(object? sender, EventArgs e, TextBox projname, TextBox revenue, ComboBox tlead, bool isedit=false)
            {
                try
                {
                    Node tlead_node = null;
                    if (tlead.Text ==""|| int.Parse(revenue.Text)<1||projname.Text=="") { throw new Exception(); }
                    if (tlead.SelectedItem is getNode){tlead_node = (tlead.SelectedItem as getNode).node;}else{ throw new Exception(); }
                    if (int.Parse(revenue.Text) < rev_val || tlead_node == null) { throw new Exception(); }
                    foreach (Node node in projects)
                    {
                        if (projname.Text == node.projects && tlead_node != node) { throw new Exception(); }
                    }
                    tlead_node.projects = projname.Text;
                    tlead_node.proj_revenue = rev_val;
                    projects.Add(tlead_node);
                    updateTree.Invoke(this, new EventArgs());
                    make_view();
                }
                catch (Exception ex)
                {
                    if (isedit) { projects.Add(err_node); err_node.projects = err_projname; err_node.proj_revenue = err_rev; }
                    MessageBox.Show("Please fill all textboxes with appropriate values. Your edit was not successful.");
                }
            }

            void search_button_clicked(object? sender, EventArgs e, ComboBox comboBox, TextBox textbox, bool isedit)
            {
                void ResetNodeBackColor(TreeNodeCollection nodes, Color color)
                {
                    foreach (TreeNode node in nodes)
                    {
                        node.BackColor = color;
                        ResetNodeBackColor(node.Nodes, color);
                    }
                }

                ResetNodeBackColor(form3.treeView1.Nodes, Color.White);

                try
                {
                    if (int.Parse(textbox.Text) < 1) { throw new Exception(); }
                    Node changenode = null;
                    String temp_str = null;
                    if (comboBox.SelectedItem != null && isedit)
                    {
                        changenode = (comboBox.SelectedItem as getNode).node;
                        temp_str = changenode.projects;
                        changenode.projects = null;
                        comboBox.SelectedIndex = -1;
                    }
                    comboBox.Items.Clear();
                    comboBox.SelectedItem = null;
                    int max = int.Parse(textbox.Text);
                    rev_val = max;
                    List<getNode> proj_leads = search_proj_lead(max);
                    foreach (getNode newgetnode in proj_leads)
                    {
                        comboBox.Items.Add(newgetnode);
                        searchtreeview(form3.treeView1.Nodes, newgetnode.node.display_name);
                    }
                    comboBox.Enabled = true;

                    if (changenode != null)
                    {
                        changenode.projects = temp_str;
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Please fill all textboxes with appropriate values.");
                }
                
            }

            void searchtreeview(TreeNodeCollection nodes, string str)
            {
                foreach (TreeNode treeNode in nodes)
                {
                    if (treeNode.Text == str)
                    {
                        treeNode.BackColor = Color.MediumSpringGreen;
                    }
                    searchtreeview(treeNode.Nodes, str);
                }
            }

            List<getNode> search_proj_lead(int max)
            {
                List<getNode> proj_leads = new List<getNode>();
                search_for_other_proj_leads(proj_leads, e_root_node, max);
                return proj_leads;
            }

            void search_for_other_proj_leads(List<getNode> proj_leads, Node x, int max)
            {
                Tree ETree = new Tree(e_root_node);
                foreach (Node childNode in x.childnodes)
                {
                    if (childNode.proj_lead && childNode.projects == null)
                    {
                        bool full_team= ETree.check_for_full_team(childNode);
                        if (!full_team) { break; }
                        int total = 0;
                        foreach (Node childNode2 in childNode.childnodes)
                        {
                            total += childNode2.salary;
                        }

                        void calc_parent_sal(Node x)
                        {
                            Node parent = ETree.recursive(x);
                            if (parent != e_root_node)
                            {
                                total += parent.salary;
                                calc_parent_sal(parent);
                            }
                        }
                        calc_parent_sal(childNode);

                        if (total <= max)
                        {
                            getNode newgetnode = new getNode();
                            newgetnode.text = childNode.name;
                            newgetnode.node = childNode;
                            proj_leads.Add(newgetnode);
                        }
                    }
                    else
                    {
                        search_for_other_proj_leads(proj_leads, childNode, max);
                    }
                }
            }


            void ListView1_ItemSelectionChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
            {
                Node cur_node;
                if (e.IsSelected) 
                {
                    cur_node= e.Item.Tag as Node;
                    current_node = cur_node;
                    form3.uuid_edit.Text = cur_node.uuid;
                    form3.pname_edit.Text = cur_node.projects;
                    form3.revenue_edit.Text = cur_node.proj_revenue.ToString();
                    getNode newgetnode = new getNode();
                    newgetnode.text = cur_node.name;
                    newgetnode.node = cur_node;
                    form3.tlead_edit.Items.Add(newgetnode);
                    form3.tlead_edit.SelectedItem = newgetnode;
                }
            }
            bool DeleteEdit()
            {
                if (current_node != null)
                {
                    err_projname = current_node.projects;
                    err_rev = current_node.proj_revenue;
                    err_node = current_node;
                    current_node.projects = null;
                    current_node.proj_revenue = 0;
                    foreach (Node childnode in current_node.childnodes)
                    {
                        current_node.projects = null;
                        current_node.proj_revenue = 0;
                    }
                    projects.Remove(current_node);
                    updateTree.Invoke(this, new EventArgs());
                    return true;
                }
                else
                {
                    MessageBox.Show("Please enter valid values.");
                    return false;
                }
                    
            }
            void Delete_edit_Click(object? sender, EventArgs e)
            {
                DeleteEdit();
                make_view();
            }

            void Confirm_edit_Click(object? sender, EventArgs e)
            {
                bool newbool = DeleteEdit();
                if(newbool)
                {
                    confirm_clicked(sender, e, form3.pname_edit, form3.revenue_edit, form3.tlead_edit, true);
                    updateTree.Invoke(this, new EventArgs());
                    make_view();
                }
               
            }
        }

        public void update_listview(ListView listview)
        {
            listview.Items.Clear();
            foreach (Node node in projects)
            {
                ListViewItem newitem = new ListViewItem(node.display_id);
                newitem.SubItems.Add(node.projects);
                newitem.SubItems.Add(node.proj_revenue.ToString());
                newitem.SubItems.Add(node.name);
                newitem.Tag = node;
                listview.Items.Add(newitem);
            }
        }

        public void reset_pressed()
        {
            root_node = fakeTree();

            Node newnode = new Node();
            newnode.create_employee("Root", null, 0, "Root", null, false, true, root_node);
            e_root_node = newnode;
            
            projects = new List<Node>();
            updateTree.Invoke(this, new EventArgs());
        }
        
    }
}