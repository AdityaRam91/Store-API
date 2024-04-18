using GamestoreManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using StoreData;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly StoreManagementDbcontext _dbcontext;
        public LoginController(StoreManagementDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
         public IActionResult getLogin()
        {
            try
            {
                List<Login> logins = _dbcontext.Logins.ToList();
                return Ok(logins);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            try
            {
                var log = _dbcontext.Logins.FirstOrDefault(l => l.username.Equals(login.username) && l.password.Equals(login.password));
                if (log == null)
                    return BadRequest(new { message = "invalid" });
                return Ok(new { message = " login success", user = log.username });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

        }

    }
}
