using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Entities;
using Api.Dtos;

namespace Api.Controllers;

public class OficinaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public OficinaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<OficinaDto>>> Get()
    {
        var oficina = await unitofwork.Oficinas.GetAllAsync();
        return mapper.Map<List<OficinaDto>>(oficina);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OficinaDto>> Get(int id)
    {
        var oficina = await unitofwork.Oficinas.GetByIdAsync(id);
        return mapper.Map<OficinaDto>(oficina);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Oficina>> Post(Oficina oficinaDto)
    {
        var oficina = this.mapper.Map<Oficina>(oficinaDto);
        this.unitofwork.Oficinas.Add(oficina);
        await unitofwork.SaveAsync();
        if (oficina == null){
            return BadRequest();
        }
        oficinaDto.CodigoOficina = oficina.CodigoOficina;
        return CreatedAtAction(nameof(Post), new { id = oficinaDto.CodigoOficina }, oficinaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Oficina>> Put (int id, [FromBody]Oficina oficinaDto)
    {
        if(oficinaDto == null)
            return NotFound();

        var oficina = this.mapper.Map<Oficina>(oficinaDto);
        unitofwork.Oficinas.Update(oficina);
        await unitofwork.SaveAsync();
        return oficinaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var oficina = await unitofwork.Oficinas.GetByIdAsync(id);

        if (oficina == null)
        {
            return Notfound();
        }

        unitofwork.Oficinas.Remove(oficina);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}