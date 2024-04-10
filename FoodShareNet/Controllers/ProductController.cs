using Microsoft.AspNetCore.Mvc;
using FoodShareNetAPI.DTO.Product;
using FoodShareNet.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FoodShareNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase //inherit from ControllerBase class
    {
        public ProductController()
        {

        }

        // We are defining the endpoint for retrieving all the Product data
        [ProducesResponseType(typeof(IList<ProductDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<IList<ProductDTO>>> GetAllAsync()
        {
            return Ok(); //returns an ActionResult of IList<ProductDTO>
        }

        //We are defining the endpoint for retrieving a specific the Product data
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public async Task<ActionResult<ProductDTO>> GetAsync()
        {
            return Ok(); //returns an ActionResult of ProductDTO
        }

        //We are defining the endpoint for creating a new Product
        [ProducesResponseType(typeof(ProductDetailDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task<ActionResult<ProductDetailDTO>> CreateAsync(CreateProductDTO createProductDTO) // It takes and input a CreateProductDTO
        {
            return Ok(); //returns an ActionResult of ProductDetailDTO
        }

        //We are defining the endpoint for editing/updating an existing Product
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]

        public async Task<ActionResult> EditAsync(int id, EditProductDTO editProductDTO) //It takes and input an id to identify the entity we need to update and EditProductDTO that holds ProductData
        {
            return Ok(); //returns an ActionResult
        }

        //We are defining the endpoint for deleting an existing Product
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
