using System;
using System.Collections.Generic;
using StateProblemCommons;

namespace Slide8Puzzle
{
    public class PuzzleState : AbstractState, IState
    {
        public int[][] Board { get; set; }

        public bool IsGoal()
        {
            var rowMax = Board.GetLength(0) - 1;
            var colMax = Board.GetLength(1) - 1;
            var numInBoard = 0;
            for (var i = 0; i <= rowMax; i++)
            for (var j = 0; j <= colMax; j++)
                if (Board[i][j] != ++numInBoard && i != rowMax && j != colMax) return false;
            return true;
        }

        public IEnumerable<IState> GetNextStates()
        {
            // var emptySlot = FindEmptySlot();
            // emptySlot
            throw new NotImplementedException();
        }

        //private (int, int) FindEmptySlot()
        //{
        //    for(int i = 0; i <= Board.GetLength(0); i++)
        //    for (int j = 0; j <= Board.GetLength(1); j++)
        //    {
        //        if (Board[i][j] == 0) return (i, j);
        //    }
        //}
    }
}
