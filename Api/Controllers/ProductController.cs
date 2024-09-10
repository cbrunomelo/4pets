using Application.Dtos;
using Application.Messaging;
using Application.Services;
using Domain.Commands.HistoryCommands;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(IProductRepository productRepository
                                ,IHandler<CreateHistoryCommand> historyHandler
                                ,ICategoryRepository categoryRepo)
        {
            _productService = new ProductService(productRepository, historyHandler, categoryRepo);
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IResultService> Get()
        {
            var productDto = new ProductDto
            (1,
            "Product 1",
            "Description",
            10.5m,
            1);
            return Ok(new ResultService(true,"Success", productDto));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<IResultService> Get(int id)
        {
            try
            {
                var result = _productService.GetProductById(id);
                if (result.Sucess)
                    return Ok(result);
                return NotFound(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultService(false, "Falha Interna", "001x00"));
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<IResultService> Post([FromBody] ProductDto newProduct)
        {
            try
            { 
                // usuario vem do token, depois eu implemento
                var usuarioId = 2;
                var result = _productService.CreateProduct(newProduct, usuarioId);
                if(result.Sucess)            
                    return Created($"/api/product/{(result.Data as ProductDto)?.Id }", result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultService(false, "Falha Interna", "001x00"));
            }

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
