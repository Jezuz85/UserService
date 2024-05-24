namespace UserService.Core.Entities;

public class Users : BaseEntity
{
    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Email { get; set; }

    public int Edad { get; set; }

    public ICollection<Producto> Productos { get; set; }
}