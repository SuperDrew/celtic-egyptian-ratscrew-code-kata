﻿using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    public class RatscrewGameFactory : IGameFactory
    {
        public IGameController Create(ILog log)
        {
            ISnapRule[] rules =
            {
                new DarkQueenSnapRule(),
                new SandwichSnapRule(),
                new StandardSnapRule(),
                new RankSnapRule()
            };

            var penalties = new Penalties();
            var loggedPenalties = new LoggedPenalties(penalties, log);
            var gameController = new GameController(new GameState(), new SnapValidator(rules), new Dealer(),
                new Shuffler(), loggedPenalties, new PlayerSequence());
            return new LoggedGameController(gameController, log);
        }
    }
}