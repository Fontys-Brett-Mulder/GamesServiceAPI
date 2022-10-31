using GamesService.Models;
using Microsoft.AspNetCore.Mvc;
using GamesService.Services.Interfaces;

namespace GamesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {

        private readonly IGamesService _service;

        public GamesController(IGamesService service)
        {
            _service = service;
        }

        // Get all articles
        [HttpGet("getAllGames")]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetAllArticles()
        {
            return await _service.GetAllGames();
        }

        
        [HttpGet("getSpecificGame/{gameId}")]
        public async Task<ActionResult<GameModel>> GetSpecificGame(Guid gameId)
        {
            return await _service.GetSpecificGame(gameId);
        }

        /*
         * Add new Game
         */
        [HttpPost("addGame")]
        public async Task<ActionResult<GameModel>> AddGame(GameModel newGame)
        {
            return await _service.AddGame(newGame);
        }

        /**
         * Delete a game by Guid
         */
        [HttpDelete("deleteGame")]
        public async Task<ActionResult<GameModel>> DeleteGame(Guid gameId)
        {
            return await _service.DeleteGame(gameId);
        }
    }
}
