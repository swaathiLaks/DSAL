using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace seat_simulation_asg
{
    [Serializable]
    internal class saveandload
    {
        public SeatDoubleLinkedList seatdll;
        public string rows_box;
        public string cols_box;
        public string rows_div;
        public string cols_div;
        public int combobox1;
        public Persons persons;
        public List<string> undo_serialized_actions;
        public List<string> redo_serialized_actions;
        public string form_name;
        public saveandload( SeatDoubleLinkedList seatdll, string rows_box, string cols_box, string rows_div, string cols_div, int combobox1, Persons persons, List<string> undo_serialized_actions, List<string> redo_serialized_actions, string form_name) 
        {
            this.seatdll = seatdll;
            this.rows_box = rows_box;
            this.cols_box = cols_box;
            this.rows_div = rows_div;
            this.cols_div = cols_div;
            this.combobox1 = combobox1;
            this.persons = persons;
            this.undo_serialized_actions = undo_serialized_actions;
            this.redo_serialized_actions = redo_serialized_actions;
            this.form_name = form_name;
        }
    }
}
