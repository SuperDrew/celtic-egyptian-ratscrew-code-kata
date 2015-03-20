using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Aggregates snap rules to see if any are true.
    /// </summary>
    public class SnapValidator : ISnapValidator
    {
        private readonly IEnumerable<ISnapRule> _rules;

        /// <summary>
        /// Create snap validator that will check against all the given <paramref name="rules"/>
        /// </summary>
        public SnapValidator(params ISnapRule[] rules)
        {
            _rules = rules;
        }

        /// <summary>
        /// Checks if <paramref name="cardStack"/> has any valid snaps.
        /// </summary>
        public bool CanSnap(IReadOnlyGameState gameState)
        {
            return _rules.Any(r => r.IsSnapValid(gameState.Stack));
        }
    }
}
