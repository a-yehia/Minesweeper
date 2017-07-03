using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public static class BoardControls
    {
        public static void FillMines(ref int[][]BackBoard ,int NumOfMines)
        {
            Random rnd = new Random();
            int sizeOfBoard = BackBoard.GetLength(0);
            for (int i = 0; i < NumOfMines; i++)
            {
                int x = rnd.Next(sizeOfBoard);
                int y = rnd.Next(sizeOfBoard);
                BackBoard[x][y] = 999;
            }
        }

        public static void FillNumbers(ref int[][] BackBoard)
        {
            int sizeOfBoard = BackBoard.GetLength(0);
            for (int x = 0; x < sizeOfBoard; x++)
            {
                for (int y = 0; y < sizeOfBoard; y++)
                {
                    if(BackBoard[x][y]!=999)
                        BackBoard[x][y]= GetNumberOfNeighbourMines(BackBoard, x, y);
                    
                }
            }
        }
        private static int GetNumberOfNeighbourMines(int [][]Board , int x ,int y )
        {
            int boardSize = Board.GetLength(0);
            int NeighboursCount = 0;
            if (!isOut(x - 1, y - 1,boardSize))
            {
                if (Board[x - 1][ y - 1] == 999)
                { NeighboursCount++; }
            }
            if (!isOut(x, y - 1, boardSize))
            {
                if (Board[x][y - 1] == 999)
                { NeighboursCount++; }
            }
            if (!isOut(x + 1, y - 1, boardSize))
            {
                if (Board[x + 1][y - 1] == 999)
                { NeighboursCount++; }
            }
            if (!isOut(x + 1, y, boardSize))
            {
                if (Board[x + 1][y] == 999)
                { NeighboursCount++; }
            }
            if (!isOut(x + 1, y + 1, boardSize))
            {
                if (Board[x + 1][y + 1] == 999)
                { NeighboursCount++; }
            }
            if (!isOut(x , y + 1, boardSize))
            {
                if (Board[x][y + 1] == 999)
                { NeighboursCount++; }
            }
            if (!isOut(x -1, y + 1, boardSize))
            {
                if (Board[x - 1][y + 1] == 999)
                { NeighboursCount++; }
            }
            if (!isOut(x -1 , y , boardSize))
            {
                if (Board[x - 1][y ] == 999)
                { NeighboursCount++; }
            }
            return NeighboursCount;
        }
        public static bool isOut(int x, int y,int size)
        {
            if ((x < 0)||(x>=size))
                return true;
            if ((y < 0) || (y >= size))
                return true;

            return false;
        }


    }
}
