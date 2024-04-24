using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Donor;
using FoodShareNet.Domain.Entities;
using FoodShareNet.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DonorController : ControllerBase //inherit from ControllerBase class
    {
        private readonly FoodShareNetDbContext _context;
        public DonorController(FoodShareNetDbContext context)
        {
            _context = context;
        }

        // We are defining the endpoint for retrieving all the Donor data
        [ProducesResponseType(typeof(IList<DonorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<DonorDTO>>> GetAllAsync()
        {
            //return Ok(); //returns an ActionResult of IList<DonorDTO>

            var donors = await _context.Donors
                .Select(donor => new DonorDTO
                {
                    Id = donor.Id,
                    Name = donor.Name,
                    CityName = donor.City.Name,
                    Address = donor.Address,
                    DonationsId = donor.Donations.Select(d => d.Id).ToList(),
                }).ToListAsync();

            return Ok(donors);
        }

        //We are defining the endpoint for retrieving a specific the Donor data
        [ProducesResponseType(typeof(DonorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<DonorDTO>> GetAsync(int id)
        {
            //return Ok(); //returns an ActionResult of DonorDTO

            var donorDTO = await _context.Donors
                .Select(donor => new DonorDTO
                {
                    Id = donor.Id,
                    Name = donor.Name,
                    CityName = donor.City.Name,
                    Address = donor.Address,
                    DonationsId = donor.Donations.Select(d => d.Id).ToList(),
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if (donorDTO == null)
            {
                return NotFound();
            }

            return Ok(donorDTO);
        }

        //We are defining the endpoint for creating a new Donor
        [ProducesResponseType(typeof(DonorDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<DonorDetailDTO>> CreateAsync(CreateDonorDTO createDonorDTO) // It takes and input a CreateDonorDTO
        {
            //return Ok(); //returns an ActionResult of DonorDetailDTO

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donor = new Donor()
            {
                Name = createDonorDTO.Name,
                CityId = createDonorDTO.CityId,
                Address = createDonorDTO.Address,
                //DonationsId = createDonorDTO.DonationsId,
            };

            _context.Add(donor);
            await _context.SaveChangesAsync();

            var donorEntityDTO = new DonorDetailDTO()
            {
                Id = donor.Id,
                Name = createDonorDTO.Name,
                CityId = createDonorDTO.CityId,
                Address = createDonorDTO.Address,
                //DonationsId = createDonorDTO.DonationsId,
            };

            return Ok(donorEntityDTO);
        }

        //We are defining the endpoint for editing/updating an existing Donor
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditDonorDTO editDonorDTO) //It takes and input an id to identify the entity we need to update and EditDonorDTO that holds DonorData
        {
            //return Ok(); //returns an ActionResult

            if (id != editDonorDTO.Id)
            {
                return BadRequest("Mismatched Donor ID");
            }

            var donor = await _context.Donors
                .FirstOrDefaultAsync(b => b.Id == editDonorDTO.Id);

            if (donor == null)
            {
                return NotFound();
            }

            donor.Name = editDonorDTO.Name;
            donor.CityId = editDonorDTO.CityId;
            donor.Address = editDonorDTO.Address;
            //donor.DonationsId = editDonorDTO.DonationsId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //We are defining the endpoint for deleting an existing Donor
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]

        public async Task<ActionResult> DeleteAsync(int id) //It takes and input an id to identify the entity we need to delete
        {
            //return Ok(); //returns an ActionResult

            var donor = await _context.Donors
                .FindAsync(id);

            if (donor == null)
            {
                return NotFound();
            }

            _context.Donors.Remove(donor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
