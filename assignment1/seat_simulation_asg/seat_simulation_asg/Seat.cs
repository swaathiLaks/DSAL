using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seat_simulation_asg
{
    [Serializable]
    internal class Seat
    {
        private bool _bookStatus = false;
        private bool _canBook = true;
        private int _row;
        private int _col;
        private int _isSpaceRow = 0;
        private int _isSpaceCol = 0;
        [NonSerialized]public Label label;
        public Person person;
        public Person form3_adj;
        public Seat(int row, int col)
        {
            _row = row;
            _col = col;
        }
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }
        public int Col
        {
            get { return _col; }
            set { _col = value; }
        }
        public int IsSpaceRow
        {
            get { return _isSpaceRow; }
            set { _isSpaceRow = value; }
        }
        public int IsSpaceCol
        {
            get { return _isSpaceCol; }
            set { _isSpaceCol = value; }
        }
        public bool CanBook
        {
            get { return _canBook; }
            set { _canBook = value; }
        }
        public bool BookStatus
        {
            get { return _bookStatus; }
            set { _bookStatus = value;}
        }
        public string ComputeSeatLabel()
        {
            return((char)(_row+65)).ToString()+(_col+1).ToString();
        }
        
    }
}
