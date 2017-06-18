using System;
using System.Collections.Generic;
using System.Linq;

namespace StateProblemCommons
{
    public class AbstractState
    {
        public static string BuildSequence(IState state)
        {
            IList<string> states = new List<string>();
            while (state.Parent != null)
            {
                states.Add(state.ToString());
                state = state.Parent;
            }

            return string.Join(Environment.NewLine, states.Reverse());
        }

        public bool Equals(IState other)
        {
            return ToString().Equals(other.ToString());
        }
    }
}