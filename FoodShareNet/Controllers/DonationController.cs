using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Donation;
using FoodShareNet.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DonationController : ControllerBase //inherit from ControllerBase class
    {
        public DonationController()
        {

        }

        // We are defining the endpoint for retrieving all the Donation data
        [ProducesResponseType(typeof(IList<DonationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<DonationDTO>>> GetAllAsync()
        {
            return Ok(); //returns an ActionResult of IList<DonationDTO>
        }

        //We are defining the endpoint for retrieving a specific the Donation data
        [ProducesResponseType(typeof(DonationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<DonationDTO>> GetAsync()
        {
            return Ok(); //returns an ActionResult of DonationDTO
        }

        //We are defining the endpoint for creating a new Donation
        [ProducesResponseType(typeof(DonationDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<DonationDetailDTO>> CreateAsync(CreateDonationDTO createDonationDTO) // It takes and input a CreateDonationDTO
        {
            return Ok(); //returns an ActionResult of DonationDetailDTO
        }

        //We are defining the endpoint for editing/updating an existing Donation
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditDonationDTO editDonationDTO) //It takes and input an id to identify the entity we need to update and EditDonationDTO that holds DonationData
        {
            return Ok(); //returns an ActionResult
        }

        //We are defining the endpoint for deleting an existing Donation
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
