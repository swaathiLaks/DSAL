using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace treeViewAssignment2
{
    internal class getNode
    {
        public string text { get; set; }
        public Node node { get; set; }

        public override string ToString()
        {
            return text;
        }
    }
}
