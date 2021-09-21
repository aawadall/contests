namespace sep20
{
    public class Solution1 : ISolution
    {
        public string Tictactoe(int[][] moves)
        {
            // given a list of moves, find who won

            // create a 3x3 board
            int[,] board = new int[3, 3];


            // iterate through the moves
            int currentPlayer = 1;

            foreach (int[] move in moves)   // move is an array of 2 ints
            {
                board[move[0], move[1]] = currentPlayer;
                currentPlayer *= -1;
            }

            // check for a winner
            int[] configuration = new int[8]; // 8 possible configurations 

            bool[] completed = new bool[] {
                true, true, true, true, true, true, true, true
            }; // check if configuration is completed 

            for (int i = 0; i < 3; i++)
            {
                // check rows
                configuration[0] += board[i, 0];
                completed[0] &= board[i, 0] != 0;

                configuration[1] += board[i, 1];
                completed[1] &= board[i, 1] != 0;

                configuration[2] += board[i, 2];
                completed[2] &= board[i, 2] != 0;

                // check columns
                configuration[3] += board[0, i];
                completed[3] &= board[0, i] != 0;

                configuration[4] += board[1, i];
                completed[4] &= board[1, i] != 0;

                configuration[5] += board[2, i];
                completed[5] &= board[2, i] != 0;

                // check diagonals
                configuration[6] += board[i, i];
                completed[6] &= board[i, i] != 0;

                configuration[7] += board[i, 2 - i];
                completed[7] &= board[i, 2 - i] != 0;
            }


            // check for a winner
            bool completedAll = true;
            for (int i = 0; i < 8; i++)
            {
                completedAll &= completed[i];
                if (configuration[i] == 3)
                {
                    return "A";
                }
                else if (configuration[i] == -3)
                {
                    return "B";
                }
            }
            return completedAll ? "Draw" : "Pending";
        }
    }
}
