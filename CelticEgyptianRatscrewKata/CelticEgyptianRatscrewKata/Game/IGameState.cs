﻿using System;

namespace CelticEgyptianRatscrewKata.Game
{
    public interface IGameState : IReadOnlyGameState
    {
        /// <summary>
        /// Advance the current rank, looping back to Ace after King.
        /// </summary>
        void AdvanceCurrentRank();

        /// <summary>
        /// Add the given player to the game with the given deck.
        /// </summary>
        /// <exception cref="ArgumentException">If the given player already exists</exception>
        void AddPlayer(string playerId, Cards deck);

        /// <summary>
        /// Play the top card of the given player's deck.
        /// </summary>
        Card PlayCard(string playerId);

        /// <summary>
        /// Wins the stack for the given player.
        /// </summary>
        void WinStack(string playerId);

        /// <summary>
        /// Returns true if the given player has any cards in their hand.
        /// </summary>
        bool HasCards(string playerId);

        /// <summary>
        /// Resets the game state back to its default values.
        /// </summary>
        void Clear();

        int GetNumberOfCardsInPlayersDeck(string name);
    }
}