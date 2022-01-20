using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Game;
namespace WpfGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BombGame bombGame;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void StartGame(object sender, RoutedEventArgs e)
        {
            int rows = int.Parse(this.rows.Text);
            int cols = int.Parse(this.cols.Text);
            bombGame = new BombGame(rows, cols);
            BuildDynamicGameBoard(rows, cols);
           
        }
        public void BuildDynamicGameBoard(int r, int c)
        {
            g.HorizontalAlignment = HorizontalAlignment.Center;
            g.VerticalAlignment = VerticalAlignment.Center;
            g.ShowGridLines = true;
            g.Background = new SolidColorBrush(Colors.LightBlue);
            ColumnDefinition gridCol;
            for (int i = 0; i < c; i++)
            {
                gridCol = new ColumnDefinition();
                g.ColumnDefinitions.Add(gridCol);
            }
            RowDefinition gridRow;
            for (int i = 0; i < r; i++)
            {
                gridRow = new RowDefinition();
                g.RowDefinitions.Add(gridRow);
            }
            Button b;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    b = new Button();
                    b.Width = 45;
                    b.Height = 45;
                    b.Foreground = new SolidColorBrush(Colors.Red);
                    b.Click += B_Click;
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    g.Children.Add(b);
                }
            }
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            var element = (UIElement)e.Source;
            int c = Grid.GetColumn(element);
            int r = Grid.GetRow(element);
            Button b = element as Button;
            b.Background = Brushes.Fuchsia;
            b.IsEnabled = false;
            bombGame.Play(r, c,g);


        }
    }
}
