using System;

namespace BoardLogic01
{
    public class Board
    {
        public int[] Grid { get; set; }
        
        public Board() 
        {
            // initialize the Grid
            Grid = new int[9];
            for (int i = 0; i < 9; i++)     Grid[i] = 0;
            
        }


        // return 0 if nobody win, return number player win, return -1 if no win and full square
        public int Check4Winner()
        {
            // row 1
            if (Grid[0] == Grid[1] && Grid[1] == Grid[2] && Grid[0] != 0)
            {
                return Grid[0];
            }
            // row 2
            if (Grid[3] == Grid[4] && Grid[4] == Grid[5] && Grid[3] != 0)
            {
                return Grid[3];
            }
            // row 3
            if (Grid[6] == Grid[7] && Grid[7] == Grid[8] && Grid[6] != 0)
            {
                return Grid[6];
            }
            // col 1
            if (Grid[0] == Grid[3] && Grid[3] == Grid[6] && Grid[0] != 0)
            {
                return Grid[0];
            }
            // col 2
            if (Grid[1] == Grid[4] && Grid[4] == Grid[7] && Grid[1] != 0)
            {
                return Grid[1];
            }
            // col 3
            if (Grid[2] == Grid[5] && Grid[5] == Grid[8] && Grid[2] != 0)
            {
                return Grid[2];
            }
            // dia 1
            if (Grid[0] == Grid[4] && Grid[4] == Grid[8] && Grid[0] != 0)
            {
                return Grid[0];
            }
            // dia 2
            if (Grid[2] == Grid[4] && Grid[4] == Grid[6] && Grid[2] != 0)
            {
                return Grid[2];
            }


            // more game to play confirm
            // 
            //if (ConfirmGame() == 0)
            //    return -1;
            return 0;
        }

        public bool IsBoardFull()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Grid[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}