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
    }
}
