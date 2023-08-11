using seat_simulation_asg;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace seat_simulation_asg
{
    [Serializable]
    public partial class Form1 : Form
    {
        forms_functions forms_Functions = new forms_functions();
        //List<Control> controls = new List<Control>();
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            forms_Functions.form_main_loop(this.save_button, this.load_button, this.rows_box, this.cols_box, this.rows_div, this.cols_div, this.seat_gen, this.comboBox1, this.max_seats, this.per_a, this.per_b, this.per_c, this.per_d, this.per_e, this.per_f, this.per_g, this.per_h, this.end_sim, this.re_sim, this.commentary, this, this.manual, this.man_button, this.enable_radio, this.disable_radio, this.enable_all, this.disable_all, this.undo, this.redo);

        }
    }
}