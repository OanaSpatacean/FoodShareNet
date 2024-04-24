using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Courier;
using FoodShareNet.Domain.Entities;
using FoodShareNet.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourierController : ControllerBase //inherit from ControllerBase class
    {
        private readonly FoodShareNetDbContext _context;
        public CourierController(FoodShareNetDbContext context)
        {
            _context = context;
        }

        // We are defining the endpoint for retrieving all the Courier data
        [ProducesResponseType(typeof(IList<CourierDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<CourierDTO>>> GetAllAsync()
        {
            //return Ok(); //returns an ActionResult of IList<CourierDTO>

            var couriers = await _context.Couriers
                .Select(courier => new CourierDTO
                {
                    Id = courier.Id,
                    Name = courier.Name,
                    Price = courier.Price
                }).ToListAsync();

            return Ok(couriers);
        }

        //We are defining the endpoint for retrieving a specific the Courier data
        [ProducesResponseType(typeof(CourierDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<CourierDTO>> GetAsync(int? id)
        {
            //return Ok(); //returns an ActionResult of CourierDTO

            var courierDTO = await _context.Couriers
                .Select(courier => new CourierDTO
                {
                    Id = courier.Id,
                    Name = courier.Name,
                    Price = courier.Price
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if (courierDTO == null)
            {
                return NotFound();
            }

            return Ok(courierDTO);
        }

        //We are defining the endpoint for creating a new Courier
        [ProducesResponseType(typeof(CourierDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<CourierDetailDTO>> CreateAsync(CreateCourierDTO createCourierDTO) // It takes and input a CreateCourierDTO
        {
            //return Ok(); //returns an ActionResult of CourierDetailDTO

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courier = new Courier()
            {
                Name = createCourierDTO.Name,
                Price = createCourierDTO.Price,
            };

            _context.Add(courier);
            await _context.SaveChangesAsync();

            var courierEntityDTO = new CourierDetailDTO()
            {
                Id = courier.Id,
                Name = courier.Name,
                Price = courier.Price,
            };

            return Ok(courierEntityDTO);
        }

        //We are defining the endpoint for editing/updating an existing Courier
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditCourierDTO editCourierDTO) //It takes and input an id to identify the entity we need to update and EditCourierDTO that holds CourierData
        {
            //return Ok(); //returns an ActionResult

            if (id != editCourierDTO.Id)
            {
                return BadRequest("Mismatched Courier ID");
            }

            var courier = await _context.Couriers
                .FirstOrDefaultAsync(b => b.Id == editCourierDTO.Id);

            if (courier == null)
            {
                return NotFound();
            }

            courier.Name = editCourierDTO.Name;
            courier.Price = editCourierDTO.Price;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //We are defining the endpoint for deleting an existing Courier
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]

        public async Task<ActionResult> DeleteAsync(int id) //It takes and input an id to identify the entity we need to delete
        {
            //return Ok(); //returns an ActionResult

            var courier = await _context.Couriers
                .FindAsync(id);

            if (courier == null)
            {
                return NotFound();
            }

            _context.Couriers.Remove(courier);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
