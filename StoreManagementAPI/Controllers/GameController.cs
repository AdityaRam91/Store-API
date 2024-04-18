using GamestoreManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreData;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly StoreManagementDbcontext _dbcontext;
        public  GameController(StoreManagementDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                var Games = await _dbcontext.Games.ToListAsync();
                return Ok(Games);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Internal server error{ex.Message}");
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetGameByTitle(string title)
        {
            try
            {
                var game = await _dbcontext.Games.FindAsync(title);
                if (game == null)
                {
                    return NotFound($"Game with title {title} not found");
                }

                return Ok(game);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server issue : {ex.Message}");    
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGames([FromBody] Games games)
        {
            try
            {
                _dbcontext.Games.Add(games);
                await _dbcontext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetGameByTitle), new { title = games.GameTitle }, games);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
