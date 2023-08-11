using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace treeViewAssignment2
{
    [Serializable]
    public class Node
    {
        public string uuid { get; set; }
        public string name = null;
        public string reporting_officer = null;
        public int salary = 0;
        public string role { get; set; }
        public string projects = null;
        public bool dummy_data = false;
        public bool salary_accountable = false;
        public bool proj_lead = false;
        public bool is_role = false;
        public List <Node> childnodes = new List <Node> ();
        public Node role_node = null;
        public string display_id = null;
        public bool last_leaf = false;
        public List<Node> employee_nodes = new List <Node> ();
        public int proj_revenue = 0;
        public bool got_all_roles = false;
        public string display_name { get; set; }
        private string genUuid(string strnode)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(strnode);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        public void create_role(string role, bool proj_lead)
        {
            this.role = role;
            this.proj_lead = proj_lead;
            this.is_role = true;
            this.uuid = genUuid(role+proj_lead.ToString());
            this.display_name = role;
        }

        public void create_employee(string name, string reporting_officer, int salary, string role, string projects, bool dummy_data, bool salary_accountable, Node role_node)
        {
            this.name = name;
            this.proj_lead = role_node.proj_lead;
            this.reporting_officer = reporting_officer;
            this.salary = salary;
            this.role = role;
            this.projects = projects;
            this.dummy_data = dummy_data;
            this.salary_accountable=salary_accountable;
            this.role_node = role_node;
            this.uuid = genUuid(name+reporting_officer+salary.ToString()+role);
            this.display_name = name+ " - " + role + " (S$" + salary.ToString() + ")";
            role_node.employee_nodes.Add(this);
        }

        
    }
}
