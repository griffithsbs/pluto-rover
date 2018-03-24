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
            testSubject.Move("FFF").Should().Be("0, 6, N");
        }

        [Test]
        public void GivenForwardCommandWhenFacingSouthMovesSouth()
        {
            Rover testSubject = new Rover(Position.Of(0, 9, Direction.S));

            testSubject.Move("F").Should().Be("0, 8, S");
            testSubject.Move("F").Should().Be("0, 7, S");
            testSubject.Move("F").Should().Be("0, 6, S");
            testSubject.Move("FFF").Should().Be("0, 3, S");
        }

        [Test]
        public void GivenForwardCommandWhenFacingEastMovesEast()
        {
            Rover testSubject = new Rover(Position.Of(1, 5, Direction.E));

            testSubject.Move("F").Should().Be("2, 5, E");
            testSubject.Move("F").Should().Be("3, 5, E");
            testSubject.Move("F").Should().Be("4, 5, E");
            testSubject.Move("FFF").Should().Be("7, 5, E");
        }

        [Test]
        public void GivenForwardCommandWhenFacingWestMovesWest()
        {
            Rover testSubject = new Rover(Position.Of(7, 5, Direction.W));

            testSubject.Move("F").Should().Be("6, 5, W");
            testSubject.Move("F").Should().Be("5, 5, W");
            testSubject.Move("F").Should().Be("4, 5, W");
            testSubject.Move("FFF").Should().Be("1, 5, W");
        }
        
        [Test]
        public void GivenMultipleCommandsExecutesEachOneInOrder()
        {
            Rover testSubject = new Rover(Position.Of(0, 0, Direction.N));

            testSubject.Move("FFFF").Should().Be("0, 4, N");
        }

    }
}
