using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Carglass.TechnicalAssessment.Api.Controllers;

[ApiController]
[Route("clients")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientAppService)
    {
        _clientService = clientAppService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var clients = _clientService.GetAll();
        return Ok(clients);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_clientService.GetById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] ClientDto dto)
    {
        _clientService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut]
    public IActionResult Update([FromBody] ClientDto dto)
    {
        _clientService.Update(dto);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] ClientDto dto)
    {
        _clientService.Delete(dto);
        return NoContent();
    }
}