namespace CelticEgyptianRatscrewKata.Game
{
    public interface IReadOnlyGameState
    {
        /// <summary>
        /// Gets a copy of the current stack of cards.
        /// </summary>
        Cards Stack { get; }

        /// <summary>
        /// Gets the last rank called.
        /// </summary>
        Rank CurrentRank { get; }
    }
}
