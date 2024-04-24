using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Order;
using FoodShareNet.Domain.Entities;
using FoodShareNet.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase //inherit from ControllerBase class
    {
        private readonly FoodShareNetDbContext _context;
        public OrderController(FoodShareNetDbContext context)
        {
            _context = context;
        }

        // We are defining the endpoint for retrieving all the Order data
        [ProducesResponseType(typeof(IList<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<OrderDTO>>> GetAllAsync()
        {
            //return Ok(); //returns an ActionResult of IList<OrderDTO>

            var orders = await _context.Orders
                .Select(order => new OrderDTO
                {
                    Id = order.Id,
                    BeneficiaryName = order.Beneficiary.Name,
                    DonationId = order.Donation.Id,
                    CourierName = order.Courier.Name,
                    CreationDate = order.CreationDate,
                    DeliveryDate = order.DeliveryDate,
                    OrderStatusName = order.OrderStatus.Name
                }).ToListAsync();

            return Ok(orders);
        }

        //We are defining the endpoint for retrieving a specific the Order data
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]

        public async Task<ActionResult<OrderDTO>> GetAsync(int id)
        {
            //return Ok(); //returns an ActionResult of OrderDTO

            var orderDTO = await _context.Orders
                .Include(o => o.Beneficiary)
                .Include(o => o.Donation)
                .Include(o => o.OrderStatus)
                .Where(o => o.Id == id)
               .Select(order => new OrderDTO
               {
                   Id = order.Id,
                   BeneficiaryId = order.BeneficiaryId,
                   BeneficiaryName = order.Beneficiary.Name,
                   DonationId = order.Donation.Id,
                   CourierId = order.CourierId,
                   CourierName = order.Courier.Name,
                   CreationDate = order.CreationDate,
                   DeliveryDate = order.DeliveryDate,
                   OrderStatusId = order.OrderStatusId,
                   OrderStatusName = order.OrderStatus.Name
               })
               .FirstOrDefaultAsync(m => m.Id == id);

            if (orderDTO == null)
            {
                return NotFound();
            }

            return Ok(orderDTO);
        }

        //We are defining the endpoint for creating a new Order
        [ProducesResponseType(typeof(OrderDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<OrderDetailDTO>> CreateAsync([FromBody] CreateOrderDTO createOrderDTO) // It takes and input a CreateOrderDTO
        {
            //return Ok(); //returns an ActionResult of OrderDetailDTO

            var donation = await _context.Donations
                .FirstOrDefaultAsync(d => d.Id == createOrderDTO.DonationId);

            if(donation == null)
            {
                return NotFound($"Donation with Id {createOrderDTO.DonationId} not found.");
            }

            if (donation.Quantity < createOrderDTO.Quantity)
            {
                return BadRequest($"Requested quantity exceeds available quantity for Donation with Id {createOrderDTO.DonationId}.");
            }

            donation.Quantity -= createOrderDTO.Quantity;

            var order = new Order()
            {
                BeneficiaryId = createOrderDTO.BeneficiaryId,
                DonationId = createOrderDTO.DonationId,
                CourierId = createOrderDTO.CourierId,
                CreationDate = createOrderDTO.CreationDate,
                DeliveryDate = createOrderDTO.DeliveryDate,
                OrderStatusId = createOrderDTO.OrderStatusId,
            };

            _context.Add(order);
            await _context.SaveChangesAsync();

            var orderEntityDTO = new OrderDetailDTO()
            {
                Id = order.Id,
                BeneficiaryId = order.BeneficiaryId,
                DonationId = order.DonationId,
                CourierId = order.CourierId,
                CreationDate = order.CreationDate,
                DeliveryDate = order.DeliveryDate,
                OrderStatusId = order.OrderStatusId
            };

            return Ok(orderEntityDTO);
        }

        //We are defining the endpoint for editing/updating an existing Order
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, [FromBody] EditOrderDTO editOrderDTO) //It takes and input an id to identify the entity we need to update and EditOrderDTO that holds OrderData
        {
            //return Ok(); //returns an ActionResult

            if (id != editOrderDTO.Id)
            {
                return BadRequest("Mismatched Order ID");
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(b => b.Id == editOrderDTO.Id);

            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            order.BeneficiaryId = editOrderDTO.BeneficiaryId;
            order.DonationId = editOrderDTO.DonationId;
            order.CourierId = editOrderDTO.CourierId;
            order.CreationDate = editOrderDTO.CreationDate;
            order.DeliveryDate = editOrderDTO.DeliveryDate;
            order.OrderStatusId = editOrderDTO.OrderStatusId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //We are defining the endpoint for deleting an existing Order
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]

        public async Task<ActionResult> DeleteAsync(int id) //It takes and input an id to identify the entity we need to delete
        {
            //return Ok(); //returns an ActionResult

            var order = await _context.Orders
                .FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> EditOrderStatus(int id, [FromBody] EditOrderStatusDTO editOrderStatusDTO)
        {
            if (id != editOrderStatusDTO.Id)
            {
                return BadRequest("Mismatched Order ID");
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(b => b.Id == editOrderStatusDTO.Id);

            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            if (!_context.OrderStatuses.Any(s => s.Id == editOrderStatusDTO.OrderStatusId))
            {
                return NotFound($"Status with ID {editOrderStatusDTO.OrderStatusId} not found.");
            }

            order.OrderStatusId = editOrderStatusDTO.OrderStatusId;
            order.DeliveryDate = editOrderStatusDTO.DeliveryDate;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
