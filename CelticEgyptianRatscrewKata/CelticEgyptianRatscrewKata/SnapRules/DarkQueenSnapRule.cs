using System.Linq;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Represents the rule where the queen of spades is on the top.
    /// </summary>
    public class DarkQueenSnapRule : ISnapRule
    {
        private static readonly Card DarkQueen = new Card(Suit.Spades, Rank.Queen);

        public bool IsSnapValid(IReadOnlyGameState gameState)
        {
            // Should this be last? Not sure what order the cardStack is in.
            return DarkQueen.Equals(gameState.Stack.FirstOrDefault());
        }
    }
}
