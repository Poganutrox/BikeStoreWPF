using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CapaEntidades;

///<author> Miguel Ángel Moreno García</author>
[Table("categories", Schema = "production")]
public partial class Category : IDisposable
{
    private bool disposedValue;

    [Key]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("category_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string CategoryName { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public Category() { }

    //Constructor con todos los parámetros
    public Category(int categoryId, string categoryName, ICollection<Product> products)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
        Products = products;
    }

    //Constructor obligatorio
    public Category(string categoryName)
    {
        CategoryName = categoryName;
    }

    //ToString()
    public override string ToString()
    {
        return $"{CategoryId}#{CategoryName}#{Products.Count}";
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: eliminar el estado administrado (objetos administrados)
            }

            // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
            // TODO: establecer los campos grandes como NULL
            disposedValue = true;
        }
    }

    // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
    // ~Category()
    // {
    //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
