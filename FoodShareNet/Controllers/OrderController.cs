using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Order;
using FoodShareNet.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase //inherit from ControllerBase class
    {
        public OrderController()
        {

        }

        // We are defining the endpoint for retrieving all the Order data
        [ProducesResponseType(typeof(IList<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<OrderDTO>>> GetAllAsync()
        {
            return Ok(); //returns an ActionResult of IList<OrderDTO>
        }

        //We are defining the endpoint for retrieving a specific the Order data
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<OrderDTO>> GetAsync()
        {
            return Ok(); //returns an ActionResult of OrderDTO
        }

        //We are defining the endpoint for creating a new Order
        [ProducesResponseType(typeof(OrderDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<OrderDetailDTO>> CreateAsync(CreateOrderDTO createOrderDTO) // It takes and input a CreateOrderDTO
        {
            return Ok(); //returns an ActionResult of OrderDetailDTO
        }

        //We are defining the endpoint for editing/updating an existing Order
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditOrderDTO editOrderDTO) //It takes and input an id to identify the entity we need to update and EditOrderDTO that holds OrderData
        {
            return Ok(); //returns an ActionResult
        }

        //We are defining the endpoint for deleting an existing Order
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
