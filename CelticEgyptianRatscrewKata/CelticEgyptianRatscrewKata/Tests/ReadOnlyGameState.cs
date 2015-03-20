using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.Tests
{
    class ReadOnlyGameState : IReadOnlyGameState
    {
        public Cards Stack { get; set; }

        public Rank CurrentRank { get; set; }
    }
}
