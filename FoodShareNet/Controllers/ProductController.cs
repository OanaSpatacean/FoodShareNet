using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Product;
using FoodShareNet.Domain.Entities;
using FoodShareNet.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase //inherit from ControllerBase class
    {
        private readonly FoodShareNetDbContext _context;
        public ProductController(FoodShareNetDbContext context)
        {
            _context = context;
        }

        // We are defining the endpoint for retrieving all the Product data
        [ProducesResponseType(typeof(IList<ProductDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<ProductDTO>>> GetAllAsync()
        {
            //return Ok(); //returns an ActionResult of IList<ProductDTO>

            var products = await _context.Products
               .Select(product => new ProductDTO
               {
                   Id = product.Id,
                   Name = product.Name,
                   Image = product.Image
               }).ToListAsync();

            return Ok(products);
        }

        //We are defining the endpoint for retrieving a specific the Product data
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<ProductDTO>> GetAsync(int id)
        {
            //return Ok(); //returns an ActionResult of ProductDTO

            var productDTO = await _context.Products
                .Select(product => new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.Image
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productDTO == null)
            {
                return NotFound();
            }

            return Ok(productDTO);
        }

        //We are defining the endpoint for creating a new Product
        [ProducesResponseType(typeof(ProductDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<ProductDetailDTO>> CreateAsync(CreateProductDTO createProductDTO) // It takes and input a CreateProductDTO
        {
            //return Ok(); //returns an ActionResult of ProductDetailDTO

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product()
            {
                Name = createProductDTO.Name,
                Image = createProductDTO.Image
            };

            _context.Add(product);
            await _context.SaveChangesAsync();

            var productEntityDTO = new ProductDetailDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Image
            };

            return Ok(productEntityDTO);
        }

        //We are defining the endpoint for editing/updating an existing Product
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditProductDTO editProductDTO) //It takes and input an id to identify the entity we need to update and EditProductDTO that holds ProductData
        {
            //return Ok(); //returns an ActionResult

            if (id != editProductDTO.Id)
            {
                return BadRequest("Mismatched Product ID");
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(b => b.Id == editProductDTO.Id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = editProductDTO.Name;
            product.Image = editProductDTO.Image;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //We are defining the endpoint for deleting an existing Product
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]

        public async Task<ActionResult> DeleteAsync(int id) //It takes and input an id to identify the entity we need to delete
        {
            //return Ok(); //returns an ActionResult

            var product = await _context.Products
                .FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
