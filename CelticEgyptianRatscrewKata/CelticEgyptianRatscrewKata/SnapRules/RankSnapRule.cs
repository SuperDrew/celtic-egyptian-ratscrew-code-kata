﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    class RankSnapRule : ISnapRule
    {
        public bool IsSnapValid(IReadOnlyGameState gameState)
        {
            if (gameState.Stack.HasCards)
            {
                if (gameState.CurrentRank == gameState.Stack.First().Rank)
                {
                    return true;
                }
            }
            return false;
        }
    }
}