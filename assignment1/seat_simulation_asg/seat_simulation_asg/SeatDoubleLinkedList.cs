using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seat_simulation_asg
{
    [Serializable]
    internal class SeatDoubleLinkedList: IEnumerable<Node>
    {
        public Node[,] seats;
        public int numRows { get; set; }
        public int numCols { get; set; }
        public SeatDoubleLinkedList(int numRows, int numCols)
        {
            this.numRows = numRows;
            this.numCols = numCols;
            seats = new Node[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for(int j = 0; j < numCols; j++)
                {
                    seats[i,j]= new Node(new Seat(i,j));
                }
            }

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (j != 0)
                    {
                        seats[i, j].Prev = seats[i, j - 1];
                    }
                    if (j!= numCols-1)
                    {
                        seats[i, j].Next = seats[i, j + 1];
                    }
                    if (i != 0)
                    {
                        seats[i, j].Up = seats[i - 1, j];
                    }
                    if (i != numRows - 1)
                    {
                        seats[i, j].Down = seats[i + 1, j];
                    }
                    
                    
                }
            }

        }

        public Seat GetSeat(int row, int col)
        {
            if (row<0 || col < 0|| row >= numRows || col >= numCols)
            {
                return null;
            }
            else
            {
                return seats[row,col].Seat;
            }
        }

        public Node GetNode(int row, int col)
        {
            if (row < 0 || col < 0 || row >= numRows || col >= numCols)
            {
                return null;
            }
            else
            {
                return seats[row, col];
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    yield return seats[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
