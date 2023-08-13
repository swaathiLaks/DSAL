using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace treeViewAssignment2
{
    public class Tree
    {
        public Node root_node;
        public Tree(Node root_node) 
        {
            this.root_node = root_node;
        }

        public Node recursive(Node x)
        {
            return DFS(root_node, x, root_node);
        }

        private Node DFS(Node node, Node x, Node parent)
        {
            if (node.uuid == x.uuid)
            {
                return parent;
            }
                

            foreach (var childNode in node.childnodes)
            {
                Node result = DFS(childNode, x, node);
                if (result != null)
                    return result;
            }

            return null;
        }

        public Node namerecursive(Node x)
        {
            return nameDFS(root_node, x);
        }

        private Node nameDFS(Node node, Node x)
        {
            if (node.uuid!= x.uuid && node.name == x.name && !x.is_role)
            {
                return node;
            }
            if(x.is_role && node.uuid != x.uuid && node.role == x.role) { return node; } 

            foreach (var childNode in node.childnodes)
            {
                Node result = nameDFS(childNode, x);
                if (result != null)
                    return result;
            }

            return null;
        }

        public List<Node> namesrecursive(Node x)
        {
            List<Node> all_names = new List<Node>();
            namesDFS(root_node, x, all_names);
            return all_names;
        }

        private void namesDFS(Node node, Node x, List<Node> all_names)
        {
            if (node.uuid != x.uuid && node.name == x.name && !x.is_role)
            {
                all_names.Add(node);
            }

            foreach (var childNode in node.childnodes)
            {
                namesDFS(childNode, x, all_names);
            }
        }

        public void addNode(Node parent_node, Node node, bool ischrole=false)
        {
            Node check_name = namerecursive(node);
            if (recursive(node) == null && !ischrole && check_name==null)
            {
                parent_node.childnodes.Add(node);
                node.display_id = Guid.NewGuid().ToString();
            }
            else
            {
                MessageBox.Show("Node already exists");
            }

            if (!node.is_role)
            {
                if (check_name != null && ischrole)
                {
                    parent_node.childnodes.Add(node);
                    node.display_id = check_name.display_id;
                    node.got_all_roles = true;
                    check_name.got_all_roles = true;
                    node.display_name =  node.name + " - " + node.role + " (S$" + node.salary.ToString() + ")" + $" (Also {check_name.role})";
                    check_name.display_name = check_name.name + " - " + check_name.role + " (S$" + check_name.salary.ToString() + ")" + $" (Also {node.role})";
                }
            }

            if (parent_node.proj_lead)
            {
                node.last_leaf = true;
            }
        }

        public void deleteNode(Node node)
        {
            Node parent_node = recursive(node);
            parent_node?.childnodes.Remove(node);
            if (!node.is_role)
            {
                node.role_node.employee_nodes.Remove(node);
            }
        }

        public void editNode(Node node, List<Object> list) 
        {
            if (node.is_role)
            {
                node.role = list[0].ToString();
                node.display_name = list[0].ToString();
                node.proj_lead = (bool)list[1];
            }
            else
            {
                node.name = list[0].ToString();
                if (int.TryParse(list[1]?.ToString(), out int salary))
                {
                    node.salary = salary;
                    node.display_name = list[0].ToString()+" - " + node.role + " (S$" + node.salary.ToString() + ")";
                }
                node.dummy_data = (bool)list[2];
                
            }
        }

        public List<string> get_all_projects(Node x)
        {
            List<string> projects = new List<string>();
            get_remaining_projects(x, projects);
            return projects;
        }

        public void get_remaining_projects(Node x, List<string> projects)
        {
            if (x.proj_lead && x.projects != null)
            {
                projects.Add(x.projects);
            }
            else
            {
                foreach (Node childnode in x.childnodes)
                {
                    get_remaining_projects(childnode, projects);
                }
            }
        }

        public void delete_all_employees()
        {
            delete_remaining_employees(root_node);
        }

        public void delete_remaining_employees(Node parent_node)
        {
            for (int i = 0; i < parent_node.childnodes.Count; i++)
            {
                parent_node.childnodes[i].employee_nodes.Clear();
                delete_remaining_employees(parent_node.childnodes[i]);
            }
        }

        public bool check_for_full_team(Node node)
        {
            foreach (Node roleNode in node.role_node.childnodes)
            {
                bool roleFound = false;
                foreach (Node employeeNode in node.childnodes)
                {
                    if (employeeNode.role == roleNode.role)
                    {
                        roleFound = true;
                        break;
                    }
                }
                if (!roleFound)
                {
                    return false;
                }
            }
            return true;
        }

    }
}