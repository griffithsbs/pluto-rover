using FluentAssertions;
using NUnit.Framework;

namespace PlutoRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private static readonly Grid TEN_BY_TEN_GRID = new Grid(width: 10, height: 10);

        [Test]
        public void StartsAtStartingPosition()
        {
            new Rover(Position.Of(0, 0, Direction.N), TEN_BY_TEN_GRID).ReportPosition().Should().Be("0, 0, N");
            new Rover(Position.Of(10, 0, Direction.S), TEN_BY_TEN_GRID).ReportPosition().Should().Be("10, 0, S");
            new Rover(Position.Of(42, 42, Direction.W), TEN_BY_TEN_GRID).ReportPosition().Should().Be("42, 42, W");
        }

        [Test]
        public void GivenForwardCommandWhenFacingNorthMovesNorth()
        {
            Rover testSubject = new Rover(Position.Of(0, 0, Direction.N), TEN_BY_TEN_GRID);

            testSubject.Move("F").Should().Be("0, 1, N");
            testSubject.Move("F").Should().Be("0, 2, N");
            testSubject.Move("F").Should().Be("0, 3, N");
            testSubject.Move("FFF").Should().Be("0, 6, N");
        }

        [Test]
        public void GivenForwardCommandWhenFacingSouthMovesSouth()
        {
            Rover testSubject = new Rover(Position.Of(0, 9, Direction.S), TEN_BY_TEN_GRID);

            testSubject.Move("F").Should().Be("0, 8, S");
            testSubject.Move("F").Should().Be("0, 7, S");
            testSubject.Move("F").Should().Be("0, 6, S");
            testSubject.Move("FFF").Should().Be("0, 3, S");
        }

        [Test]
        public void GivenForwardCommandWhenFacingEastMovesEast()
        {
            Rover testSubject = new Rover(Position.Of(1, 5, Direction.E), TEN_BY_TEN_GRID);

            testSubject.Move("F").Should().Be("2, 5, E");
            testSubject.Move("F").Should().Be("3, 5, E");
            testSubject.Move("F").Should().Be("4, 5, E");
            testSubject.Move("FFF").Should().Be("7, 5, E");
        }

        [Test]
        public void GivenForwardCommandWhenFacingWestMovesWest()
        {
            Rover testSubject = new Rover(Position.Of(7, 5, Direction.W), TEN_BY_TEN_GRID);

            testSubject.Move("F").Should().Be("6, 5, W");
            testSubject.Move("F").Should().Be("5, 5, W");
            testSubject.Move("F").Should().Be("4, 5, W");
            testSubject.Move("FFF").Should().Be("1, 5, W");
        }

        [Test]
        public void GivenBackCommandWhenFacingNorthMovesSouth()
        {
            Rover testSubject = new Rover(Position.Of(0, 9, Direction.N), TEN_BY_TEN_GRID);

            testSubject.Move("B").Should().Be("0, 8, N");
            testSubject.Move("B").Should().Be("0, 7, N");
            testSubject.Move("B").Should().Be("0, 6, N");
            testSubject.Move("BBB").Should().Be("0, 3, N");
        }

        [Test]
        public void GivenBackCommandWhenFacingSouthMovesNorth()
        {
            Rover testSubject = new Rover(Position.Of(0, 1, Direction.S), TEN_BY_TEN_GRID);

            testSubject.Move("B").Should().Be("0, 2, S");
            testSubject.Move("B").Should().Be("0, 3, S");
            testSubject.Move("B").Should().Be("0, 4, S");
            testSubject.Move("BBB").Should().Be("0, 7, S");
        }

        [Test]
        public void GivenBackCommandWhenFacingEastMovesWest()
        {
            Rover testSubject = new Rover(Position.Of(8, 5, Direction.E), TEN_BY_TEN_GRID);

            testSubject.Move("B").Should().Be("7, 5, E");
            testSubject.Move("B").Should().Be("6, 5, E");
            testSubject.Move("B").Should().Be("5, 5, E");
            testSubject.Move("BBB").Should().Be("2, 5, E");
        }

        [Test]
        public void GivenBackCommandWhenFacingWestMovesEast()
        {
            Rover testSubject = new Rover(Position.Of(0, 5, Direction.W), TEN_BY_TEN_GRID);

            testSubject.Move("B").Should().Be("1, 5, W");
            testSubject.Move("B").Should().Be("2, 5, W");
            testSubject.Move("B").Should().Be("3, 5, W");
            testSubject.Move("BBB").Should().Be("6, 5, W");
        }

        [Test]
        public void GivenALeftCommandRobotDoesNotMoveFromSpot()
        {
            Rover testSubject = new Rover(Position.Of(0, 0, Direction.N), TEN_BY_TEN_GRID);

            testSubject.Move("L").Should().StartWith("0, 0");
        }

        [Test]
        public void GivenALeftCommandRobotTurnsAntiClockwise()
        {
            Rover testSubject = new Rover(Position.Of(5, 5, Direction.N), TEN_BY_TEN_GRID);

            testSubject.Move("L").Should().EndWith("W");
            testSubject.Move("L").Should().EndWith("S");
            testSubject.Move("LL").Should().EndWith("N");
        }

        [Test]
        public void GivenARightCommandRobotDoesNotMoveFromSpot()
        {
            Rover testSubject = new Rover(Position.Of(0, 0, Direction.N), TEN_BY_TEN_GRID);

            testSubject.Move("R").Should().StartWith("0, 0");
        }

        [Test]
        public void GivenARightCommandRobotTurnsClockwise()
        {
            Rover testSubject = new Rover(Position.Of(5, 5, Direction.N), TEN_BY_TEN_GRID);

            testSubject.Move("R").Should().EndWith("E");
            testSubject.Move("R").Should().EndWith("S");
            testSubject.Move("RRR").Should().EndWith("E");
        }

        [Test]
        public void GivenMultipleCommandsExecutesEachOneInOrder()
        {
            Rover testSubject = new Rover(Position.Of(5, 5, Direction.N), TEN_BY_TEN_GRID);

            testSubject.Move("RFBFBFBFBBL").Should().Be("4, 5, N");
        }

        [Test]
        public void GivenACommandToMoveForwardOffOfTheGridWrapsToOppositeEdgeOfGrid()
        {
            new Rover(Position.Of(0, 9, Direction.N), TEN_BY_TEN_GRID)
                .Move("F").Should().Be("0, 0, N");

            new Rover(Position.Of(2, 2, Direction.S), TEN_BY_TEN_GRID)
                .Move("FFFFF").Should().Be("2, 7, S");

            new Rover(Position.Of(0, 0, Direction.W), TEN_BY_TEN_GRID)
                .Move("F").Should().Be("9, 0, W");

            new Rover(Position.Of(8, 0, Direction.E), TEN_BY_TEN_GRID)
                .Move("FFF").Should().Be("1, 0, E");
        }

        [Test]
        public void GivenACommandToMoveBackwardOffOfTheGridWrapsToOppositeEdgeOfGrid()
        {
            new Rover(Position.Of(0, 9, Direction.S), TEN_BY_TEN_GRID)
                .Move("B").Should().Be("0, 0, S");

            new Rover(Position.Of(2, 2, Direction.N), TEN_BY_TEN_GRID)
                .Move("BBBBB").Should().Be("2, 7, N");

            new Rover(Position.Of(0, 0, Direction.E), TEN_BY_TEN_GRID)
                .Move("B").Should().Be("9, 0, E");

            new Rover(Position.Of(8, 0, Direction.W), TEN_BY_TEN_GRID)
                .Move("BBB").Should().Be("1, 0, W");
        }

    }
}
