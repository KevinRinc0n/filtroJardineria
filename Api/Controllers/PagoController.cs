using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Entities;
using Api.Dtos;

namespace Api.Controllers;

public class PagoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PagoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PagoDto>>> Get()
    {
        var pago = await unitofwork.Pagos.GetAllAsync();
        return mapper.Map<List<PagoDto>>(pago);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PagoDto>> Get(int id)
    {
        var pago = await unitofwork.Pagos.GetByIdAsync(id);
        return mapper.Map<PagoDto>(pago);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pago>> Post(Pago pagoDto)
    {
        var pago = this.mapper.Map<Pago>(pagoDto);
        this.unitofwork.Pagos.Add(pago);
        await unitofwork.SaveAsync();
        if (pago == null){
            return BadRequest();
        }
        pagoDto.CodigoCliente = pago.CodigoCliente;
        return CreatedAtAction(nameof(Post), new { id = pagoDto.CodigoCliente }, pagoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pago>> Put (int id, [FromBody]Pago pagoDto)
    {
        if(pagoDto == null)
            return NotFound();

        var pago = this.mapper.Map<Pago>(pagoDto);
        unitofwork.Pagos.Update(pago);
        await unitofwork.SaveAsync();
        return pagoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var pago = await unitofwork.Pagos.GetByIdAsync(id);

        // if (pago == null)
        // {
        //     return Notfound();
        // }

        unitofwork.Pagos.Remove(pago);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("paypal2008")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PagoDto>>> GetPaypal2008()
    {
        var paypal2008 = await unitofwork.Pagos.paypal2008();
        return mapper.Map<List<PagoDto>>(paypal2008);
    }

    [HttpGet("formasPago")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<string>>> GetFormasPago()
    {
        var formasDePago = await unitofwork.Pagos.formasPago();
        return mapper.Map<List<string>>(formasDePago);
    }
}