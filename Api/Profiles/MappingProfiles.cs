using Api.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace Api.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Cliente, ClienteDto>().ReverseMap();

        CreateMap<DetallePedido, DetallePedidoDto>().ReverseMap();

        CreateMap<Empleado, EmpleadoDto>().ReverseMap();

        CreateMap<GamaProducto, GamaProductoDto>().ReverseMap();

        CreateMap<Oficina, OficinaDto>().ReverseMap();

        CreateMap<Pago, PagoDto>().ReverseMap();

        CreateMap<Pedido, PedidoDto>().ReverseMap();

        CreateMap<Producto, ProductoDto>().ReverseMap();

        CreateMap<Cliente, ClienteeDto>().ReverseMap();

        CreateMap<Producto, ProductoImgDto>().ReverseMap();

        CreateMap<GamaProducto, GamaImgDto>().ReverseMap();

        CreateMap<Cliente, ClienteRepDto>().ReverseMap();

        CreateMap<Oficina, OficinaCiuDto>().ReverseMap();

        CreateMap<Empleado, EmpleadoRepDto>().ReverseMap();

        CreateMap<Cliente, ClienteRep2Dto>().ReverseMap();

        CreateMap<Oficina, OficinaTelDto>().ReverseMap();

        CreateMap<Empleado, EmpleadoRep2Dto>().ReverseMap();
    }
}