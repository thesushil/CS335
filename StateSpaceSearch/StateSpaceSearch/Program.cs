using System;

namespace StateSpaceSearch
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var initialState = new JarsState(0, 0, 0);

            var breadthFirstSolution = SearchState.Search(initialState, frontier => frontier[0]);
            foreach (var solutionState in breadthFirstSolution)
            {
                Console.WriteLine("Hurray !!!");
                JarsState.PrintSequence(solutionState);
            }

            var depthFirstSolution = SearchState.Search(initialState, frontier => frontier[frontier.Count - 1]);
            foreach (var solutionState in depthFirstSolution)
            {
                Console.WriteLine("Hurray !!!");
                JarsState.PrintSequence(solutionState);
            }

            Console.WriteLine("Press any key to exit ...");
            //Console.Read();
        }
    }
}