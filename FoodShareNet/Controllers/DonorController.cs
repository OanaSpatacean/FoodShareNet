using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Donor;
using FoodShareNet.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DonorController : ControllerBase //inherit from ControllerBase class
    {
        public DonorController()
        {

        }

        // We are defining the endpoint for retrieving all the Donor data
        [ProducesResponseType(typeof(IList<DonorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<DonorDTO>>> GetAllAsync()
        {
            return Ok(); //returns an ActionResult of IList<DonorDTO>
        }

        //We are defining the endpoint for retrieving a specific the Donor data
        [ProducesResponseType(typeof(DonorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<DonorDTO>> GetAsync()
        {
            return Ok(); //returns an ActionResult of DonorDTO
        }

        //We are defining the endpoint for creating a new Donor
        [ProducesResponseType(typeof(DonorDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<DonorDetailDTO>> CreateAsync(CreateDonorDTO createDonorDTO) // It takes and input a CreateDonorDTO
        {
            return Ok(); //returns an ActionResult of DonorDetailDTO
        }

        //We are defining the endpoint for editing/updating an existing Donor
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditDonorDTO editDonorDTO) //It takes and input an id to identify the entity we need to update and EditDonorDTO that holds DonorData
        {
            return Ok(); //returns an ActionResult
        }

        //We are defining the endpoint for deleting an existing Donor
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]

        public async Task<ActionResult> DeleteAsync(int id) //It takes and input an id to identify the entity we need to delete
        {
            return Ok(); //returns an ActionResult
        }
    }
}
