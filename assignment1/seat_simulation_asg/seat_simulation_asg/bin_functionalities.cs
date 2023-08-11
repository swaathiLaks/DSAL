using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace seat_simulation_asg
{
    [Serializable]
    internal class bin_functionalities
    {
        public void gen_serialize(string fileName, saveandload saveandload)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(stream, saveandload);
                stream.Close();
            }
        }
        public void Serialize(saveandload saveandload)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Binary File|*.bin";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    gen_serialize(fileName, saveandload);
                }
            }
            
        }

        public Object gen_deserialize(TextBox rows_box, TextBox cols_box, TextBox rows_div, TextBox cols_div, Button seat_gen, ComboBox combo, TextBox max_seats, Button per_a, Button per_b, Button per_c, Button per_d, Button per_e, Button per_f, Button per_g, Button per_h, Button end_sim, Button re_sim, Form aform, GroupBox groupBox, Button man_button, RadioButton enable_radio, RadioButton disable_radio, Button enable_all, Button disable_all, Button undo, Button redo, Form bform, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                saveandload saveandload = (saveandload)formatter.Deserialize(stream);
                var toreturn = populate_form(saveandload, rows_box, cols_box, rows_div, cols_div, seat_gen, combo, max_seats, per_a, per_b, per_c, per_d, per_e, per_f, per_g, per_h, end_sim, re_sim, aform, groupBox, man_button, enable_radio, disable_radio, enable_all, disable_all, undo, redo, bform);
                return toreturn;
            }
        }

        public Object populate_form(saveandload saveandload, TextBox rows_box, TextBox cols_box, TextBox rows_div, TextBox cols_div, Button seat_gen, ComboBox combo, TextBox max_seats, Button per_a, Button per_b, Button per_c, Button per_d, Button per_e, Button per_f, Button per_g, Button per_h, Button end_sim, Button re_sim, Form aform, GroupBox groupBox, Button man_button, RadioButton enable_radio, RadioButton disable_radio, Button enable_all, Button disable_all , Button undo, Button redo, Form bform)
        {
            //Textbox max_seats Label commentary
            Seats cseats = new Seats();
            userActions userac = new userActions();
            forms_functions  form_Functions = new forms_functions();
            rows_box.ForeColor = Color.RebeccaPurple;
            rows_box.Text = saveandload.rows_box;
            cols_box.Text = saveandload.cols_box;
            rows_div.Text = saveandload.rows_div;
            cols_div.Text = saveandload.cols_div;

            var rows = form_Functions.textbox_valid_int(rows_box, 25, "rows", false);
            if (rows is bool) { return false; }
            var cols = form_Functions.textbox_valid_int(cols_box, 25, "cols", false);
            if (cols is bool) { return false; }
            var cols_li = form_Functions.textbox_valid_list(cols_div, false);
            if (cols_li is bool) { return false; }
            var rows_li = form_Functions.textbox_valid_list(rows_box, false);
            if (rows_li is bool) { return false; }

            List<Button> buttons= new List<Button>() {per_a, per_b, per_c, per_d, per_e, per_f, per_g, per_h };

            cseats.genseats(saveandload.seatdll, bform, (List<int>)cols_li, (List<int>)rows_li, saveandload.persons, userac, man_button, enable_radio, disable_radio, undo, redo, groupBox,false);

            seat_gen.Enabled = false;
            
            combo.Enabled = true;
            if (saveandload.combobox1 > 0)
            {
                foreach (Node node in saveandload.seatdll)
                {
                    if (node.Seat.CanBook) { node.Seat.label.Enabled = true; }
                }
                max_seats.Enabled = true;
            }

            for (int i = 0; i < saveandload.persons.personslist.Count(); i++)
            {
                saveandload.persons.personslist[i].per_button = buttons[i];
                if (saveandload.persons.personslist[i].person_isbooking)
                {
                    saveandload.persons.personslist[i].per_button.Enabled = true;
                    saveandload.persons.personslist[i].per_button.BackColor = saveandload.persons.personslist[i].person_colour;
                    foreach (Seat seat in saveandload.persons.personslist[i].person_bookedseats)
                    {
                        seat.label.BackColor = saveandload.persons.personslist[i].person_colour;
                    }
                    Debug.WriteLine(saveandload.persons.personslist[i].max_seats.ToString());
                }
                else
                {
                    saveandload.persons.personslist[i].per_button.Enabled = false;
                }
            }
            groupBox.Enabled= true;
            List<Action> deserializedActions = new List<Action>();

            

            // Use the deserializedActions list as needed


            return new System.Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>(saveandload.seatdll, saveandload.persons, saveandload, deserializedActions);
        }

        public void enable_afterwards(ComboBox combo, saveandload saveandload)
        {
            combo.Text = saveandload.combobox1.ToString();
        }
        public Object Deserialize(TextBox rows_box, TextBox cols_box, TextBox rows_div, TextBox cols_div, Button seat_gen, ComboBox combo, TextBox max_seats, Button per_a, Button per_b, Button per_c, Button per_d, Button per_e, Button per_f, Button per_g, Button per_h, Button end_sim, Button re_sim, Form aform, GroupBox groupBox, Button man_button, RadioButton enable_radio, RadioButton disable_radio, Button enable_all, Button disable_all, Button undo, Button redo, Form bform)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Binary File|*.bin";
                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFileDialog.FileName;
                        BinaryFormatter formatter = new BinaryFormatter();
                        using (FileStream stream = new FileStream(fileName, FileMode.Open))
                        {
                            saveandload saveandload = (saveandload)formatter.Deserialize(stream);
                            if (saveandload.form_name != bform.GetType().Name)
                            {
                                throw new Exception("Force exception; Not correct simulation.");
                            }
                            var toreturn = populate_form(saveandload, rows_box, cols_box, rows_div, cols_div, seat_gen, combo, max_seats, per_a, per_b, per_c, per_d, per_e, per_f, per_g, per_h, end_sim, re_sim, aform, groupBox, man_button, enable_radio, disable_radio, enable_all, disable_all, undo, redo, bform);
                            return toreturn;
                        }
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to open file.\n{ex.Message}");
                    return false;
                }               
            }
            
        }


    }
}
