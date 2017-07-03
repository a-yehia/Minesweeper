using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Minesweeper
{
    public static class ButtonControls
    {
        public static void ShowEmptyButton(ref List<List<Button>> but , int x,int y)
        {

            but[x][y].FlatStyle = FlatStyle.Flat;
            but[x][y].BackColor = Color.White;

        }
        public static void ShowNumberButton(ref List<List<Button>> but, int x, int y ,string numMines)
        {
            but[x][y].FlatStyle = FlatStyle.Flat;
            but[x][y].BackColor = Color.Gainsboro;
            but[x][y].Text = numMines;
            but[x][y].Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            if (int.Parse(numMines) == 1)
            {
                but[x][y].ForeColor = Color.DarkMagenta;
            }
            else if (int.Parse(numMines) == 2)
            { but[x][y].ForeColor = Color.Blue; }
            else if (int.Parse(numMines) == 3)
            { but[x][y].ForeColor = Color.Brown; }
            else if (int.Parse(numMines) == 4)
            { but[x][y].ForeColor = Color.DarkCyan; }
        }
        public static void ShowMine(ref List<List<Button>> but, int x, int y)
        {
            but[x][y].FlatStyle = FlatStyle.Flat;
            but[x][y].BackColor = Color.Red;
            but[x][y].BackgroundImageLayout = ImageLayout.Stretch;
            but[x][y].BackgroundImage = Image.FromFile("Mine.PNG");
        }

        public static void ShowALL(int[][] Board,ref List<List<Button>> buttons) // For DEV TEST and END GAME
        {
            int boardSize = Board.GetLength(0);
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if (Board[x][y] == 0)
                        ShowEmptyButton(ref buttons, x, y);
                    else if (Board[x][y] == 999)
                        ShowMine(ref buttons, x, y);
                    else
                        ShowNumberButton(ref buttons, x, y, Board[x][y].ToString());

                }
            }
        }

        public static bool isMine(int[][] board ,int x,int y)
        {
            if (board[x][y] == 999)
                return true;
            return false;
        }
        public static bool isEmpty(int[][] board, int x, int y)
        {
            if (board[x][y] == 0)
                return true;
            return false;
        }
        public static bool isNum(int[][] board, int x, int y)
        {
            if ((!isEmpty(board,x,y))&&(!isMine(board,x,y)))
                return true;
            return false;
        }
        public static bool openMe(List<List<Button>> but, int[][] board, int x, int y)
        {
            if ((!BoardControls.isOut(x, y, board.GetLength(0))&&(but[x][y].BackColor != Color.White) && (!isMine(board, x, y)) ))
            {
                return true;
            }
            return false;
        }
        private static void showNeighbourEmpties(ref List<List<Button>> but, int[][] board, int x, int y)
        {
            if (openMe(but, board, x - 1, y - 1))
            {
                if (board[x - 1][y - 1] == 0)
                { 
                    ShowEmptyButton(ref but, x - 1, y - 1);
                    showNeighbourEmpties(ref but, board, x - 1, y - 1);
                }
                else
                    ShowNumberButton(ref but, x - 1, y - 1, board[x - 1][y - 1].ToString());
               
            }
            if (openMe(but, board, x  , y - 1))
            {
                if (board[x][y - 1] == 0)
                {
                    ShowEmptyButton(ref but, x, y - 1);
                    showNeighbourEmpties(ref but, board, x, y - 1);
                }
                else
                    ShowNumberButton(ref but, x, y - 1, board[x][y - 1].ToString());
                
            }
            if (openMe(but, board, x + 1, y - 1))
            {
                if (board[x + 1][y - 1] == 0)
                {
                    ShowEmptyButton(ref but, x + 1, y - 1);
                    showNeighbourEmpties(ref but, board, x + 1, y - 1);
                }
                else
                    ShowNumberButton(ref but, x + 1, y - 1, board[x + 1][y - 1].ToString());
                
            }
            if (openMe(but, board, x + 1, y  ))
            {
                if (board[x + 1][y] == 0)
                {
                    ShowEmptyButton(ref but, x + 1, y);
                    showNeighbourEmpties(ref but, board, x + 1, y);
                }
                else
                    ShowNumberButton(ref but, x + 1, y, board[x + 1][y].ToString());
                
            }
            if (openMe(but, board, x + 1, y + 1))
            {
                if (board[x + 1][y + 1] == 0)
                {
                    ShowEmptyButton(ref but, x + 1, y + 1);
                    showNeighbourEmpties(ref but, board, x + 1, y + 1);
                }
                else
                    ShowNumberButton(ref but, x + 1, y + 1, board[x + 1][y + 1].ToString());
               
            }
            if (openMe(but, board, x  , y + 1))
            {
                if (board[x][y + 1] == 0)
                { 
                    ShowEmptyButton(ref but, x, y + 1);
                    showNeighbourEmpties(ref but, board, x, y + 1);
                }
                else
                    ShowNumberButton(ref but, x, y + 1, board[x][y + 1].ToString());
                
            }
            if (openMe(but, board, x - 1, y + 1))
            {
                if (board[x - 1][y + 1] == 0)
                {
                    ShowEmptyButton(ref but, x - 1, y + 1);
                    showNeighbourEmpties(ref but, board, x - 1, y + 1);
                }
                else
                    ShowNumberButton(ref but, x - 1, y + 1, board[x - 1][y + 1].ToString());
            }
            if (openMe(but, board, x - 1, y ))
            {
                if (board[x - 1][y] == 0)
                {
                    ShowEmptyButton(ref but, x - 1, y);
                    showNeighbourEmpties(ref but, board, x - 1, y);
                }
                else
                    ShowNumberButton(ref but, x - 1, y, board[x - 1][y].ToString());
            }
            
        }

        private static bool Win( List<List<Button>> but, int[][] board)
        {
            int boardSize = board.GetLength(0);
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if (isNum(board, x, y)&&(but[x][y].Font.Bold==false))
                    {
                        return false;
                    }
                }
            }
            return true;        
        }

        public static void ButtonClick(ref List<List<Button>> but,int [][]board, int x, int y)
        {
            if (isEmpty(board, x, y))
            {
                if (but[x][y].BackColor != Color.White)
                {
                    ShowEmptyButton(ref but, x, y);
                }
                showNeighbourEmpties(ref but, board, x, y);
                if (Win(but, board))
                { MessageBox.Show("You WIN ! :)"); }
            }
            else if (isNum(board, x, y))
            {
                if (but[x][y].BackColor != Color.Gainsboro)
                {
                    ShowNumberButton(ref but, x, y, board[x][y].ToString());
                }
                if (Win(but, board))
                { MessageBox.Show("You WIN ! :)"); }
            }
            else
            {
                ShowALL(board, ref but);
                MessageBox.Show("Boom  !  :(");
            }

        }

    }
}
