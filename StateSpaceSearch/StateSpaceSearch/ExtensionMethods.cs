using System.Collections.Generic;
using System.Linq;

namespace StateSpaceSearch.ExtensionMethods
{
    public static class ListExtension
    {
        public static bool ContainsState(this IList<JarsState> states, JarsState state) =>
            states.Any(s => s.Amount.SequenceEqual(state.Amount));
    }
}