using GamestoreManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreData;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JoystickController : ControllerBase
    {
        private readonly StoreManagementDbcontext _dbcontext;
        public JoystickController(StoreManagementDbcontext dbcontext)
        {    
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetJoysticks()
        {
            try
            {
                var joystick = await _dbcontext.Joysticks.ToListAsync();
                return Ok(joystick);

            }
            catch (Exception ex)
            {
                return StatusCode(500,  $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetJoystickByTitle(string title)
        {
            try
            {
                var joystick = await _dbcontext.Joysticks.FindAsync(title);
                if (joystick == null)
                    return NotFound($"joystick with title {title} not found");
                return Ok(joystick);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 

            }
        }
        [HttpPost]
        public async Task<IActionResult> AddJoystick([FromBody] Joysticks joystick)
        {
            try
            {
                _dbcontext.Joysticks.Add(joystick);
                await _dbcontext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetJoystickByTitle), new { title = joystick.JoyTitle }, joystick);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }
    }
}
