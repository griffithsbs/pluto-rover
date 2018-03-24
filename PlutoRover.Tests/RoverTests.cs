﻿using FluentAssertions;
using NUnit.Framework;

namespace PlutoRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void StartsAtStartingPosition()
        {
            new Rover(Position.Of(0, 0, Direction.N)).ReportPosition().Should().Be("0, 0, N");
            new Rover(Position.Of(10, 0, Direction.S)).ReportPosition().Should().Be("10, 0, S");
            new Rover(Position.Of(42, 42, Direction.W)).ReportPosition().Should().Be("42, 42, W");
        }

        [Test]
        public void GivenForwardCommandWhenFacingNorthMovesNorth()
        {
            Rover testSubject = new Rover(Position.Of(0, 0, Direction.N));

            testSubject.Move("F").Should().Be("0, 1, N");
            testSubject.Move("F").Should().Be("0, 2, N");
            testSubject.Move("F").Should().Be("0, 3, N");
        }

    }
}
