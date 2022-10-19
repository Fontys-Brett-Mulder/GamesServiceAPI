using GamesService.Data.Repository;
using GamesService.Models;

namespace GamesService.Tests
{
    public class GamesServiceTest
    {
        private readonly List<GameModel> _games;

        public GamesServiceTest()
        {
            _games = new List<GameModel>()
            {
                new GameModel()
                {
                    Id = new Guid(),
                    Name = "Test Game 1",
                    Difficulty = "Easy",
                    MinPlayers = 0,
                    MaxPlayers = 0
                },
                new GameModel()
                {
                    Id = new Guid(),
                    Name = "Test Game 2",
                    Difficulty = "Hard",
                    MinPlayers = 2,
                    MaxPlayers = 10
                },
                new GameModel()
                {
                    Id = new Guid(),
                    Name = "Test Game 3",
                    Difficulty = "Medium",
                    MinPlayers = 2,
                    MaxPlayers = 5
                },
            };
        }

        /**
         * Tests if the amount is equal
         */
        [Fact]
        public async void GamesCheckIfAmountIsEqual()
        {
            var repository = new Mock<IGamesRepository>();
            repository.Setup(m => m.GetAllGames()).ReturnsAsync(_games);

            var service = new Services.GamesService(repository.Object);

            var games = await service.GetAllGames();
            
            // Should give true because the number of items in _games is 3
            Assert.Equal(games.Count, _games.Count);
        }
    }
}