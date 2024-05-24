namespace UserService.Core.Entities;

public class Producto : BaseEntity
{
    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int UserId { get; set; }

    public Users? Users { get; set; }
}