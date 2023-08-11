using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace seat_simulation_asg
{
    [Serializable]
    internal class Seats
    {
        //Function to calculate seat space
        private void incrementseat(SeatDoubleLinkedList alist, List<int> collist, List<int>rowlist)
        {
            for(int j=0;  j<alist.numRows; j++) 
            {
                int isspacecol = 0;
                for (int i = 0; i < alist.numCols; i++)
                {
                    if (collist.Contains(i + 1))
                    {
                        alist.GetSeat(j, i).IsSpaceCol = isspacecol;
                        isspacecol++;
                    }
                    else
                    {
                        alist.GetSeat(j, i).IsSpaceCol = isspacecol;
                    }
                }
            }
            for (int j = 0; j < alist.numCols; j++)
            {
                int isspacerow = 0;
                for (int i = 0; i < alist.numRows; i++)
                {
                    if (rowlist.Contains(i + 1))
                    {
                        alist.GetSeat(i,j).IsSpaceRow = isspacerow;
                        isspacerow++;
                    }
                    else
                    {
                        alist.GetSeat(i,j).IsSpaceRow= isspacerow;
                    }
                }
            }

        }

        //Function to generate one seat
        public void genseat(Seat s, Form aform, Persons persons, SeatDoubleLinkedList aseatlist, userActions userac, Button undo, Button redo, Button man_button, RadioButton enable_radio, RadioButton disable_radio, GroupBox groupBox)
        {
            Label labels = new Label();
            labels.Text = s.ComputeSeatLabel();
            labels.Location = new Point(400+(60 * (s.Col + 1) + 22 * s.Col+s.IsSpaceCol*50), 88+(60 * (s.Row + 1) + 22 * s.Row+s.IsSpaceRow*50));
            labels.Size = new Size(60, 60);
            labels.BorderStyle = BorderStyle.FixedSingle;
            labels.TextAlign = ContentAlignment.MiddleCenter;
            labels.BackColor = Color.AliceBlue;
            labels.ForeColor = Color.Black;
            labels.Tag = s;
            labels.Enabled = false;
            s.label = labels;
            aform.Controls.Add(labels);
            labels.Click += (sender, e) => labelSeat_Click(sender, e, s, persons.currentbooker, aseatlist, aform, man_button, enable_radio, disable_radio, userac, undo, redo, groupBox);
        }

        //Function to generate seats
        public void genseats(SeatDoubleLinkedList alist, Form aform, List<int> collist, List<int> rowlist, Persons persons, userActions userac, Button man_button, RadioButton enable_radio, RadioButton disable_radio, Button undo, Button redo, GroupBox groupBox, bool ifneeded = true )
        {
            if (ifneeded) { incrementseat(alist, rowlist, collist); }
            for (int i = 0; i < alist.numRows; i++)
            {
                for (int j = 0; j < alist.numCols; j++)
                {
                    Seat seat = alist.GetSeat(i, j);
                    genseat(seat, aform, persons, alist, userac, undo, redo, man_button, enable_radio, disable_radio, groupBox);
                }
            }
            if (aform is Form2)
            {  
                for (int j = 2; j < alist.numCols; j++)
                {
                    if(alist.GetSeat(0,j).IsSpaceCol> alist.GetSeat(0, j - 1).IsSpaceCol)
                    {
                        alist.GetSeat(0, j).CanBook = alist.GetSeat(0, j - 1).CanBook;
                    }
                    else
                    {
                        alist.GetSeat(0, j).CanBook = !alist.GetSeat(0, j - 1).CanBook;
                        if ((j + 1) < alist.numCols)
                        {
                            alist.GetSeat(0, j + 1).CanBook = alist.GetSeat(0, j).CanBook;
                        }
                        j++;
                    }
                }

                for (int j = 0;j < alist.numCols; j++)
                {
                    for(int i = 1; i<alist.numRows; i++)
                    {
                        alist.GetSeat(i,j).CanBook = !alist.GetNode(i,j).Up.Seat.CanBook;
                    }
                }

            }
        }

        public void person_with_seat(Seat s)
        {
            if (s.person != null)
            {
                s.BookStatus = false;
                s.person.person_bookedseats.Remove(s);
                s.person = null;
            }
        }

        //Function to check if seat is booked and change colour accordingly
        public void valid_objectclicked(Seat s,Person person, object sender, GroupBox groupBox, userActions userac, Button undo, Button redo, Node seatnode=null, Form aform = null)
        {
            if (s.BookStatus == false)
            {
                ((Label)sender).BackColor = person.person_colour;
                s.BookStatus = true;
                person.person_bookedseats.Add(s);
                person.person_bookedseats=person.person_bookedseats.OrderBy(o => o.Col).ToList();
                person.person_bookedseats = person.person_bookedseats.Distinct().ToList();
                s.person = person;
                groupBox.Enabled = false;
                if (aform is Form3)
                {
                    change_colour(seatnode, person.form3_colour, person, person);
                }
                else if (!(aform is Form3)||person.person_bookedseats.Count() == 0)
                {
                    Action validobjectclicked = () => valid_objectclicked(s, person, sender, groupBox, userac, undo, redo, seatnode, aform);
                    userac.addAction(validobjectclicked, undo, redo);
                }
                
            }
            else
            {   if (s.person==person)
                {
                    s.BookStatus = false;
                    ((Label)sender).BackColor = Color.AliceBlue;
                    person.person_bookedseats.Remove(s);
                    Action validobjectclicked = () => valid_objectclicked(s, person, sender, groupBox, userac, undo, redo, seatnode, aform);
                    userac.addAction(validobjectclicked, undo, redo);
                }
                else { MessageBox.Show("Seat cannot be booked"); }                
            }
        }

        //function to change colour
        private void change_colour(Node aseatnode, Color colour, Person person, Person aperson = null)
        {

            if (aseatnode.Prev != null && !aseatnode.Prev.Seat.BookStatus && (aseatnode.Prev.Seat.form3_adj==null|| aseatnode.Prev.Seat.form3_adj==person) && (aseatnode.Prev.Seat.IsSpaceCol == aseatnode.Seat.IsSpaceCol)) { aseatnode.Prev.Seat.form3_adj = aperson; aseatnode.Prev.Seat.label.BackColor = colour; }

            if (aseatnode.Next != null  && !aseatnode.Next.Seat.BookStatus && (aseatnode.Next.Seat.form3_adj == null || aseatnode.Next.Seat.form3_adj == person)&&(aseatnode.Next.Seat.IsSpaceCol == aseatnode.Seat.IsSpaceCol)) { aseatnode.Next.Seat.form3_adj = aperson;  aseatnode.Next.Seat.label.BackColor = colour; }

            if (aseatnode.Up != null && !aseatnode.Up.Seat.BookStatus && (aseatnode.Up.Seat.form3_adj == null || aseatnode.Up.Seat.form3_adj == person)&&(aseatnode.Up.Seat.IsSpaceRow == aseatnode.Seat.IsSpaceRow)) { aseatnode.Up.Seat.form3_adj = aperson; aseatnode.Up.Seat.label.BackColor = colour; }

            if (aseatnode.Down != null && !aseatnode.Down.Seat.BookStatus && (aseatnode.Down.Seat.form3_adj == null || aseatnode.Down.Seat.form3_adj == person) && (aseatnode.Down.Seat.IsSpaceRow == aseatnode.Seat.IsSpaceRow)) { aseatnode.Down.Seat.form3_adj = aperson; aseatnode.Down.Seat.label.BackColor = colour; }
        }

        //function if form 3 seat is being clicked
        public void smartmode(Person person, Seat s, object sender, SeatDoubleLinkedList aseatlist, Form aform, GroupBox groupBox, userActions userac, Button undo, Button redo)
        {
            Node seatnode = aseatlist.GetNode(s.Row, s.Col);

            
            if ((s.form3_adj == null || s.form3_adj == person)&&(s.person==null)&&(!s.BookStatus)&&(person.person_bookedseats.Count() < person.max_seats) && (seatnode.Prev != null && person == seatnode.Prev.Seat.person || seatnode.Next != null && person == seatnode.Next.Seat.person || seatnode.Up != null && person == seatnode.Up.Seat.person || seatnode.Down != null && person == seatnode.Down.Seat.person))
            {               
                valid_objectclicked(s, person, sender, groupBox, userac, undo, redo, seatnode, aform);

                Action smartmode1 = () => smartmode(person, s, sender, aseatlist, aform, groupBox, userac, undo, redo);
                userac.addAction(smartmode1, undo, redo);
            }
            else if(person==s.person&& s.BookStatus)
            {
                s.BookStatus=false;
                HashSet<Seat> checkedSeats = new HashSet<Seat>();
                List<Seat> bookedseats = new List<Seat>();
                change_colour(seatnode, Color.AliceBlue, person);

                void check_ifbooked(Node seatnode)
                {
                    Seat seat = seatnode.Seat;
                    if (checkedSeats.Contains(seat))
                    {
                        return;
                    }
                    checkedSeats.Add(seat);

                    if (seat.BookStatus && seat.person == person)
                    {
                        inner_check_fn(seatnode);
                        bookedseats.Add(seat);
                        change_colour(seatnode,person.form3_colour, person, person);
                    }
                }

                void inner_check_fn(Node seatnode)
                {
                    if (seatnode.Prev != null && !checkedSeats.Contains(seatnode.Prev.Seat))
                    {
                        check_ifbooked(seatnode.Prev);
                    }
                    if (seatnode.Next != null && !checkedSeats.Contains(seatnode.Next.Seat))
                    {
                        check_ifbooked(seatnode.Next);
                    }
                    if (seatnode.Up != null && !checkedSeats.Contains(seatnode.Up.Seat))
                    {
                        check_ifbooked(seatnode.Up);
                    }
                    if (seatnode.Down != null && !checkedSeats.Contains(seatnode.Down.Seat))
                    {
                        check_ifbooked(seatnode.Down);
                    }
                }
                
                if (seatnode.Prev != null && seatnode.Prev.Seat.BookStatus == true)
                {
                    inner_check_fn(seatnode.Prev);
                }
                else if (seatnode.Next != null && seatnode.Next.Seat.BookStatus == true)
                {
                    inner_check_fn(seatnode.Next);
                }
                else if (seatnode.Up != null && seatnode.Up.Seat.BookStatus == true)
                {
                    inner_check_fn(seatnode.Up);
                }
                else if (seatnode.Down != null && seatnode.Down.Seat.BookStatus == true)
                {
                    inner_check_fn(seatnode.Down);
                }
                Debug.WriteLine("count" + person.person_bookedseats.Count() + " " + bookedseats.Count());
                if (person.person_bookedseats.Count()>2&&(bookedseats.Count() < person.person_bookedseats.Count()-1)) 
                {
                    s.BookStatus = true;
                    change_colour(seatnode, person.form3_colour, person);
                    Debug.WriteLine("colour");
                    s.label.BackColor = person.person_colour;                 
                    MessageBox.Show("Seat cannot be unbooked.\nAll seats have to be connected");
                }
                else
                {
                    s.BookStatus = false;
                    if (person.person_bookedseats.Count() > 1)
                    {
                        if ((seatnode.Prev != null &&seatnode.Prev.Seat.BookStatus == true && (s.IsSpaceCol != seatnode.Prev.Seat.IsSpaceCol)) || (seatnode.Next != null && seatnode.Next.Seat.BookStatus == true && (s.IsSpaceCol != seatnode.Next.Seat.IsSpaceCol)) || (seatnode.Up != null && seatnode.Up.Seat.BookStatus == true && (s.IsSpaceRow != seatnode.Up.Seat.IsSpaceRow)) || (seatnode.Down != null && seatnode.Down.Seat.BookStatus == true && (s.IsSpaceRow != seatnode.Down.Seat.IsSpaceRow))) { s.label.BackColor = Color.AliceBlue; }
                        else { s.label.BackColor = person.form3_colour; }                       
                    }
                    else
                    {
                        s.label.BackColor = Color.AliceBlue;
                    }   
                    s.person = null;
                    person.person_bookedseats.Remove(s);
                }
                Action smartmode1 = () => smartmode(person, s, sender, aseatlist, aform, groupBox, userac, undo, redo);
                userac.addAction(smartmode1, undo, redo);
            }
            else
            {
                MessageBox.Show("All booked seats have to be connected.");
            }
        }
        

    //function for form 1 seat being clicked
    public void normalmode(Person person, Seat s, object sender, SeatDoubleLinkedList aseatlist, GroupBox groupBox, userActions userac, Button undo, Button redo)
        {
            Node seatnode = aseatlist.GetNode(s.Row, s.Col);              
            if ((person.person_bookedseats.Count() < person.max_seats)&&!s.BookStatus&& (person.person_bookedseats[0] == seatnode.Next?.Seat || person.person_bookedseats[0] == seatnode.Prev?.Seat || person.person_bookedseats[^1] == seatnode.Next?.Seat || person.person_bookedseats[^1] == seatnode.Prev?.Seat))
            {
                valid_objectclicked(s, person, sender, groupBox, userac, undo, redo);
            }
            else if (person.person_bookedseats[0] == s|| person.person_bookedseats[^1]==s)
            {
                s.BookStatus=false;
                ((Label)sender).BackColor = Color.AliceBlue;
                s.person = null;
                person.person_bookedseats.Remove(s);
            }
            else
            {
                MessageBox.Show("Only adjacent seats can be booked.");
            }         
        }

        //if a seat is clicked
        public void labelSeat_Click(object sender, EventArgs e, Seat s, Person person, SeatDoubleLinkedList aseatlist, Form aform, Button man_button, RadioButton enable_radio, RadioButton disable_radio, userActions userac, Button undo, Button redo, GroupBox groupBox)
        {
            if(man_button!=null&& man_button.Text == "disable editor")
            {
                if (enable_radio.Checked)
                {
                    s.CanBook = true;
                    ((Label)sender).BackColor= Color.AliceBlue;
                    Action labelseatclick = () => labelSeat_Click(sender, e, s, person, aseatlist, aform, man_button, enable_radio, disable_radio, userac, undo, redo, groupBox);
                    userac.addAction(labelseatclick, undo, redo);
                }
                else if(disable_radio.Checked)
                {
                    s.CanBook = false;
                    ((Label)sender).BackColor = Color.Plum;
                    person_with_seat(s);
                    Action labelseatclick = () => labelSeat_Click(sender, e, s, person, aseatlist, aform, man_button, enable_radio, disable_radio, userac, undo, redo, groupBox);
                    userac.addAction(labelseatclick, undo, redo);
                }
            }
            else if (person==null||person.max_seats == 0)
            {
                MessageBox.Show("You need to select a person and enter max seats before you can book.");
            }
            else if (person.person_bookedseats.Count==0)
            {
                if (aform is Form3)
                {
                    if (s.form3_adj == null)
                    {
                        valid_objectclicked(s, person, sender, groupBox, userac, undo, redo, aseatlist.GetNode(s.Row, s.Col), aform);
                    }
                }
                else
                {
                    valid_objectclicked(s, person, sender, groupBox, userac, undo, redo, aseatlist.GetNode(s.Row, s.Col), aform);
                }
            }
            else if (aform is Form1||aform is Form2)
            {
                normalmode(person, s, sender, aseatlist, groupBox, userac, undo, redo);
            }
            else if(aform is Form3)
            {
                smartmode(person, s, sender, aseatlist, aform, groupBox, userac, undo, redo);
            }
        }

        //function to enable all seats
        public void enable_all(SeatDoubleLinkedList aseatlist)
        {
            foreach (Node node in aseatlist)
            {
                node.Seat.CanBook = true;
                node.Seat.label.Enabled = true;
                if (node.Seat.label.BackColor == Color.Plum)
                {
                    node.Seat.label.BackColor = Color.AliceBlue;
                }
            }
        }

        //function to disable all seats
        public void disable_all(SeatDoubleLinkedList aseatlist)
        {
            foreach (Node node in aseatlist)
            {
                node.Seat.CanBook = false;
                node.Seat.label.BackColor = Color.Plum;
                person_with_seat(node.Seat);
            }
        }
    }

}
