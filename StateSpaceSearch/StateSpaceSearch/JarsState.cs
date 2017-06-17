using System;
using System.Collections.Generic;
using System.Linq;

namespace StateSpaceSearch
{
    public class JarsState
    {
        public JarsState(int g3, int g8, int g12)
        {
            Amount = new[] {g3, g8, g12};
        }

        public static bool IsGoal(JarsState currentState)
        {
            var amount = currentState.Amount;

            //return (amount[0] + amount[1] + amount[2] == 1);
            return amount[0] == 1 || amount[1] == 1 || amount[2] == 1;
        }

        public static IEnumerable<JarsState> GetNextStates(JarsState currentState)
        {
            var amount = currentState.Amount;

            IList<JarsState> states = new List<JarsState>();

            for (var jar = 0; jar < 3; jar++)
            {
                if (amount[jar] < JarCapacity.Capacity[jar]) states.Add(StateAction.Fill(jar, currentState));

                if (amount[jar] <= 0) continue;

                states.Add(StateAction.EmptyJar(jar, currentState));

                for (var to = 0; to < 3; to++)
                {
                    if (jar == to || amount[to] == JarCapacity.Capacity[to]) continue;

                    states.Add(StateAction.EmptyFromTo(jar, to, currentState));
                }
            }

            return states;
        }

        public static void PrintSequence(JarsState state)
        {
            IList<string> states = new List<string>();
            while (state.Parent != null)
            {
                states.Add(state.ToString());
                state = state.Parent;
            }

            foreach (var state1 in states.Reverse())
            {
                Console.WriteLine(state1);
            }
        }

        public JarsState Clone()
        {
            return new JarsState(Amount[0], Amount[1], Amount[2]);
        }

        public readonly int[] Amount;

        public JarsState Parent;

        public override string ToString()
        {
            return string.Format("{{{0} {1} {2}}}", Amount[0], Amount[1], Amount[2]);
        }
    }
}
