using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.API.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrict _district;
        public DistrictController(IDistrict district)
        {
            
            _district = district;
        }

        [HttpGet("GetAllDistricts")]
        public IActionResult GetAll()
        {
            return Ok(_district.GetAll());
        }

        [HttpPost("AddDistrict")]
        public IActionResult AddDistrict(District district)
        {
            return Ok(_district.Add(district));
        }

        [HttpPut("UpdateDistrict")]
        public IActionResult UpdateDistrict(District district)
        {
            return Ok(_district.Update(district));
        }

        [HttpDelete("DeleteDistrict")]
        public IActionResult DeleteDistrict(int Id)
        {
            return Ok(_district.Delete(Id));
        }
    }
}
