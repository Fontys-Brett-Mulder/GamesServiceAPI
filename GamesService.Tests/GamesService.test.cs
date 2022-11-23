using GamesService.Data.Repository;
using GamesService.Models;
using Xunit.Abstractions;

namespace GamesService.Tests
{
    public class GamesServiceTest
    {
        private readonly List<GameModel> _games;

        // private readonly ITestOutputHelper _testOutputHelper;
        private readonly Mock<IGamesRepository> _repository = new Mock<IGamesRepository>();

        public GamesServiceTest()
        {
            _games = new List<GameModel>()
            {
                new GameModel()
                {
                    Id = new Guid("7ea98e9a-7364-4b7a-af16-8a8b478ca58a"),
                    Name = "A Test Game 1",
                    Difficulty = "Easy",
                    MinPlayers = 0,
                    MaxPlayers = 0
                },
                new GameModel()
                {
                    Id = new Guid("e2fedb68-132b-4f3e-825b-53aca606ca87"),
                    Name = "C Test Game 2",
                    Difficulty = "Hard",
                    MinPlayers = 2,
                    MaxPlayers = 10
                },
                new GameModel()
                {
                    Id = new Guid("ed6356e1-c3d4-4c61-a3b5-d124ad679421"),
                    Name = "B Test Game 3",
                    Difficulty = "Medium",
                    MinPlayers = 2,
                    MaxPlayers = 5
                },
            };
        }

        /// <summary>
        /// Check if the amount of games is equal
        /// </summary>
        [Fact]
        public async void GamesCheckIfAmountIsEqual()
        {
            _repository.Setup(m => m.GetAllGames()).ReturnsAsync(_games);

            var service = new Services.GamesService(_repository.Object);

            var games = await service.GetAllGames();

            // Should give true because the number of items in _games is 3
            Assert.Equal(games.Count, _games.Count);
        }
        
        /// <summary>
        /// Check if the specific games are of type GameModel
        /// </summary>
        /// <param name="guid"></param>
        [Theory]
        [InlineData("7ea98e9a-7364-4b7a-af16-8a8b478ca58a")]
        [InlineData("e2fedb68-132b-4f3e-825b-53aca606ca87")]
        [InlineData("ed6356e1-c3d4-4c61-a3b5-d124ad679421")]
        public async void CheckIfItemsAreOfTypeObject(Guid guid)
        {
            // Creating a mock for the GetSpecificGame function
            _repository.Setup(m => m.GetSpecificGame(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => _games.FirstOrDefault(g => g.Id == guid));
            
            var service = new Services.GamesService(_repository.Object);

            var game = await service.GetSpecificGame(guid);
            
            // Check if all the 
            Assert.IsType<GameModel>(game);
        }

        /// <summary>
        /// Check if the games are getting ordered by name in the service
        /// </summary>
        [Fact]
        public async void CheckIfIsOrdered()
        {
            // Order the list manually
            List<GameModel> orderedList = _games.OrderBy(game => game.Name).ToList();
            
            _repository.Setup(m => m.GetAllGames()).ReturnsAsync(_games);

            var service = new Services.GamesService(_repository.Object);

            var games = await service.GetAllGames();
            
            Assert.Equal(orderedList, games);
        }

        [Theory]
        [InlineData("7ea98e9a-7364-4b7a-af16-8a8b478ca58a")]
        public async void CheckIfHasSpecificFields(Guid guid)
        {
            // Creating a mock for the GetSpecificGame function
            _repository.Setup(m => m.GetSpecificGame(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => _games.FirstOrDefault(g => g.Id == guid));
            
            var service = new Services.GamesService(_repository.Object);
            
            var game = await service.GetSpecificGame(guid);
            
            Assert.IsType<string>(game.Difficulty);
            Assert.IsType<int>(game.MaxPlayers);
            Assert.IsType<int>(game.MinPlayers);
            Assert.IsType<string>(game.Name);
        }
    }
}
