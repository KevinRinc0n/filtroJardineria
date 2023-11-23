using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Entities;
using Api.Dtos;

namespace Api.Controllers;

public class DetallePedidoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public DetallePedidoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DetallePedidoDto>>> Get()
    {
        var detallePedido = await unitofwork.DetallePedidos.GetAllAsync();
        return mapper.Map<List<DetallePedidoDto>>(detallePedido);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetallePedidoDto>> Get(int id)
    {
        var detallePedido = await unitofwork.DetallePedidos.GetByIdAsync(id);
        return mapper.Map<DetallePedidoDto>(detallePedido);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallePedido>> Post(DetallePedido detallePedidoDto)
    {
        var detallePedido = this.mapper.Map<DetallePedido>(detallePedidoDto);
        this.unitofwork.DetallePedidos.Add(detallePedido);
        await unitofwork.SaveAsync();
        if (detallePedido == null){
            return BadRequest();
        }
        detallePedidoDto.CodigoProducto = detallePedido.CodigoProducto;
        return CreatedAtAction(nameof(Post), new { id = detallePedidoDto.CodigoProducto }, detallePedidoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DetallePedido>> Put (int id, [FromBody]DetallePedido detallePedidoDto)
    {
        if(detallePedidoDto == null)
            return NotFound();

        var detallePedido = this.mapper.Map<DetallePedido>(detallePedidoDto);
        unitofwork.DetallePedidos.Update(detallePedido);
        await unitofwork.SaveAsync();
        return detallePedidoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var detallePedido = await unitofwork.DetallePedidos.GetByIdAsync(id);

        // if (detallePedido == null)
        // {
        //     return Notfound();
        // }

        unitofwork.DetallePedidos.Remove(detallePedido);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}