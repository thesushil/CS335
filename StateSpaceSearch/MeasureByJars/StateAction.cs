namespace MeasureByJars
{
    public static class StateAction
    {
        public static JarsState Fill(int jar, JarsState currentState)
        {
            var newState = currentState.Clone();
            newState.Amount[jar] = JarsState.Capacity[jar];
            newState.Parent = currentState;
            return newState;
        }

        public static JarsState EmptyJar(int jar, JarsState currentState)
        {
            var newState = currentState.Clone();
            newState.Amount[jar] = 0;
            newState.Parent = currentState;
            return newState;
        }

        public static JarsState EmptyFromTo(int from, int to, JarsState currentState)
        {
            var newState = currentState.Clone();

            var spaceLeft = JarsState.Capacity[to] - currentState.Amount[to];
            var availableToPour = currentState.Amount[from];
            var pourAmount = (availableToPour < spaceLeft) ? availableToPour : spaceLeft;

            newState.Amount[to] += pourAmount;
            newState.Amount[from] -= pourAmount;
            newState.Parent = currentState;

            return newState;
        }

    }
}
