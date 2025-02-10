using Api.Extension;
using Application.Dtos;
using Application.Messaging;
using Application.Services;
using Domain.Commands.HistoryCommands;
using Domain.Handlers.Contracts;
using Domain.Queries;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductController(IProductRepository productRepository
                            , IHandler<CreateHistoryCommand> historyHandler
                            , ICategoryRepository categoryRepo
                            , IProductQuery productQuery)
    {
        _productService = new ProductService(productRepository
                                             , historyHandler
                                             , categoryRepo
                                             , productQuery);
    }

    // GET: api/<ProductController>
    [HttpGet]
    public ActionResult<IResultService<IEnumerable<ProductDto>>> Get()
    {
        var productDto = new ProductDto
        (1,
        "Product 1",
        "Description",
        10.5m,
        1);
        return Ok(new ResultService<ProductDto>(true, "Success", productDto));
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public ActionResult<IResultService<ProductDto>> Get(
        [FromRoute] int id
        )
    {
        try
        {
            string token = "";
            int userId = token.GetUserId();
            var result = _productService.GetById(id, userId);
            if (result.Sucess)
                return Ok(result);
            return NotFound(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResultService<ProductDto>(false, "Falha Interna", "001x00"));
        }
    }

    // POST api/<ProductController>
    [HttpPost]
    public ActionResult<IResultService<ProductDto>> Post([FromBody] ProductDto newProduct)
    {
        try
        {
            // usuario vem do token, depois eu implemento
            var usuarioId = 2;
            var result = _productService.CreateProduct(newProduct, usuarioId);
            if (result.Sucess)
                return Created($"/api/product/{(result.Data as ProductDto)?.Id}", result);
            return BadRequest(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResultService<ProductDto>(false, "Falha Interna", "001x00"));
        }

    }

    // PUT api/<ProductController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] ProductDto product)
    {
        try
        {
            // usuario vem do token, depois eu implemento
            var usuarioId = 2;
            var result = _productService.UpdateProduct(product, usuarioId);
            if (result.Sucess)
                Ok(result);
            BadRequest(result);
        }
        catch (Exception ex)
        {
            StatusCode(StatusCodes.Status500InternalServerError, new ResultService<ProductDto>(false, "Falha Interna", "001x00"));

        }
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

