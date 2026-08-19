using System;
using System.Collections.Generic;
using System.Text;
using TournamentPlatform.API.Model.Domain;

namespace TournamentPlatform.Test
{
    public class SingleEliminationSystemTests
    {
        [Theory]
        [InlineData(2, 1)]
        [InlineData(4, 3)]
        [InlineData(8, 7)]
        [InlineData(16, 15)]
        [InlineData(32, 31)]
        [InlineData(64, 63)]

        public void GenerateMatches_NumberOfParticipants_ReturnsCorrectMatchesAmount(int input, int expected)
        {
            //Arrange
            List<Participant> participants = new List<Participant>();

            for (int i = 0; i < input; i++)
            {
                participants.Add(new Participant());
            }

            SingleEliminationSystem system = new SingleEliminationSystem();

            //Act
            var matches = system.GenerateMatches(participants);

            //Assert
            Assert.Equal(expected, matches.Count);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(8, 4)]
        [InlineData(16, 8)]
        [InlineData(32, 16)]
        [InlineData(64, 32)]
        public void GenerateMatches_NumberOfMatchesFirstRound_ReturnsCorrectAmount(int input, int expected)
        {
            //Arrange
            List<Participant> participants = new List<Participant>();

            for (int i = 0; i < input; i++)
            {
                participants.Add(new Participant());
            }

            SingleEliminationSystem system = new SingleEliminationSystem();

            //Act
            var matches = system.GenerateMatches(participants);

            int roundCount = 0;

            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Round == 1)
                {
                    roundCount++;
                }
            }

            //Assert
            Assert.Equal(expected, roundCount);
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(8, 2)]
        [InlineData(16, 4)]
        [InlineData(32, 8)]
        [InlineData(64, 16)]
        public void GenerateMatches_NumberOfMatchesSecondRound_ReturnsCorrectAmount(int input, int expected)
        {
            //Arrange
            List<Participant> participants = new List<Participant>();

            for (int i = 0; i < input; i++)
            {
                participants.Add(new Participant());
            }

            SingleEliminationSystem system = new SingleEliminationSystem();

            //Act
            var matches = system.GenerateMatches(participants);

            int roundCount = 0;

            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Round == 2)
                {
                    roundCount++;
                }
            }

            //Assert
            Assert.Equal(expected, roundCount);
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(8, 1)]
        [InlineData(16, 2)]
        [InlineData(32, 4)]
        [InlineData(64, 8)]
        public void GenerateMatches_NumberOfMatchesThirdRound_ReturnsCorrectAmount(int input, int expected)
        {
            //Arrange
            List<Participant> participants = new List<Participant>();

            for (int i = 0; i < input; i++)
            {
                participants.Add(new Participant());
            }

            SingleEliminationSystem system = new SingleEliminationSystem();

            //Act
            var matches = system.GenerateMatches(participants);

            int roundCount = 0;

            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Round == 3)
                {
                    roundCount++;
                }
            }

            //Assert
            Assert.Equal(expected, roundCount);
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(8, 0)]
        [InlineData(16, 1)]
        [InlineData(32, 2)]
        [InlineData(64, 4)]
        public void GenerateMatches_NumberOfMatchesFourthRound_ReturnsCorrectAmount(int input, int expected)
        {
            //Arrange
            List<Participant> participants = new List<Participant>();

            for (int i = 0; i < input; i++)
            {
                participants.Add(new Participant());
            }

            SingleEliminationSystem system = new SingleEliminationSystem();

            //Act
            var matches = system.GenerateMatches(participants);

            int roundCount = 0;

            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Round == 4)
                {
                    roundCount++;
                }
            }

            //Assert
            Assert.Equal(expected, roundCount);
        }

        [Theory]
        [InlineData(3, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 2)]
        [InlineData(24, 8)]
        [InlineData(36, 4)]
        [InlineData(48, 16)]
        public void GenerateMatches_NumberOfParticipantsNotPowerOfTwoQualificationRound_ReturnsCorrectMatchesAmount(int input, int expected)
        {
            //Arrange
            List<Participant> participants = new List<Participant>();

            for (int i = 0; i < input; i++)
            {
                participants.Add(new Participant());
            }

            SingleEliminationSystem system = new SingleEliminationSystem();

            //Act
            var matches = system.GenerateMatches(participants);

            int roundCount = 0;

            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Round == 0)
                {
                    roundCount++;
                }
            }

            //Assert
            Assert.Equal(expected, roundCount);
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(5, 8)]
        [InlineData(6, 8)]
        [InlineData(24, 32)]
        [InlineData(36, 64)]
        [InlineData(48, 64)]
        public void NextPowerOfTwo_Number_ReturnsNextPowerOfTwo(int input, int expected)
        {
            //Arrange
            SingleEliminationSystem system = new SingleEliminationSystem();

            //Act
            int result = system.NextPowerOfTwo(input);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
