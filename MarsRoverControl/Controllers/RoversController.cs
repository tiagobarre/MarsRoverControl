using MarsRoverControl.API.DTOs;
using MarsRoverControl.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace MarsRoverControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoversController : ControllerBase
    {        

        [HttpPost]
        public IActionResult ExecuteRoversPost([FromBody] RoverCommandRequest request)
        {
            var result = RoversModels.ExecuteRovers(request);

            if (result == "Direção Inválida")
                return BadRequest(result);

            if (result == "Posição inválida ou ocupada")
                return Conflict(result);

            return Ok(result);
        }
    }
}
