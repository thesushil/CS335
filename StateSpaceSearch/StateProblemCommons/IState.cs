using System;
using System.Collections.Generic;

namespace StateProblemCommons
{
    public interface IState : IEquatable<IState>
    {
        IState Parent { get; }
        bool IsGoal();
        IEnumerable<IState> GetNextStates();
    }
}