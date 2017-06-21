using System.Collections.Generic;
using StateProblemCommons;

namespace MeasureByJars
{
    public class JarsState : AbstractState, IState
    {
        public static readonly int[] Capacity = {3, 8, 12};

        public readonly int[] Amount;

        public JarsState(int jar1, int jar2, int jar3)
        {
            Amount = new[] {jar1, jar2, jar3};
        }

        public bool IsGoal()
        {
            //var amount = currentState.Amount;
            //return (Amount[0] + Amount[1] + Amount[2] == 1);
            return Amount[0] == 1 || Amount[1] == 1 || Amount[2] == 1;
        }

        public IEnumerable<IState> GetNextStates()
        {
            IList<IState> nextStates = new List<IState>();

            for (var jar = 0; jar < 3; jar++)
            {
                if (Amount[jar] < Capacity[jar]) nextStates.Add(StateAction.Fill(jar, this));

                if (Amount[jar] <= 0) continue;

                nextStates.Add(StateAction.EmptyJar(jar, this));

                for (var to = 0; to < 3; to++)
                {
                    if (jar == to || Amount[to] == Capacity[to]) continue;

                    nextStates.Add(StateAction.EmptyFromTo(jar, to, this));
                }
            }

            return nextStates;
        }

        public JarsState Clone()
        {
            return new JarsState(Amount[0], Amount[1], Amount[2]);
        }

        public override string ToString()
        {
            return $"{{{Amount[0]} {Amount[1]} {Amount[2]}}}";
        }
    }
}