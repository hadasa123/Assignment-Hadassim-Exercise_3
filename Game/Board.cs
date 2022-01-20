using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Board
    {

        private int[,] gameData;

        public int[,] GameData { get => gameData; }

        
        public int GetData(int r, int c)
        {
            return this.GameData[r, c];
        }
        public int RowLengh { get => this.gameData.GetLength(0); }
        public int ColLengh { get => this.gameData.GetLength(1); }
        //private int[,] visibleBoard;
        //private int[] randomBomb;


        //public int[,] VisibleBoard { get => visibleBoard; set => visibleBoard = value; }
        //public int[] RandomBomb { get => randomBomb; set => randomBomb = value; }
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
        public Board(int rows, int columns, int B)
        {
            this.gameData = new int[rows, columns];
            int[] randomBomb = new int[rows * columns];
            for (int i = 0; i < rows * columns; i++)
                randomBomb[i] = i;
            //row =5; column=8;
            int endOfRandom = rows * columns - 1;

            for (int i = 0; i < B; i++)
            {
                Random rnd = new Random();
                int SquareWithBomb = rnd.Next(0, endOfRandom);
                int row = randomBomb[SquareWithBomb] / columns;
                int column = randomBomb[SquareWithBomb] % columns;
                //9=bomb
                gameData[row, column] = 9;
                if (row != 0)
                {
                    //(i-1,j-1)
                    if (column != 0)
                        if (gameData[row - 1, column - 1] != 9)
                        {
                            gameData[row - 1, column - 1] += 1;
                        }

                    //(i-1,j)
                    if (gameData[row - 1, column] != 9)
                    {
                        gameData[row - 1, column] += 1;
                    }

                    //(i-1, j+1)
                    if (column != columns - 1)
                        if (gameData[row - 1, column + 1] != 9)
                        {
                            gameData[row - 1, column + 1] += 1;
                        }

                }
                //(i,j-1)
                if (column != 0)
                    if (gameData[row, column - 1] != 9)
                    {
                        gameData[row, column - 1] += 1;
                    }

                //(i,j+1)
                if (column != columns - 1)
                    if (gameData[row, column + 1] != 9)
                    {
                        gameData[row, column + 1] += 1;
                    }

                if (row != rows - 1)
                {
                    //(i+1,j-1)
                    if (column != 0)
                        if (gameData[row + 1, column - 1] != 9)
                        {
                            gameData[row + 1, column - 1] += 1;
                        }

                    //(i+1,j)
                    if (gameData[row + 1, column] != 9)
                    {
                        gameData[row + 1, column] += 1;
                    }

                    //(i+1, j+1)
                    if (column != columns - 1)
                        if (gameData[row + 1, column + 1] != 9)
                        {
                            gameData[row + 1, column + 1] += 1;
                        }

                }

                randomBomb[SquareWithBomb] = randomBomb[endOfRandom];
                endOfRandom--;
            }
        
        }

    }


}

