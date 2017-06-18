using System;
using System.Collections.Generic;
using StateProblemCommons;

namespace SheepAndWolves
{
    public class SheepAndWolvesState : AbstractState, IState
    {
        public readonly StateSide Side1, Side2;

        public SheepAndWolvesState(StateSide side1, StateSide side2)
        {
            Side1 = side1;
            Side2 = side2;
        }

        public IState Parent { get; set; }

        public bool IsGoal()
        {
            return Side1.WolfCount == 3
                   && Side1.SheepCount == 3
                   && Side2.WolfCount == 0
                   && Side2.SheepCount == 0;
        }

        public IEnumerable<IState> GetNextStates()
        {
            var states = new List<SheepAndWolvesState>();

            int sheepCount, wolfCount;
            if (Side1.HasBoat)
            {
                sheepCount = Side1.SheepCount;
                wolfCount = Side1.WolfCount;
            }
            else
            {
                sheepCount = Side2.SheepCount;
                wolfCount = Side2.WolfCount;
            }

            for (var sheep = 0; sheep <= sheepCount; sheep++)
            for (var wolf = 0; wolf <= wolfCount; wolf++)
            {
                if (sheep + wolf > 2 || sheep + wolf <= 0) continue;
                var newState = StateAction.MoveBoat(sheep, wolf, this);
                if(newState == null) continue;
                states.Add(newState);
            }

            return states;
        }

        public override string ToString()
        {
            return
                $"{{{Side1.SheepCount} {Side1.WolfCount} {Side1.HasBoat} | {Side2.SheepCount} {Side2.WolfCount} {Side2.HasBoat}}}";
        }

        public static SheepAndWolvesState Clone(ref StateSide side1, ref StateSide side2)
        {
            return new SheepAndWolvesState(side1, side2);
        }
    }
}