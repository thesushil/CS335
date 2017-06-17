using System;
using System.Collections.Generic;
using System.Text;

namespace StateSpaceSearch
{
    public static class StateAction
    {
        public static JarsState Fill(int jar, JarsState currentState)
        {
            JarsState newState = currentState.Clone();
            newState.Amount[jar] = JarCapacity.Capacity[jar];
            newState.Parent = currentState;
            return newState;
        }

        public static JarsState EmptyJar(int jar, JarsState currentState)
        {
            JarsState newState = currentState.Clone();
            newState.Amount[jar] = 0;
            newState.Parent = currentState;
            return newState;
        }

        public static JarsState EmptyFromTo(int from, int to, JarsState currentState)
        {
            JarsState newState = currentState.Clone();

            int spaceLeft = JarCapacity.Capacity[to] - currentState.Amount[to];
            int availableToPour = currentState.Amount[from];
            int pourAmount = (availableToPour < spaceLeft) ? availableToPour : spaceLeft;

            newState.Amount[to] += pourAmount;
            newState.Amount[from] -= pourAmount;
            newState.Parent = currentState;

            return newState;
        }

    }
}
