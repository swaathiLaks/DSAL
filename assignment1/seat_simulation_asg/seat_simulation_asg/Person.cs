using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seat_simulation_asg
{
    [Serializable]
    internal class Person
    {
        public bool person_isbooking = false;
        public Color person_colour = Color.White;
        public List<Seat> person_bookedseats = new List<Seat>();
        [NonSerialized] public Button per_button;
        public Color form3_colour;
        public int max_seats { get; set; }

        public Person(Color person_colour, Button per_button, Color form3_colour)
        {
            this.person_colour = person_colour;
            this.per_button = per_button;
            this.form3_colour = form3_colour;
            per_button.Enabled = false;
        }

        public void makeavail(bool person_isbooking)
        {
            this.person_isbooking=person_isbooking;
            if (person_isbooking)
            {
                per_button.Enabled = true;
                per_button.BackColor = (Color)this.person_colour;
            }
            else
            {
                per_button.Enabled = false;
            }
        }
    }
    
}
