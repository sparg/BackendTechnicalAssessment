using Carglass.TechnicalAssessment.Backend.BL.Products;
using Carglass.TechnicalAssessment.Backend.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Carglass.TechnicalAssessment.Backend.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        this._productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_productService.GetById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductDto dto)
    {
        _productService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut]
    public IActionResult Update([FromBody] ProductDto dto)
    {
        _productService.Update(dto);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] ProductDto dto)
    {
        _productService.Delete(dto);
        return NoContent();
    }
}