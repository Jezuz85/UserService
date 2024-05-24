﻿using UserService.Core.Entities;

namespace UserService.Core.Dtos;

public class ProductoDTO : BaseEntity
{
    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int UserId { get; set; }
}