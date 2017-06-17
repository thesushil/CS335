using StateSpaceSearch.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StateSpaceSearch
{
    public static class SearchState
    {
        public static IEnumerable<JarsState> Search(JarsState initialState, Func<IList<JarsState>, JarsState> selectStateToOpen)
        {
            IList<JarsState> solutionStates = new List<JarsState>();
            IList<JarsState> frontier = new List<JarsState>();
            IList<JarsState> visited = new List<JarsState>();

            frontier.Add(initialState);

            while (frontier.Any())
            {
                var state = selectStateToOpen(frontier);
                if (JarsState.IsGoal(state))
                {                    
                    solutionStates.Add(state);
                    frontier.Remove(state);
                    continue;
                }

                visited.Add(state);
                frontier.Remove(state);

                var nextStates = JarsState.GetNextStates(state);
                foreach (var nextState in nextStates)
                {
                    if (!frontier.ContainsState(nextState) && !visited.ContainsState(nextState))
                        frontier.Add(nextState);
                }
            }
            return solutionStates;
        }

        
    }
}