using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Entities;
using Api.Dtos;

namespace Api.Controllers;

public class PedidoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PedidoDto>>> Get()
    {
        var pedido = await unitofwork.Pedidos.GetAllAsync();
        return mapper.Map<List<PedidoDto>>(pedido);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PedidoDto>> Get(int id)
    {
        var pedido = await unitofwork.Pedidos.GetByIdAsync(id);
        return mapper.Map<PedidoDto>(pedido);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pedido>> Post(Pedido pedidoDto)
    {
        var pedido = this.mapper.Map<Pedido>(pedidoDto);
        this.unitofwork.Pedidos.Add(pedido);
        await unitofwork.SaveAsync();
        if (pedido == null){
            return BadRequest();
        }
        pedidoDto.CodigoPedido = pedido.CodigoPedido;
        return CreatedAtAction(nameof(Post), new { id = pedidoDto.CodigoPedido }, pedidoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pedido>> Put (int id, [FromBody]Pedido pedidoDto)
    {
        if(pedidoDto == null)
            return NotFound();

        var pedido = this.mapper.Map<Pedido>(pedidoDto);
        unitofwork.Pedidos.Update(pedido);
        await unitofwork.SaveAsync();
        return pedidoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var pedido = await unitofwork.Pedidos.GetByIdAsync(id);

        // if (pedido == null)
        // {
        //     return Notfound();
        // }

        unitofwork.Pedidos.Remove(pedido);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}