using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seat_simulation_asg
{
    [Serializable]
    internal class Node
    {
        private Node _prev;
        private Seat _seat;
        private Node _next;
        private Node _up;
        private Node _down;
        public Node(Seat pSeat)
        {
            _seat = pSeat;
            _prev = null;
            _next = null;
            _up = null;
            _down = null;
        }
        public Seat Seat
        {
            get { return _seat; }
            set { _seat = value; }
        }
        public Node Next
        {
            get { return _next; }
            set { _next = value; }
        }
        public Node Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }
        public Node Up
        {
            get { return _up; }
            set { _up = value; }
        }
        public Node Down 
        {
            get { return _down; }
            set { _down = value; }
        }
    }
}
