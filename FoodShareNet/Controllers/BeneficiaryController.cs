using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Beneficiary;
using FoodShareNet.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BeneficiaryController : ControllerBase //inherit from ControllerBase class
    {
        public BeneficiaryController()
        {

        }

        // We are defining the endpoint for retrieving all the Beneficiary data
        [ProducesResponseType(typeof(IList<BeneficiaryDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<BeneficiaryDTO>>> GetAllAsync()
        {
            return Ok(); //returns an ActionResult of IList<BeneficiaryDTO>
        }

        //We are defining the endpoint for retrieving a specific the Beneficiary data
        [ProducesResponseType(typeof(BeneficiaryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<BeneficiaryDTO>> GetAsync()
        {
            return Ok(); //returns an ActionResult of BeneficiaryDTO
        }

        //We are defining the endpoint for creating a new Beneficiary
        [ProducesResponseType(typeof(BeneficiaryDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<BeneficiaryDetailDTO>> CreateAsync(CreateBeneficiaryDTO createBeneficiaryDTO) // It takes and input a CreateBeneficiaryDTO
        {
            return Ok(); //returns an ActionResult of BeneficiaryDetailDTO
        }

        //We are defining the endpoint for editing/updating an existing Beneficiary
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditBeneficiaryDTO editBeneficiaryDTO) //It takes and input an id to identify the entity we need to update and EditBeneficiaryDTO that holds BeneficiaryData
        {
            return Ok(); //returns an ActionResult
        }

        //We are defining the endpoint for deleting an existing Beneficiary
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
