using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Courier;
using FoodShareNet.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourierController : ControllerBase //inherit from ControllerBase class
    {
        public CourierController()
        {

        }

        // We are defining the endpoint for retrieving all the Courier data
        [ProducesResponseType(typeof(IList<CourierDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<CourierDTO>>> GetAllAsync()
        {
            return Ok(); //returns an ActionResult of IList<CourierDTO>
        }

        //We are defining the endpoint for retrieving a specific the Courier data
        [ProducesResponseType(typeof(CourierDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<CourierDTO>> GetAsync()
        {
            return Ok(); //returns an ActionResult of CourierDTO
        }

        //We are defining the endpoint for creating a new Courier
        [ProducesResponseType(typeof(CourierDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<CourierDetailDTO>> CreateAsync(CreateCourierDTO createCourierDTO) // It takes and input a CreateCourierDTO
        {
            return Ok(); //returns an ActionResult of CourierDetailDTO
        }

        //We are defining the endpoint for editing/updating an existing Courier
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditCourierDTO editCourierDTO) //It takes and input an id to identify the entity we need to update and EditCourierDTO that holds CourierData
        {
            return Ok(); //returns an ActionResult
        }

        //We are defining the endpoint for deleting an existing Courier
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
