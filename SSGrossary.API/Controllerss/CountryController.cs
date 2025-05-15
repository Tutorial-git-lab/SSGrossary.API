using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.API.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountry _country;

        public CountryController(ICountry country)
        {
            _country = country;
        }

        [HttpGet("GetAllCountries")]
        public IActionResult GetAllCountries()
        {
            return Ok(_country.GetAll());
        }

        [HttpPost("AddCountry")]
        public IActionResult AddCountry(Country country)
        {
            return Ok(_country.Add(country));
        }

        [HttpPut("UpdateCountry")]
        public IActionResult UpdateCountry(Country country)
        {
            return Ok(_country.Update(country));
        }

        [HttpDelete("DeleteCountry")]
        public IActionResult DeleteCountry(int Id)
        {
            return Ok(_country.Delete(Id));
        }
    }
}
