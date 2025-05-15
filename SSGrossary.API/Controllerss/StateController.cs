using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.API.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IState _state;
        public StateController(IState state)
        {
            _state = state;
            
        }

        [HttpGet("GetAllStates")]
        public IActionResult GetAllCountries()
        {
            return Ok(_state.GetAll());
        }

        [HttpPost("AddState")]
        public IActionResult AddState(State state)
        {
            return Ok(_state.Add(state));
        }

        [HttpPut("UpdateState")]
        public IActionResult UpdateState(State state)
        {
            return Ok(_state.Update(state));
        }

        [HttpDelete("DeleteState")]
        public IActionResult DeleteState(int Id)
        {
            return Ok(_state.Delete(Id));
        }
    }
}
