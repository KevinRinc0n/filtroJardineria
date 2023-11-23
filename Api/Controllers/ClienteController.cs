using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Entities;
using Api.Dtos;

namespace Api.Controllers;

public class ClienteController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var cliente = await unitofwork.Clientes.GetAllAsync();
        return mapper.Map<List<ClienteDto>>(cliente);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var cliente = await unitofwork.Clientes.GetByIdAsync(id);
        return mapper.Map<ClienteDto>(cliente);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post(Cliente ClienteDto)
    {
        var cliente = this.mapper.Map<Cliente>(ClienteDto);
        this.unitofwork.Clientes.Add(cliente);
        await unitofwork.SaveAsync();
        if (cliente == null){
            return BadRequest();
        }
        ClienteDto.CodigoCliente = cliente.CodigoCliente;
        return CreatedAtAction(nameof(Post), new { id = ClienteDto.CodigoCliente }, ClienteDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Cliente>> Put (int id, [FromBody]Cliente clienteDto)
    {
        if(clienteDto == null)
            return NotFound();

        var cliente = this.mapper.Map<Cliente>(clienteDto);
        unitofwork.Clientes.Update(cliente);
        await unitofwork.SaveAsync();
        return clienteDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var cliente = await unitofwork.Clientes.GetByIdAsync(id);

        // if (cliente == null)
        // {
        //     return Notfound();
        // }

        unitofwork.Clientes.Remove(cliente);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("clientePagoYRepresentante")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteeDto>>> GetPagoYRepresentantes()
    {
        var pagosYRepresentante = await unitofwork.Clientes.clientePagosYRepresentante();
        return mapper.Map<List<ClienteeDto>>(pagosYRepresentante);
    }

    [HttpGet("sinPagos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetSinPagos()
    {
        var clientesSinPagos = await unitofwork.Clientes.sinPagos();
        return mapper.Map<List<ClienteDto>>(clientesSinPagos);
    }

    [HttpGet("clientess")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteRepDto>>> Getclientess()
    {
        var clientts = await unitofwork.Clientes.clientess();
        return mapper.Map<List<ClienteRepDto>>(clientts);
    }

    [HttpGet("sinPagos2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteRep2Dto>>> GetSinPagos2()
    {
        var clientesSinPagos2 = await unitofwork.Clientes.sinPagos2();
        return mapper.Map<List<ClienteRep2Dto>>(clientesSinPagos2);
    }
}