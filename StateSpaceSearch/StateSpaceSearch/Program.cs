using System;
using MeasureByJars;
using SheepAndWolves;
using StateProblemCommons;

namespace StateSpaceSearch
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            SolveMeasureByJars();

            //SolveSheepAndWolves();

            Console.WriteLine("Press any key to exit ...");
            //Console.Read();
        }

        private static void SolveMeasureByJars()
        {
            var initialState = new JarsState(0, 0, 0);

            var breadthFirstSolution = SearchState.Search(initialState, frontier => frontier[0]);
            foreach (var solutionState in breadthFirstSolution)
            {
                Console.WriteLine("Hurray !!!");
                Console.WriteLine(AbstractState.BuildSequence(solutionState));
            }

            var depthFirstSolution = SearchState.Search(initialState, frontier => frontier[frontier.Count - 1]);
            foreach (var solutionState in depthFirstSolution)
            {
                Console.WriteLine("Hurray !!!");
                Console.WriteLine(AbstractState.BuildSequence(solutionState));
            }
        }

        private static void SolveSheepAndWolves()
        {
            var side1 = new StateSide(3, 3, true);
            var side2 = new StateSide(0, 0, false);
            var initialState = new SheepAndWolvesState(side1, side2);

            var breadthFirstSolution = SearchState.Search(initialState, frontier => frontier[0]);
            foreach (var solutionState in breadthFirstSolution)
            {
                Console.WriteLine("Hurray !!!");
                AbstractState.BuildSequence(solutionState);
            }

            var depthFirstSolution = SearchState.Search(initialState, frontier => frontier[frontier.Count - 1]);
            foreach (var solutionState in depthFirstSolution)
            {
                Console.WriteLine("Hurray !!!");
                AbstractState.BuildSequence(solutionState);
            }
        }
    }
}