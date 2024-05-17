using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CapaEntidades;


///<author> Miguel Ángel Moreno García</author>
[Table("brands", Schema = "production")]
public partial class Brand : IDisposable
{
    private bool disposedValue;

    [Key]
    [Column("brand_id")]
    public int BrandId { get; set; }

    [Column("brand_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string BrandName { get; set; } = null!;

    [InverseProperty("Brand")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public Brand() { }

    //Constructor con todos los parámetros
    public Brand(int brandId, string brandName, ICollection<Product> products)
    {
        BrandId = brandId;
        BrandName = brandName;
        Products = products;
    }
    //Constructor obligatorio
    public Brand(string brandName)
    {
        BrandName = brandName;
    }

    //ToString()
    public override string ToString()
    {
        return $"{BrandId}#{BrandName}#{Products.Count}";
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
    // ~Brand()
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
