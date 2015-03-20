using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.SnapRules;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    [TestFixture]
    public class RankSnapRuleTests
    {
        private RankSnapRule _rankSnapRule;

        [SetUp]
        public void SetUp()
        {
            _rankSnapRule = new RankSnapRule();
        }

        [Test]
        public void SnapFailWithEmptyCardStack()
        {
            //Arrange
            IReadOnlyGameState gameState = new ReadOnlyGameState {Stack = Cards.Empty()};

            //Act
            var result = _rankSnapRule.IsSnapValid(gameState);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SnapIsValidWhenRankMatchesCard()
        {
            //Arrange
            Cards cards = new Cards(new List<Card> {new Card(Suit.Hearts, Rank.Six)});
            IReadOnlyGameState gameState = new ReadOnlyGameState() {Stack = cards, CurrentRank = Rank.Six};

            //Act
            var result = _rankSnapRule.IsSnapValid(gameState);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
