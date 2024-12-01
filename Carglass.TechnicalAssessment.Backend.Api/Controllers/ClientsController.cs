using Carglass.TechnicalAssessment.Backend.BL.Clients;
using Carglass.TechnicalAssessment.Backend.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Carglass.TechnicalAssessment.Backend.Api.Controllers;

[ApiController]
[Route("clients")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientAppService;

    public ClientsController(IClientService clientAppService)
    {
        this._clientAppService = clientAppService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var clients = _clientAppService.GetAll();
        return Ok(clients);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_clientAppService.GetById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] ClientDto dto)
    {
        _clientAppService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut]
    public IActionResult Update([FromBody] ClientDto dto)
    {
        _clientAppService.Update(dto);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] ClientDto dto)
    {
        _clientAppService.Delete(dto);
        return NoContent();
    }
}