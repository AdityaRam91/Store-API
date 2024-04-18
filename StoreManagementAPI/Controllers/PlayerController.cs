using GamestoreManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreData;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly StoreManagementDbcontext _dbcontext;
        public PlayerController(StoreManagementDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayer()
        {
            try
            {
                var players = await _dbcontext.Players.ToListAsync();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayerByTitle( string title)
        {
            try
            {
                var player = await _dbcontext.Players.FindAsync(title);
                if (player == null)
                    return NotFound($"player with title{title} not found");
                return Ok(player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }
        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] Players player)
        {
            try
            {
                _dbcontext.Players.Add(player);
                await _dbcontext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPlayerByTitle), new { title = player.PlayerTitle }, player);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
    }
}
