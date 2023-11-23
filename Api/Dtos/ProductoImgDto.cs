namespace Api.Dtos;

public class ProductoImgDto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public GamaImgDto GamaNavigation { get; set; }
}