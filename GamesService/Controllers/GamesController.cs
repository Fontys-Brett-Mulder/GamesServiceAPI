using GamesService.DataContext;
using GamesService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        private ApplicationDbContext _db;

        public GamesController(ApplicationDbContext db)
        {
            _db = db;
        }


        // Get all articles
        [HttpGet("getAllGames")]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetAllArticles()
        {

            List<GameModel> allGames = await _db.Games.ToListAsync();

            return allGames;
        }

        /**
         * Get a game with specific Id
         */
        [HttpGet("getSpecificgame/{id}")]
        public async Task<ActionResult<GameModel>> GetSpecificgame(Guid id)
        {
            var game = await _db.Games.FirstOrDefaultAsync(x => x.Id == id);

            return game;
        }

        /*
         * Add new Game
         */
        [HttpPost("addGame")]
        public async Task<ActionResult<GameModel>> AddArticle(GameModel game)
        {
            _db.Add(game);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetAllArticles", new { id = game.Id }, game);
        }
    }
}
