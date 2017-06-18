using System.Collections.Generic;
using System.Linq;

namespace MeasureByJars.ExtensionMethods
{
    public static class ListExtension
    {
        public static bool ContainsState(this IEnumerable<JarsState> states, JarsState state) =>
            states.Any(s => Enumerable.SequenceEqual<int>(s.Amount, state.Amount));
    }
}