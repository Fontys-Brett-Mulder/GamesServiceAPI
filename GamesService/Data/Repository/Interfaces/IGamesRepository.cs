using GamesService.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesService.Data.Repository;

public interface IGamesRepository
{
    Task<List<GameModel>> GetAllGames();
    Task<GameModel> GetSpecificGame(Guid id);
    Task<ActionResult<GameModel>> AddGame(GameModel newGame);
    Task<ActionResult<GameModel>> DeleteGame(Guid id);
}
