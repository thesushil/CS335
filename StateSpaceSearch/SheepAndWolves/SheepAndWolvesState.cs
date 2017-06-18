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
            return Side1.WolvesCount == 0
                   && Side1.SheepCount == 0
                   && Side2.WolvesCount == 3
                   && Side2.SheepCount == 3;
        }

        public IEnumerable<IState> GetNextStates()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return
                $@"{{Sheep:{Side1.SheepCount} Wolves:{Side1.WolvesCount} HasBoat:{Side1.HasBoat}
                    | Sheep:{Side2.SheepCount} Wolves:{Side2.WolvesCount} HasBoat{Side2.HasBoat}}}";
        }

        public static SheepAndWolvesState Clone(ref StateSide side1, ref StateSide side2)
        {
            return new SheepAndWolvesState(side1, side2);
        }
    }
}