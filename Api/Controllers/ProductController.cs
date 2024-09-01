using Application.Dtos;
using Application.Messaging;
using Application.Services;
using Domain.Commands.HistoryCommands;
using Domain.Handlers.Contracts;
using Domain.Repository;
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
                                ,IHandler<CreateHistoryCommand> historyHandler)
        {
            _productService = new ProductService(productRepository, historyHandler);
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
        public string Get(int id)
        {
            throw new Exception();            
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<IResultService> Post([FromBody] ProductDto newProduct)
        {
            // usuario vem do token, depois eu implemento
            var usuarioId = 2;
            var result = _productService.CreateProduct(newProduct, usuarioId);
            if(result.Sucess)            
                return Ok(result);
            return BadRequest(result);
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
