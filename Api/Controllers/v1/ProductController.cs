using Api.Extension;
using Application.Dtos;
using Application.Messaging;
using Application.Services;
using Domain.Commands.HistoryCommands;
using Domain.Handlers.Contracts;
using Domain.Queries;
using Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;

namespace Api.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductController(IProductRepository productRepository
                            ,IMediator mediator
                            ,IProductQuery productQuery)
    {
        _productService = new ProductService(productRepository
                                             ,mediator
                                             ,productQuery);
    }

    // GET: api/<ProductController>
    [HttpGet]
    public ActionResult<IResultService<IEnumerable<ProductDto>>> Get(
        int page = 1,
        int pageSize = 10
        )
    {
        var pag = new PaginacaoDto(page, pageSize);
        string token = "";
        int userId = token.GetUserId();
        var result = _productService.GetAll(pag);
        if (result.Sucess)
            return Ok(result);
        return BadRequest(result);
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public ActionResult<IResultService<ProductDto>> Get(
        [FromRoute] int id
        )
    {
        string token = "";
        int userId = token.GetUserId();
        var result = _productService.GetById(id, userId);
        if (result.Sucess)
            return Ok(result);
        return NotFound(result);        
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<ActionResult<IResultService<ProductDto>>> Post([FromBody] ProductDto newProduct)
    {

     // usuario vem do token, depois eu implemento
     var usuarioId = 2;
     var result =await _productService.Create(newProduct, usuarioId);
     if (result.Sucess)
         return Created($"/api/product/{(result.Data as ProductDto)?.Id}", result);
     return BadRequest(result);
        
    }

    // PUT api/<ProductController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult<IResultService<ProductDto>>> Put(int id, [FromBody] ProductDto product)
    {
     // usuario vem do token, depois eu implemento
     var usuarioId = 2;
     var result =await _productService.Update(product, usuarioId);
     if (result.Sucess)
         return Ok(result);

     return BadRequest(result);        
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {

        // usuario vem do token, depois eu implemento
        var usuarioId = 2;
        var result = _productService.Delete(id, usuarioId);
        if (result.Sucess)
            StatusCode(StatusCodes.Status204NoContent);
        else
            StatusCode(StatusCodes.Status400BadRequest);

    }
}

