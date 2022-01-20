using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Windows.Media;

namespace Game
{
    public class BombGame
    {
        private Board hiddenBoard;
        private PlayerBoard pBoard;
        private BoardOfSuspects suspects;
        private int numOfBombs;
        bool stop = false;
        public Board HiddenBoard { get => hiddenBoard; set => hiddenBoard = value; }
        public PlayerBoard PBoard { get => pBoard; set => pBoard = value; }
        public BoardOfSuspects Suspects { get => suspects; set => suspects = value; }
        public int NumOfBombs { get => numOfBombs; set => numOfBombs = value; }

        public BombGame(int rows, int columns)
        {
            Random rnd = new Random();
            NumOfBombs = rnd.Next(1, rows * columns / 4);
            this.HiddenBoard = new Board(rows, columns, numOfBombs);
            this.PBoard = new PlayerBoard(rows, columns);
            this.Suspects = new BoardOfSuspects(rows, columns);

        }
        public void ShowAllBombs( Board board, Grid g)
        {
            for (int i = 0; i < board.RowLengh; i++)
            {
                for (int j = 0; j < board.ColLengh; j++)
                {
                    Button b = g.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == i && Grid.GetColumn(e) == j) as Button;
                    b.IsEnabled = false;
                    b.Background = new SolidColorBrush(Colors.Fuchsia);
                    
                    if (board.GetData(i, j) == 9)
                    {
                            b.Background = new SolidColorBrush(Colors.BlueViolet);
                            b.Content = board.GetData(i, j).ToString();
                            
                           
                    }
                }
            }
        }
        public bool CheckingTheSelection(int r, int c, Board board, PlayerBoard gamePlayer,Grid g)
        {
            if (board.GetData(r, c) == 9)
            {
                ShowAllBombs( board, g);

                MessageBox.Show("loss :(");
                stop = true;
                return false;
            }
            else if (board.GetData(r, c) > 0)
            {
                //https://stackoverflow.com/questions/1511722/how-to-programmatically-access-control-in-wpf-grid-by-row-and-column-index
                Button b= g.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == r && Grid.GetColumn(e) == c) as Button;
               
                b.Background = Brushes.Blue;
                b.Content = board.GetData(r, c).ToString();
                b.IsEnabled = false;

                gamePlayer.SetData(r, c, board);
                return true;
            }
            else if (gamePlayer.GetData(r, c) == -1)
            {
                Button b = g.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == r && Grid.GetColumn(e) == c) as Button;
                b.Background = Brushes.Blue;
                b.Content = board.GetData(r, c).ToString();
                b.IsEnabled = false;

                if (r > 0 && r < gamePlayer.RowLengh - 1 && c > 0 && c < gamePlayer.ColLengh - 1)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r - 1, c - 1, board, gamePlayer,g);
                    CheckingTheSelection(r - 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r - 1, c + 1, board, gamePlayer, g);
                    CheckingTheSelection(r, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r, c + 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c + 1, board, gamePlayer, g);
                }
                else if (r == 0 && c > 0 && c < gamePlayer.ColLengh - 1)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r, c + 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c + 1, board, gamePlayer, g);
                }
                else if (r > 0 && r < gamePlayer.RowLengh - 1 && c == 0)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r - 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r - 1, c + 1, board, gamePlayer, g);
                    CheckingTheSelection(r, c + 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c + 1, board, gamePlayer, g);
                }
                else if (r == gamePlayer.RowLengh - 1 && c > 0 && c < gamePlayer.ColLengh - 1)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r - 1, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r - 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r - 1, c + 1, board, gamePlayer, g);
                    CheckingTheSelection(r, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r, c + 1, board, gamePlayer, g);
                }
                else if (r > 0 && r < gamePlayer.RowLengh - 1 && c == gamePlayer.ColLengh - 1)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r - 1, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r - 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c, board, gamePlayer, g);
                }
                else if (r == 0 && c == 0)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r, c + 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c + 1, board, gamePlayer, g);
                }
                else if (r == gamePlayer.RowLengh - 1 && c == gamePlayer.ColLengh - 1)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r - 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r - 1, c - 1, board, gamePlayer, g);
                }
                else if (r == 0 && c == gamePlayer.ColLengh - 1)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c - 1, board, gamePlayer, g);
                    CheckingTheSelection(r + 1, c, board, gamePlayer, g);
                }
                else if (r == gamePlayer.RowLengh - 1 && c == 0)
                {
                    gamePlayer.SetData(r, c, board);
                    CheckingTheSelection(r - 1, c, board, gamePlayer, g);
                    CheckingTheSelection(r - 1, c + 1, board, gamePlayer, g);
                    CheckingTheSelection(r, c + 1, board, gamePlayer, g);
                }
                return true;
            }
            return true;
        }
        public void Play(int r,int c,Grid g)
        {    
            if (suspects.GetData(r, c) != -1)
            {
                if (!stop)
                    if (CheckingTheSelection(r, c, this.hiddenBoard, this.pBoard, g))

                        if (this.numOfBombs == pBoard.SumOfEmptySquares())
                        {
                            MessageBox.Show("Triumph :)");


                        }
            }




        }
       
    }
}
