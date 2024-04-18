using GamestoreManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using StoreData;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class RegisterController : ControllerBase
    {
        private readonly StoreManagementDbcontext _dbcontext;
        public RegisterController(StoreManagementDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetRegister()
        {
            try
            {
                List<Register> registers = _dbcontext.Registers.ToList();
                return Ok(registers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetRegisterById(int id)
        {
            try
            {
                Register register = _dbcontext.Registers.Find(id);
                if (register == null)
                    return NotFound();
                return Ok(register);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddRegister([FromBody] Register register)
        {
            try
            {
                _dbcontext.Registers.Add(register);
                Login log = new Login { username = register.Name, password = register.Password };
                _dbcontext.Logins.Add(log);
                _dbcontext.SaveChanges();
                return CreatedAtAction(nameof(GetRegisterById), new { id = register.Id }, register);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
