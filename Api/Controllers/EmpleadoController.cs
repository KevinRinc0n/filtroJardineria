using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Entities;
using Api.Dtos;

namespace Api.Controllers;

public class EmpleadoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var empleado = await unitofwork.Empleados.GetAllAsync();
        return mapper.Map<List<EmpleadoDto>>(empleado);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var empleado = await unitofwork.Empleados.GetByIdAsync(id);
        return mapper.Map<EmpleadoDto>(empleado);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Post(Empleado empleadoDto)
    {
        var empleado = this.mapper.Map<Empleado>(empleadoDto);
        this.unitofwork.Empleados.Add(empleado);
        await unitofwork.SaveAsync();
        if (empleado == null){
            return BadRequest();
        }
        empleadoDto.CodigoEmpleado = empleado.CodigoEmpleado;
        return CreatedAtAction(nameof(Post), new { id = empleadoDto.CodigoEmpleado }, empleadoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Empleado>> Put (int id, [FromBody]Empleado empleadoDto)
    {
        if(empleadoDto == null)
            return NotFound();

        var empleado = this.mapper.Map<Empleado>(empleadoDto);
        unitofwork.Empleados.Update(empleado);
        await unitofwork.SaveAsync();
        return empleadoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var empleado = await unitofwork.Empleados.GetByIdAsync(id);

        if (empleado == null)
        {
            return Notfound();
        }

        unitofwork.Empleados.Remove(empleado);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}