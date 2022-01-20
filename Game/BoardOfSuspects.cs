using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoardOfSuspects
    {
        private int[,] suspects;

        public int[,] Suspects { get => suspects; set => suspects = value; }
        public int GetData(int r, int c)
        {
            return this.Suspects[r, c];
        }
        public void SetData(int r, int c)
        {
            this.Suspects[r, c] = -1 ;
        }
        public BoardOfSuspects(int r, int c)
        {
            suspects = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    suspects[i, j]=0;
                }
            }
        }
    }
}
