using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Entities;
using Api.Dtos;

namespace Api.Controllers;

public class ProductoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProductoDto>>> Get()
    {
        var producto = await unitofwork.Productos.GetAllAsync();
        return mapper.Map<List<ProductoDto>>(producto);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoDto>> Get(int id)
    {
        var producto = await unitofwork.Productos.GetByIdAsync(id);
        return mapper.Map<ProductoDto>(producto);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Post(Producto productoDto)
    {
        var producto = this.mapper.Map<Producto>(productoDto);
        this.unitofwork.Productos.Add(producto);
        await unitofwork.SaveAsync();
        if (producto == null){
            return BadRequest();
        }
        productoDto.CodigoProducto = producto.CodigoProducto;
        return CreatedAtAction(nameof(Post), new { id = productoDto.CodigoProducto }, productoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Producto>> Put (int id, [FromBody]Producto productoDto)
    {
        if(productoDto == null)
            return NotFound();

        var producto = this.mapper.Map<Producto>(productoDto);
        unitofwork.Productos.Update(producto);
        await unitofwork.SaveAsync();
        return productoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var producto = await unitofwork.Productos.GetByIdAsync(id);

        // if (producto == null)
        // {
        //     return Notfound();
        // }

        unitofwork.Productos.Remove(producto);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("sinPedidos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductoImgDto>>> GetProductsSinPedidos()
    {
        var sinPedido = await unitofwork.Productos.productosSinPedido();
        return mapper.Map<List<ProductoImgDto>>(sinPedido);
    }
}