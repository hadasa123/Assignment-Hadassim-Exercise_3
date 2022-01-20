using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerBoard
    {
        private int[,] pBoard;
        public PlayerBoard(int r, int c)
        {
            this.pBoard = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    this.pBoard[i, j] = -1;
                }
            }
        }

        public int[,] PBoard { get => pBoard; set => pBoard = value; }

        public int GetData(int r, int c)
        {
            return this.PBoard[r, c];
        }
        public void SetData(int r, int c, Board board)
        {
             this.PBoard[r, c]= board.GetData(r, c); 
        }
        public int RowLengh { get => this.PBoard.GetLength(0); }
        public int ColLengh { get => this.PBoard.GetLength(1); }
        public void Draw()
        {
            for (int i = 0; i < RowLengh; i++)
            {
                for (int j = 0; j < ColLengh; j++)
                {
                    Console.Write(GetData(i, j));
                    Console.Write(" | ");

                }
                Console.WriteLine();
                for (int j = 0; j < ColLengh; j++)
                {
                    Console.Write("----");

                }
                Console.WriteLine();
            }
        }
        public int SumOfEmptySquares()
        {
            int acount = 0;
            for (int i = 0; i < RowLengh; i++)
                for (int j = 0; j < ColLengh; j++)
                    if (this.pBoard[i,j]==-1)
                        acount++;
            return acount;
        }
       

    }
}
