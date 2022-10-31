using GamesService.Data.Repository;
using GamesService.Models;
using Microsoft.AspNetCore.Mvc;
using GamesService.Services.Interfaces;

namespace GamesService.Services;

public class GamesService : IGamesService
{
    private readonly IGamesRepository _repository;

    public GamesService(IGamesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GameModel>> GetAllGames()
    {
        var games = await _repository.GetAllGames();
        return games.OrderBy(x => x.Name).ToList();
    }

    public async Task<GameModel> GetSpecificGame(Guid gameId)
    {
        return await _repository.GetSpecificGame(gameId);
    }

    public async Task<ActionResult<GameModel>> AddGame(GameModel newGame)
    {
        return await _repository.AddGame(newGame);
    }

    public async Task<ActionResult<GameModel>> DeleteGame(Guid gameId)
    {
        return await _repository.DeleteGame(gameId);
    }
}
