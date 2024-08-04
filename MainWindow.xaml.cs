using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrameTikTakToe_2_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board board = new Board();
        private BoardCell[] boardCell = new BoardCell[9];

        private int turn = 0;
        private bool boardExists = false;
        public MainWindow()
        {
            InitializeComponent();

            Left = Screen.PrimaryScreen.Bounds.Width - (225 + (Screen.PrimaryScreen.Bounds.Width / 2));
            Top = Screen.PrimaryScreen.Bounds.Height - (100 + (Screen.PrimaryScreen.Bounds.Height / 2))-400;
            LSplashText.Content = "Player: " + board.player[(turn % 2) + 1] + " is next.";
            drawBoard();
        }
        void drawBoard()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!boardExists)
                    {
                        boardCell[(i+1)*(j+1)+j*(2-i)-1] = new BoardCell(i, j, board.GetValueAsString(i, j));     //spawns a new board Cell at the given row and collumn
                    }
                    else
                    {
                        boardCell[(i + 1) * (j + 1) + j * (2 - i) - 1].setContent(board.GetValueAsString(i, j));
                    }
                    
                }
                

            }
            if (!boardExists) { boardExists = true; }
        }

        public void takeTurn(int index, int row, int column)
        {
            LSplashText.Content = "Player: " + board.player[((turn + 1) % 2) + 1] + " is next.";
            if (board.GetValue(row, column) == 0)
            {
                board.SetCell(row, column, turn);
                drawBoard();
                if (board.GetHasWon(turn))
                {
                    LSplashText.Content = ("Game Over. Player: "+ board.player[(turn%2)+1]+" Has Won!");
                    for (int i = 0; i < 9; i++)
                    {
                        if (turn%2 == 0)
                        {
                            boardCell[i].setColor(107, 150, 219);
                        }
                        else
                        {
                            boardCell[i].setColor(250, 159, 67);
                        }  
                    }
                }
                turn++;
            }
            else
            {
                LSplashText.Content = "this square is already taken";

            }
            
        }

    }
}