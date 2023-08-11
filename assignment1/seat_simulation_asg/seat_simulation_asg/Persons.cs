using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seat_simulation_asg
{
    [Serializable]
    internal class Persons
    {
        public List<Person> personslist = new List<Person>();
        private Person personA;
        private Person personB;
        private Person personC;
        private Person personD;
        private Person personE;
        private Person personF;
        private Person personG;
        private Person personH;
        public Person currentbooker { get; set; }
        public int booking_ppl_num;

        public Persons(Button perA, Button perB, Button perC, Button perD, Button perE, Button perF, Button perG, Button perH)
        {
            // create your Person objects and pass the button references
            this.personA = new Person(Color.Orchid, perA, Color.Pink);
            this.personB = new Person(Color.MediumSlateBlue, perB, Color.Thistle);
            this.personC = new Person(Color.MediumSpringGreen, perC, Color.PaleGreen);
            this.personD = new Person(Color.MediumSeaGreen, perD, Color.MediumTurquoise);
            this.personE = new Person(Color.LightSkyBlue, perE, Color.MintCream);
            this.personF = new Person(Color.DodgerBlue, perF, Color.SkyBlue);
            this.personG = new Person(Color.Wheat, perG, Color.LightGoldenrodYellow);
            this.personH = new Person(Color.Coral, perH, Color.MistyRose);

            // add your Person objects to the list
            this.personslist.Add(personA);
            this.personslist.Add(personB);
            this.personslist.Add(personC);
            this.personslist.Add(personD);
            this.personslist.Add(personE);
            this.personslist.Add(personF);
            this.personslist.Add(personG);
            this.personslist.Add(personH);
        }

        public void availpeople(int num)
        {
            for (int i = 0; i < num; i++)
            {
                personslist[i].makeavail(true);
            }
        }
    }



}
