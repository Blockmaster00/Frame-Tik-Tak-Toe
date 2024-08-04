using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameTikTakToe_2_
{
    class Board
    {
        private int[,] board = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        public string[] player = { " ", "X", "O" };
        public Board()
        {

        }

        public void SetCell(int row, int column, int turn)
        {
            board[row, column] = (turn%2)+1;
        }

        public int[,] GetBoard()
        {
            return board;
        }
        public int GetValue(int row, int column)
        {
            return board[row, column];
        }

        public string GetValueAsString(int row, int column)
        {
            return player[board[row, column]];
        }

        public bool GetHasWon(int turn)
        {
            bool winState = false;

            //HORIZONTAL
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == (turn % 2) + 1 && board[i, 1] == (turn % 2) + 1 && board[i, 2] == (turn % 2) + 1)
                {
                    winState = true;
                }
            }
            //VERTICAL
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == (turn % 2) + 1 && board[1, i] == (turn % 2) + 1 && board[2, i] == (turn % 2) + 1)
                {
                    winState = true;
                }
            }
            //DIAGONAL
            if (board[0, 0] == (turn % 2) + 1 && board[1, 1] == (turn % 2) + 1 && board[2, 2] == (turn % 2) + 1)
            {
                winState = true;
            }
            if (board[0, 2] == (turn % 2) + 1 && board[1, 1] == (turn % 2) + 1 && board[2, 0] == (turn % 2) + 1)
            {
                winState = true;
            }

            return winState;
        }
    }
}
