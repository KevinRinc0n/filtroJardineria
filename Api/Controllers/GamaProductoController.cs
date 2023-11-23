using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Entities;
using Api.Dtos;

namespace Api.Controllers;

public class GamaProductoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public GamaProductoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<GamaProductoDto>>> Get()
    {
        var gamaProducto = await unitofwork.GamaProductos.GetAllAsync();
        return mapper.Map<List<GamaProductoDto>>(gamaProducto);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GamaProductoDto>> Get(int id)
    {
        var gamaProducto = await unitofwork.GamaProductos.GetByIdAsync(id);
        return mapper.Map<GamaProductoDto>(gamaProducto);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GamaProducto>> Post(GamaProducto gamaProductoDto)
    {
        var gamaProducto = this.mapper.Map<GamaProducto>(gamaProductoDto);
        this.unitofwork.GamaProductos.Add(gamaProducto);
        await unitofwork.SaveAsync();
        if (gamaProducto == null){
            return BadRequest();
        }
        gamaProductoDto.Gama = gamaProducto.Gama;
        return CreatedAtAction(nameof(Post), new { id = gamaProductoDto.Gama }, gamaProductoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<GamaProducto>> Put (int id, [FromBody]GamaProducto gamaProductoDto)
    {
        if(gamaProductoDto == null)
            return NotFound();

        var gamaProducto = this.mapper.Map<GamaProducto>(gamaProductoDto);
        unitofwork.GamaProductos.Update(gamaProducto);
        await unitofwork.SaveAsync();
        return gamaProductoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var gamaProducto = await unitofwork.GamaProductos.GetByIdAsync(id);

        // if (gamaProducto == null)
        // {
        //     return Notfound();
        // }

        unitofwork.GamaProductos.Remove(gamaProducto);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}