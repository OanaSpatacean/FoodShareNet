using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Donation;
using FoodShareNet.Domain.Entities;
using FoodShareNet.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DonationController : ControllerBase //inherit from ControllerBase class
    {
        private readonly FoodShareNetDbContext _context;
        public DonationController(FoodShareNetDbContext context)
        {
            _context = context;
        }

        // We are defining the endpoint for retrieving all the Donation data
        [ProducesResponseType(typeof(IList<DonationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<DonationDTO>>> GetAllAsync()
        {
            //return Ok(); //returns an ActionResult of IList<DonationDTO>

            var donations = await _context.Donations
               .Select(donation => new DonationDTO
               {
                   Id = donation.Id,
                   DonorName = donation.Donor.Name,
                   ProductName = donation.Product.Name,
                   Quantity = donation.Quantity,
                   ExpirationDate = donation.ExpirationDate,
                   StatusName = donation.Status.Name,
               }).ToListAsync();

            return Ok(donations);
        }

        //We are defining the endpoint for retrieving a specific the Donation data
        [ProducesResponseType(typeof(DonationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<DonationDTO>> GetAsync(int id)
        {
            //return Ok(); //returns an ActionResult of DonationDTO

            var donationDTO = await _context.Donations
                .Select(donation => new DonationDTO
                {
                    Id = donation.Id,
                    DonorName = donation.Donor.Name,
                    ProductName = donation.Product.Name,
                    Quantity = donation.Quantity,
                    ExpirationDate = donation.ExpirationDate,
                    StatusName = donation.Status.Name,
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if (donationDTO == null)
            {
                return NotFound();
            }

            return Ok(donationDTO);
        }

        //We are defining the endpoint for creating a new Donation
        [ProducesResponseType(typeof(DonationDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<DonationDetailDTO>> CreateAsync(CreateDonationDTO createDonationDTO) // It takes and input a CreateDonationDTO
        {
            //return Ok(); //returns an ActionResult of DonationDetailDTO

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donation = new Donation()
            {
                DonorId = createDonationDTO.DonorId,
                ProductId = createDonationDTO.ProductId,
                Quantity = createDonationDTO.Quantity,
                ExpirationDate = createDonationDTO.ExpirationDate,
                StatusId = createDonationDTO.StatusId,
            };

            _context.Add(donation);
            await _context.SaveChangesAsync();

            var donationEntityDTO = new DonationDetailDTO()
            {
                Id = donation.Id,
                DonorId = createDonationDTO.DonorId,
                ProductId = createDonationDTO.ProductId,
                Quantity = createDonationDTO.Quantity,
                ExpirationDate = createDonationDTO.ExpirationDate,
                StatusId = createDonationDTO.StatusId,
            };

            return Ok(donationEntityDTO);
        }

        //We are defining the endpoint for editing/updating an existing Donation
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditDonationDTO editDonationDTO) //It takes and input an id to identify the entity we need to update and EditDonationDTO that holds DonationData
        {
            //return Ok(); //returns an ActionResult

            if (id != editDonationDTO.Id)
            {
                return BadRequest("Mismatched Donation ID");
            }

            var donation = await _context.Donations
                .FirstOrDefaultAsync(b => b.Id == editDonationDTO.Id);

            if (donation == null)
            {
                return NotFound();
            }

            donation.DonorId = editDonationDTO.DonorId;
            donation.ProductId = editDonationDTO.ProductId;
            donation.Quantity = editDonationDTO.Quantity;
            donation.ExpirationDate = editDonationDTO.ExpirationDate;
            donation.StatusId = editDonationDTO.StatusId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //We are defining the endpoint for deleting an existing Donation
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]

        public async Task<ActionResult> DeleteAsync(int id) //It takes and input an id to identify the entity we need to delete
        {
            //return Ok(); //returns an ActionResult

            var donation = await _context.Donations
                .FindAsync(id);

            if (donation == null)
            {
                return NotFound();
            }

            _context.Donations.Remove(donation);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
