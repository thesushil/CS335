using System;
using System.Collections.Generic;
using System.Linq;

namespace StateProblemCommons
{
    public static class SearchState
    {
        public static IEnumerable<IState> Search(IState initialState
            , Func<IList<IState>, IState> selectStateToOpen)
        {
            IList<IState> solutionStates = new List<IState>();
            IList<IState> frontier = new List<IState>();
            IList<IState> visited = new List<IState>();

            frontier.Add(initialState);

            while (frontier.Any())
            {
                var state = selectStateToOpen(frontier);
                if (state.IsGoal())
                {
                    solutionStates.Add(state);
                    frontier.Remove(state);
                    continue;
                }

                visited.Add(state);
                frontier.Remove(state);

                foreach (var nextState in state.GetNextStates())
                    if (!frontier.Contains(nextState) && !visited.Contains(nextState))
                        frontier.Add(nextState);
            }
            return solutionStates;
        }
    }
}