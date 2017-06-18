using System.Collections.Generic;
using StateProblemCommons;

namespace SheepAndWolves
{
    public static class StateAction
    {
        public static SheepAndWolvesState MoveBoat(int sheepCount, int wolvesCount, SheepAndWolvesState currentState)
        {
            var newSide1 = currentState.Side1;
            var newSide2 = currentState.Side2;

            var newState = SheepAndWolvesState.Clone(ref newSide1, ref newSide2);
            newState.Parent = currentState;
            return newState;
        }
    }
}