using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace seat_simulation_asg
{
    [Serializable]
    internal class forms_functions
    {
        private Persons persons;
        private Seats cseats = new Seats();
        private SeatDoubleLinkedList seatdll = null;
        private userActions userac = new userActions();
        private bin_functionalities bin_func = new bin_functionalities();

        //checks if textbox has valid integer
        public Object textbox_valid_int(TextBox textbox, int max, string endsentence, bool inform = true)
        {
            if ((!int.TryParse(textbox.Text, out int value)||value<0||value>max))
            {
                if (inform) { MessageBox.Show($"Please enter a valid integer between 0 and {max} for {endsentence}."); }                
                return false;
            }
            else
            {
                return value;
            }
        }

        //checks if textbox has valid int list
        public Object textbox_valid_list(TextBox textbox, bool inform = true)
        {
            string[] values = textbox.Text.Split(',');
            List<int> numlist = new List<int>();
            bool wronginput=false;
            foreach (string value in values)
            {
                if (!int.TryParse(value.Trim(), out int newval))
                {
                    wronginput = true;
                    break;
                }
                else
                {
                    numlist.Add(newval);
                }
            }
            if (wronginput)
            {
                if (inform) { MessageBox.Show("Please enter integer values seperated by commas for dividers."); }              
                return false;
            }
            else
            {
                return numlist;
            }
        }
        
        //function for if generate button is pressed
        public Object gen_pressed(TextBox rows_box, TextBox cols_box, TextBox rows_div, TextBox cols_div)
        {
            Object rows = textbox_valid_int(rows_box, 25, "rows");
            if (rows is bool) { return false; }
            Object cols = textbox_valid_int(cols_box, 25, "cols");
            if (cols is bool) { return false; }
            Object rows_div_list = textbox_valid_list(rows_div);
            if (rows_div_list is bool) { return false; }
            Object cols_div_list = textbox_valid_list(cols_div);
            if (cols_div_list is bool) { return false; }

            return new List<Object> {rows, cols, rows_div_list, cols_div_list };
        }

        
        public void form_main_loop(Button save_but, Button load_but, TextBox rows_box, TextBox cols_box, TextBox rows_div, TextBox cols_div, Button seat_gen, ComboBox combo, TextBox max_seats, Button per_a, Button per_b, Button per_c, Button per_d, Button per_e, Button per_f, Button per_g, Button per_h, Button end_sim, Button re_sim, Label commentary, Form aform, GroupBox groupBox, Button man_button, RadioButton enable_radio, RadioButton disable_radio, Button enable_all, Button disable_all, Button undo, Button redo)
        {
            bool isreload = true;
            string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string filePath = Path.Combine(downloadFolderPath, $"YourFile{aform.GetType().Name}.bin");
            List<Control> controls = new List<Control>();
            persons = new Persons(per_a, per_b, per_c, per_d, per_e, per_f, per_g, per_h);
            List<Object> row_col_list = new List<Object>() { false, false, false, false};
            Object row_col_vals=false;
            int max_people = 0;
            int total_seats=0;
            List<string> man_but_li = new List<string> { "disable editor", "enable editor" };

            //disabling all controls
            combo.Enabled = false;
            max_seats.Enabled = false;
            per_a.Enabled = false;
            per_b.Enabled = false;
            per_c.Enabled = false;
            per_d.Enabled = false;
            per_e.Enabled = false;
            per_f.Enabled = false;
            per_g.Enabled = false;
            per_h.Enabled = false;
            end_sim.Enabled = true;
            re_sim.Enabled = false;
            commentary.Enabled = false;
            groupBox.Enabled = false;
            disable_radio.Checked=true;
            undo.Enabled = false;
            redo.Enabled = false;
            enable_radio.Enabled = false;
            disable_radio.Enabled = false;
            enable_all.Enabled = false;
            disable_all.Enabled = false;
            if (aform is Form3)
            {
                rows_div.Text = "3,8";
                cols_div.Text = "3,8";
                rows_div.Enabled = false;
                cols_div.Enabled = false;
            }
            //events
            seat_gen.Click += Seat_gen_Click;
            combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
            per_a.Click += Per_a_Click;
            per_b.Click += Per_b_Click;
            per_c.Click += Per_c_Click;
            per_d.Click += Per_d_Click;
            per_e.Click += Per_e_Click;
            per_f.Click += Per_f_Click;
            per_g.Click += Per_g_Click;
            per_h.Click += Per_h_Click;
            max_seats.TextChanged += Max_seats_TextChanged;
            save_but.Click += Save_but_Click;
            load_but.Click += Load_but_Click;
            re_sim.Click += Re_sim_Click;
            end_sim.Click += End_sim_Click;
            man_button.Click += Man_button_Click;
            enable_all.Click += Enable_all_Click;
            disable_all.Click += Disable_all_Click;
            undo.Click += Undo_Click;
            redo.Click += Redo_Click;

            void reset_form()
            {
                persons = new Persons(per_a, per_b, per_c, per_d, per_e, per_f, per_g, per_h);
                row_col_list = new List<Object>() { false, false, false, false };
                row_col_vals = false;
                max_people = 0;
                total_seats = 0;

                List<string> man_but_li = new List<string> { "disable editor", "enable editor" };
                rows_box.Text = "";
                cols_box.Text = "";
                cols_div.Text = "";
                seat_gen.Enabled = true;
                
                combo.Enabled = false;              
                max_seats.Enabled = false;
                per_a.Enabled = false;
                per_a.BackColor = Color.White;
                per_b.Enabled = false;
                per_b.BackColor = Color.White;
                per_c.Enabled = false;
                per_c.BackColor = Color.White;
                per_d.Enabled = false;
                per_d.BackColor = Color.White;
                per_e.Enabled = false;
                per_e.BackColor = Color.White;
                per_f.Enabled = false;
                per_f.BackColor = Color.White;
                per_g.Enabled = false;
                per_g.BackColor = Color.White;
                per_h.Enabled = false;
                per_h.BackColor = Color.White;
                end_sim.Enabled = true;
                re_sim.Enabled = true;
                commentary.Enabled = false;
                groupBox.Enabled = false;
                disable_radio.Checked = true;
                enable_radio.Enabled = false;
                disable_radio.Enabled = false;
                enable_all.Enabled = false;
                disable_all.Enabled = false;
                if (seatdll!=null)
                {
                    foreach (Node node in seatdll)
                    {
                        node.Seat.label.Parent.Controls.Remove(node.Seat.label);
                    }

                    seatdll = null;
                }
                userac.undo_useractions.Clear();
                userac.redo_useractions.Clear();
            }

            void Load_but_Click(object? sender, EventArgs e)
            {
                reset_form();
                Object returned_tuple = bin_func.Deserialize(rows_box,cols_box,rows_div,cols_div,seat_gen,combo,max_seats,per_a,per_b,per_c,per_d,per_e,per_f,per_g,per_h,end_sim,re_sim,aform,groupBox, man_button,enable_radio,disable_radio,enable_all, disable_all, undo, redo, aform);
                if (returned_tuple is Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>)
                {
                    seatdll = ((Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>)returned_tuple).Item1;
                    persons = ((Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>)returned_tuple).Item2;
                    var saveandload1 = ((Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>)returned_tuple).Item3;
                    bin_func.enable_afterwards(combo, saveandload1);
                    total_seats = seatdll.numRows * seatdll.numCols;
                }            
            }

            void Save_but_Click(object? sender, EventArgs e)
            {
                saveandload saveandload = new saveandload(seatdll, rows_box.Text, cols_box.Text, rows_div.Text, cols_box.Text,max_people,persons,userac.undo_serialized_actions, userac.redo_serialized_actions,aform.GetType().Name);
                bin_func.Serialize(saveandload);
            }

            void Re_sim_Click(object? sender, EventArgs e)
            {
                reset_form();
                
                Object returned_tuple = bin_func.gen_deserialize(rows_box, cols_box, rows_div, cols_div, seat_gen, combo, max_seats, per_a, per_b, per_c, per_d, per_e, per_f, per_g, per_h, end_sim, re_sim, aform, groupBox, man_button, enable_radio, disable_radio, enable_all, disable_all, undo, redo, aform, filePath);
                if (returned_tuple is Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>)
                {
                    seatdll = ((Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>)returned_tuple).Item1;
                    persons = ((Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>)returned_tuple).Item2;
                    var saveandload1 = ((Tuple<SeatDoubleLinkedList, Persons, saveandload, List<Action>>)returned_tuple).Item3;
                    bin_func.enable_afterwards(combo, saveandload1);
                    total_seats = seatdll.numRows * seatdll.numCols;
                }
            }

            void End_sim_Click(object? sender, EventArgs e)
            {
                foreach (Person person in persons.personslist)
                {
                    person.per_button.Enabled = false;
                }
                seat_gen.Enabled = false;
                groupBox.Enabled = false;
                end_sim.Enabled = false;
                combo.Enabled = false;
                max_seats.Enabled = false;
                rows_box.Enabled = false;
                cols_box.Enabled = false;
                rows_div.Enabled = false;
                cols_div.Enabled = false;
            }

            void Seat_gen_Click(object? sender, EventArgs e)
            {
                row_col_vals = gen_pressed(rows_box, cols_box, rows_div, cols_div);
                if (row_col_vals is List<Object>)
                {
                    row_col_list = (List<Object>)row_col_vals;
                    seatdll = new SeatDoubleLinkedList((int)row_col_list[0], (int)row_col_list[1]);
                    cseats.genseats(seatdll, aform, (List<int>)row_col_list[2], (List<int>)row_col_list[3], persons, userac,man_button, enable_radio, disable_radio, undo, redo , groupBox, true);
                    combo.Enabled = true;
                    groupBox.Enabled = true;                     
                    seat_gen.Enabled=false;
                    total_seats = (int)row_col_list[0] * (int)row_col_list[1];
                }
                saveandload saveandload = new saveandload(seatdll, rows_box.Text, cols_box.Text, rows_div.Text, cols_box.Text, max_people, persons, userac.undo_serialized_actions, userac.redo_serialized_actions,aform.GetType().Name);
                bin_func.gen_serialize(filePath, saveandload);

                re_sim.Enabled = true;
            }

           

            //function for combobox
            void Combo_SelectedIndexChanged(object? sender, EventArgs e)
            {
                if (int.TryParse(combo.Text, out max_people) && max_people < 9 && max_people > 3)
                {
                    if (persons.personslist[0].per_button.Enabled && max_people< persons.booking_ppl_num)
                    {
                        MessageBox.Show("This change requires you to reset the simulation.");
                    }
                    else
                    {
                        persons.booking_ppl_num = max_people;
                        persons.availpeople(max_people);
                        foreach (Node node in seatdll)
                        {
                            if (node.Seat.CanBook)
                            {
                                node.Seat.label.Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid integer between 4 and 8.");
                }
                
            }

            void Max_seats_TextChanged(object? sender, EventArgs e)
            {
                if (persons.currentbooker != null && int.TryParse(max_seats.Text, out int num) && num >= 0 && num <= (total_seats / 8) && persons.currentbooker.max_seats <= num)
                {
                    persons.currentbooker.max_seats = (int)num;
                    Action maxseatstextchanged = () => Max_seats_TextChanged(sender, e);
                }
                else if (!string.IsNullOrEmpty(max_seats.Text) && max_seats.Text != "0")
                {
                    MessageBox.Show($"Please enter a valid integer between 1 and {total_seats / 8}.");
                }              
            }

            void every_man_button_press()
            {
                if (man_button.Text == "enable editor")
                {
                    foreach (Node node in seatdll)
                    {
                        if (!node.Seat.CanBook)
                        {
                            node.Seat.label.Enabled = false;
                            node.Seat.label.BackColor = Color.AliceBlue;
                        }
                    }
                    enable_radio.Enabled = false;
                    disable_radio.Enabled = false;
                    enable_all.Enabled = false;
                    disable_all.Enabled = false;
                }
                else
                {
                    foreach (Node node in seatdll)
                    {
                        if (!node.Seat.CanBook)
                        {
                            node.Seat.label.BackColor = Color.Plum;
                            node.Seat.label.Enabled = true;
                        }
                    }
                    enable_radio.Enabled = true;
                    disable_radio.Enabled = true;
                    enable_all.Enabled = true;
                    disable_all.Enabled = true;
                }
            }

            void Man_button_Click(object? sender, EventArgs e)
            {
                List<object> form_controls = new List<object> { per_a, per_b, per_c, per_d, per_e, per_f, per_g, per_h, max_seats, combo };
                foreach (object obj in form_controls)
                {
                    if (obj is Button button)
                    {
                        button.Enabled = !button.Enabled;
                    }
                    else if (obj is TextBox textbox)
                    {
                        textbox.Enabled = !textbox.Enabled;
                    }
                    else if (obj is ComboBox comboBox)
                    {
                        comboBox.Enabled = !comboBox.Enabled;
                    }
                }

                man_button.Text = man_but_li[0];
                man_but_li[0] = man_but_li[1];
                man_but_li[1] = man_button.Text;

                every_man_button_press();
                Action manbuttonclick = () => Man_button_Click(sender, e);
                userac.addAction(manbuttonclick, undo, redo);
            }

            void Redo_Click(object? sender, EventArgs e)
            {
                userac.Redo(undo, redo);                               
            }

            void Undo_Click(object? sender, EventArgs e)
            {
                userac.Undo(undo, redo);
            }

            void Disable_all_Click(object? sender, EventArgs e)
            {
                if (man_button.Text == "disable editor") { cseats.disable_all(seatdll); }
                Action disableallclick = () => Disable_all_Click(sender, e);
                userac.addAction(disableallclick, undo, redo);
            }

            void Enable_all_Click(object? sender, EventArgs e)
            {
                if (man_button.Text == "disable editor") { cseats.enable_all(seatdll); }
                Action enableallclick = () => Enable_all_Click(sender, e);
                userac.addAction(enableallclick, undo, redo);
            }

            void for_every_click(Person person)
            {
                max_seats.Enabled = true;
                max_seats.Text = person.max_seats.ToString();
                
                persons.currentbooker = person;
                Action foreveryclick = () => for_every_click(person);
                userac.addAction(foreveryclick, undo, redo);
            }

            void Per_h_Click(object? sender, EventArgs e)
            {
                for_every_click(persons.personslist[7]);
            }

            void Per_g_Click(object? sender, EventArgs e)
            {
                for_every_click(persons.personslist[6]);
            }

            void Per_f_Click(object? sender, EventArgs e)
            {
                for_every_click(persons.personslist[5]);
            }

            void Per_e_Click(object? sender, EventArgs e)
            {
                for_every_click(persons.personslist[4]);
            }

            void Per_d_Click(object? sender, EventArgs e)
            {
                for_every_click(persons.personslist[3]);
            }

            void Per_c_Click(object? sender, EventArgs e)
            {
                for_every_click(persons.personslist[2]);
            }

            void Per_b_Click(object? sender, EventArgs e)
            {
                for_every_click(persons.personslist[1]);
            }

            void Per_a_Click(object? sender, EventArgs e)
            {
                for_every_click(persons.personslist[0]);
            }

            


        }//end
    }
}
