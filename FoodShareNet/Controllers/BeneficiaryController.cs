using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Beneficiary;
using FoodShareNet.Domain.Entities;
using FoodShareNet.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BeneficiaryController : ControllerBase //inherit from ControllerBase class
    {
        private readonly FoodShareNetDbContext _context;
        public BeneficiaryController(FoodShareNetDbContext context)
        {
            _context = context;
        }

        // We are defining the endpoint for retrieving all the Beneficiary data
        [ProducesResponseType(typeof(IList<BeneficiaryDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<BeneficiaryDTO>>> GetAllAsync()
        {
            //return Ok(); //returns an ActionResult of IList<BeneficiaryDTO>

            var beneficiaries = await _context.Beneficiaries
                .Include(b => b.City)
                .Select(b => new BeneficiaryDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Address = b.Address,
                    CityName = b.City.Name,
                    Capacity = b.Capacity,
                }).ToListAsync();

            return Ok(beneficiaries);
        }

        //We are defining the endpoint for retrieving a specific the Beneficiary data
        [ProducesResponseType(typeof(BeneficiaryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<BeneficiaryDTO>> GetAsync(int? id)
        {
            //return Ok(); //returns an ActionResult of BeneficiaryDTO

            var beneficiaryDTO = await _context.Beneficiaries
                .Select(b => new BeneficiaryDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Address = b.Address,
                    CityName = b.City.Name,
                    Capacity = b.Capacity,
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if(beneficiaryDTO == null)
            {
                return NotFound();
            }

            return Ok(beneficiaryDTO);
        }

        //We are defining the endpoint for creating a new Beneficiary
        [ProducesResponseType(typeof(BeneficiaryDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<BeneficiaryDetailDTO>> CreateAsync(CreateBeneficiaryDTO createBeneficiaryDTO) // It takes and input a CreateBeneficiaryDTO
        {
            //return Ok(); //returns an ActionResult of BeneficiaryDetailDTO

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var beneficiary = new Beneficiary()
            {
                Name = createBeneficiaryDTO.Name,
                Address = createBeneficiaryDTO.Address,
                CityId = createBeneficiaryDTO.CityId,
                Capacity = createBeneficiaryDTO.Capacity,
            };

            _context.Add(beneficiary);
            await _context.SaveChangesAsync();

            var beneficiaryEntityDTO = new BeneficiaryDetailDTO()
            {
                Id = beneficiary.Id,
                Name = beneficiary.Name,
                Address = beneficiary.Address,
                CityId = beneficiary.CityId,
                Capacity = beneficiary.Capacity,
            };

            return Ok(beneficiaryEntityDTO);
        }

        //We are defining the endpoint for editing/updating an existing Beneficiary
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditBeneficiaryDTO editBeneficiaryDTO) //It takes and input an id to identify the entity we need to update and EditBeneficiaryDTO that holds BeneficiaryData
        {
            //return Ok(); //returns an ActionResult

            if(id != editBeneficiaryDTO.Id)
            {
                return BadRequest("Mismatched Beneficiary ID");
            }

            var beneficiary = await _context.Beneficiaries
                .FirstOrDefaultAsync(b => b.Id == editBeneficiaryDTO.Id);
            
            if (beneficiary == null)
            {
                return NotFound();
            }

            beneficiary.Name = editBeneficiaryDTO.Name;
            beneficiary.Address = editBeneficiaryDTO.Address;
            beneficiary.CityId = editBeneficiaryDTO.CityId;
            beneficiary.Capacity = editBeneficiaryDTO.Capacity;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //We are defining the endpoint for deleting an existing Beneficiary
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]

        public async Task<ActionResult> DeleteAsync(int id) //It takes and input an id to identify the entity we need to delete
        {
            //return Ok(); //returns an ActionResult

            var beneficiary = await _context.Beneficiaries
                .FindAsync(id);

            if(beneficiary == null)
            {
                return NotFound();
            }

            _context.Beneficiaries.Remove(beneficiary);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
