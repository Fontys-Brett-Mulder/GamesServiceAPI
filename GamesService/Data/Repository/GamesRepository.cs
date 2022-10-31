using GamesService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesService.Data.Repository;

public class GamesRepository : IGamesRepository
{
    private readonly ApplicationDbContext _db;

    public GamesRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<GameModel>> GetAllGames()
    {
        return await _db.Games.ToListAsync();
    }

    public async Task<GameModel> GetSpecificGame(Guid gameId)
    {
        return await _db.Games.FirstAsync(x => x.Id == gameId);
    }

    public async Task<ActionResult<GameModel>> AddGame(GameModel newGame)
    {
        _db.Add(newGame);
        await _db.SaveChangesAsync();

        return new ActionResult<GameModel>(new OkResult());
    }

    public async Task<ActionResult<GameModel>> DeleteGame(Guid gameId)
    {
        _db.Games.Remove(new GameModel() {Id = gameId});
        await _db.SaveChangesAsync();
        return new ActionResult<GameModel>(new OkResult());
    }
}
