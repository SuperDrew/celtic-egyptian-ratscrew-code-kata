using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class SnapValidatorTests
    {
        [Test]
        public void ReturnsFalseIfNoRulesAndNoStack()
        {
            //ARRANGE
            var snapValidator = new SnapValidator();

            //ACT
            var result = snapValidator.CanSnap(new ReadOnlyGameState {Stack = Cards.Empty()});

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueIfThereIsOneRuleAndItReturnsTrue()
        {
            //ARRANGE
            var alwaysTrueRule = Substitute.For<ISnapRule>();
            alwaysTrueRule.IsSnapValid(Arg.Any<IReadOnlyGameState>()).Returns(true);
            var snapValidator = new SnapValidator(alwaysTrueRule);

            //ACT
            var result = snapValidator.CanSnap(new ReadOnlyGameState {Stack = Cards.Empty()});

            //ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsTrueOnlyOnSpecificStack()
        {
            //ARRANGE
            var cardStack = new Cards(new []
            {
                new Card(Suit.Clubs, Rank.Ace) 
            });

            var alwaysTrueRule = Substitute.For<ISnapRule>();
            alwaysTrueRule.IsSnapValid(Arg.Any<IReadOnlyGameState>()).Returns(false);
            var gameState = new ReadOnlyGameState {Stack = cardStack};
            alwaysTrueRule.IsSnapValid(gameState).Returns(true);

            var snapValidator = new SnapValidator(alwaysTrueRule);

            //ACT
            var result = snapValidator.CanSnap(gameState);

            //ASSERT
            Assert.IsTrue(result);
        }
    }
}
