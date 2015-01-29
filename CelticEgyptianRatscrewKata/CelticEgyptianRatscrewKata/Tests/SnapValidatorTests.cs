﻿using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.SnapRules;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SnapValidatorTests
    {
        [Test]
        public void ShouldNotBeSnappableIfAllRulesReturnFalse()
        {
            var ruleMock = new Mock<IRule>();
            ruleMock.Setup(x => x.CanSnap(It.IsAny<Stack>())).Returns(false);
            var rules = new List<IRule> { ruleMock.Object, ruleMock.Object };

            var stack = Stack.Empty();
            var snapValidator = new SnapValidator();
            bool canSnap = snapValidator.CanSnap(stack, rules);

            Assert.That(canSnap, Is.False);
        }

        [Test]
        public void ShouldBeSnappableIfARuleReturnsTrue()
        {
            var falseRuleMock = new Mock<IRule>();
            var trueRuleMock = new Mock<IRule>();
            falseRuleMock.Setup(x => x.CanSnap(It.IsAny<Stack>())).Returns(false);
            trueRuleMock.Setup(x => x.CanSnap(It.IsAny<Stack>())).Returns(true);
            var rules = new List<IRule> { falseRuleMock.Object, trueRuleMock.Object };

            var stack = Stack.Empty();
            var snapValidator = new SnapValidator();
            bool canSnap = snapValidator.CanSnap(stack, rules);

            Assert.That(canSnap, Is.True);
        }

        [Test]
        public void ShouldPassStackToRule()
        {
            var ruleMock = new Mock<IRule>();
            ruleMock.Setup(x => x.CanSnap(It.IsAny<Stack>())).Returns(false);
            var rules = new List<IRule> { ruleMock.Object };

            var stack = Stack.Empty();
            var snapValidator = new SnapValidator();
            snapValidator.CanSnap(stack, rules);

            ruleMock.Verify(r => r.CanSnap(stack), Times.Once());            
        }
    }
}