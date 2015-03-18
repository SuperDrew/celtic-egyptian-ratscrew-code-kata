﻿using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SandwichSnapTests
    {
        [Test]
        public void EmptyStackIsNotAValidSnap()
        {
            var snapRule = new SandwichSnap();
            var cards = new List<Card>();
            Stack emptyStack = new Stack(cards);

            var result = snapRule.IsSnap(emptyStack);

            Assert.IsFalse(result);
        }

        [Test]
        public void ASandwichOfTwoCardsOfSameRankIsValidSnap()
        {
            var snapRule = new SandwichSnap();
            var cards = new List<Card>
                        {
                            new Card(Suit.Clubs, Rank.Ace),
                            new Card(Suit.Clubs, Rank.Two),
                            new Card(Suit.Diamonds, Rank.Ace)

                        };
            Stack snapStack = new Stack(cards);

            var result = snapRule.IsSnap(snapStack);

            Assert.IsTrue(result);

        }

        [Test]
        public void SandwichSnapInMiddleOfStackIsValidSnap()
        {
            var snapRule = new SandwichSnap();
            var cards = new List<Card>
                        {
                            new Card(Suit.Hearts, Rank.Ace),
                            new Card(Suit.Clubs, Rank.Two),
                            new Card(Suit.Clubs, Rank.Three),
                            new Card(Suit.Diamonds, Rank.Two),
                            new Card(Suit.Clubs, Rank.Four)
                        };
            Stack snapStack = new Stack(cards);

            var result = snapRule.IsSnap(snapStack);

            Assert.IsTrue(result);
        }
        
        [Test]
        public void ThreeCardsInStackWithNoSandwichSnapNotValidSnap()
        {
            var snapRule = new SandwichSnap();
            var cards = new List<Card>
                        {
                            new Card(Suit.Clubs, Rank.Ace),
                            new Card(Suit.Hearts, Rank.Two),
                            new Card(Suit.Diamonds, Rank.Three)
                        };
            Stack snapStack = new Stack(cards);

            var result = snapRule.IsSnap(snapStack);

            Assert.IsFalse(result);
        }
    }
}