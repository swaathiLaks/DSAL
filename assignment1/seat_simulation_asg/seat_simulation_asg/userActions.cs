using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seat_simulation_asg
{
    [Serializable]
    internal class userActions
    {
        public List<Action> redo_useractions = new List<Action>();
        public List<Action> undo_useractions = new List<Action>();
        public List<string> undo_serialized_actions = new List<string>();
        public List<string> redo_serialized_actions = new List<string>();
        private bool isundoing = false;
        public bool was_pressed = false;
        public void addAction(Action action, Button undo_but, Button redo_but)
        {
           if (was_pressed && !isundoing) { redo_useractions.Clear(); }
           if (!isundoing) { undo_useractions.Add(action); }
           was_pressed = false;
           if (redo_useractions.Count() == 0) { redo_but.Enabled = false; } else { redo_but.Enabled = true; }
           if (undo_useractions.Count() == 0) { undo_but.Enabled = false; } else { undo_but.Enabled = true; }
        }

        public void Undo(Button undo_but, Button redo_but)
        {
            isundoing = true;
            undo_useractions[undo_useractions.Count() - 1].Invoke();
            redo_useractions.Add(undo_useractions[undo_useractions.Count() - 1]);
            undo_useractions.RemoveAt(undo_useractions.Count() - 1);
            isundoing=false;
            was_pressed = true;
            if (undo_useractions.Count() == 0) { undo_but.Enabled = false; } else { undo_but.Enabled = true; }
        }

        public void Redo(Button undo_but, Button redo_but)
        {
            isundoing = true;
            redo_useractions[redo_useractions.Count() - 1].Invoke();
            undo_useractions.Add(redo_useractions[redo_useractions.Count() - 1]);
            redo_useractions.RemoveAt(redo_useractions.Count() - 1);
            isundoing = false;
            was_pressed = true;
            if (redo_useractions.Count() == 0) { redo_but.Enabled = false; } else { redo_but.Enabled = true; }
        }
    }
}
