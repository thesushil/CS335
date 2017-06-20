using System.Collections.Generic;
using StateProblemCommons;

namespace SheepAndWolves
{
    public static class StateAction
    {
        public static SheepAndWolvesState MoveBoat(int sheepCount, int wolvesCount,
            SheepAndWolvesState currentState)
        {
            var side1 = currentState.Side1;
            var side2 = currentState.Side2;

            if (side1.HasBoat)
            {
                side1.SheepCount -= sheepCount;
                side2.SheepCount += sheepCount;

                side1.WolfCount -= wolvesCount;
                side2.WolfCount += wolvesCount;

                side1.HasBoat = false;
                side2.HasBoat = true;
            }
            else
            {
                side2.SheepCount -= sheepCount;
                side1.SheepCount += sheepCount;

                side2.WolfCount -= wolvesCount;
                side1.WolfCount += wolvesCount;

                side1.HasBoat = true;
                side2.HasBoat = false;
            }

            if (side1.WolfCount > side1.SheepCount && side1.SheepCount > 0 
                || side2.WolfCount > side2.SheepCount && side2.SheepCount > 0) return null;

            var newState = SheepAndWolvesState.Clone(ref side1, ref side2);
            newState.Parent = currentState;
            return newState;
        }
    }
}