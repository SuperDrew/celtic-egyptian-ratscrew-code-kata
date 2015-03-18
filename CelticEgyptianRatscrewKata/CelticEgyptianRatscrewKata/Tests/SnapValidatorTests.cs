﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SnapValidatorTests
    {
        [Test]
        public void SnapValidatorReturnsFalseWithNoSnapRules()
        {
            List<ISnapRule> rules = new List<ISnapRule>();
            var snapValidator = new SnapValidator(rules);
            
            IEnumerable<Card> cards = new List<Card>();
            Stack stack = new Stack(cards);
            var result = snapValidator.IsSnap(stack);

            Assert.IsFalse(result);
        }

        [Test]
        public void SnapValidatorReturnsTrueWhenSnapRuleReturnsTrue()
        {
            var snapRuleMock = new Mock<ISnapRule>();
            List<ISnapRule> rules = new List<ISnapRule>
                                    {
                                        snapRuleMock.Object
                                    };
            var snapValidator = new SnapValidator(rules);
            snapRuleMock.Setup(x => x.IsSnap(It.IsAny<Stack>())).Returns(true);

            IEnumerable<Card> cards = new List<Card>();
            Stack stack = new Stack(cards);
            var result = snapValidator.IsSnap(stack);

            Assert.IsTrue(result);
        }
    }
}