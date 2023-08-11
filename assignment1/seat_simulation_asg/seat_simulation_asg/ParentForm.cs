
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seat_simulation_asg
{
    public partial class ParentForm : Form
    {
        public Form1 form1;
        public Form2 form2;
        public Form3 form3;
        public ParentForm()
        {
            InitializeComponent();
        }

        public void loadforms(Form formy, Type Formy)
        {
            if (formy != null)
            {
                formy.BringToFront();
            }
            else if (formy == null)
            {
                Form newformy = (Form)Activator.CreateInstance(Formy);
                newformy.MdiParent = this;
                newformy.Show();
                newformy.Dock = DockStyle.Fill;
            }
        }

        private void normalModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadforms(form1, typeof(Form1));
            form1 = (Form1)this.MdiChildren.FirstOrDefault(f => f.GetType() == typeof(Form1));
        }

        private void safeDistanceModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadforms(form2, typeof(Form2));
            form2 = (Form2)this.MdiChildren.FirstOrDefault(f => f.GetType() == typeof(Form2));
        }

        private void safeDistanceSmartModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadforms(form3, typeof(Form3));
            form3 = (Form3)this.MdiChildren.FirstOrDefault(f => f.GetType() == typeof(Form3));
        }
    }
}
