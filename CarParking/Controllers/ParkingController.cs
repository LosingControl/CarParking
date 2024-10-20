using CarParking.DTO_s;
using CarParking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService) 
        {
            _parkingService = parkingService;
        }

        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("user/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync(long id)
        {
            var user = await _parkingService.GetUserByIdAsync(id);

            if (user == null) return NotFound(new ProblemDetails() { Detail = "Пользователь с данным id не найден"});

            return Ok(user);
        }
    }
}
