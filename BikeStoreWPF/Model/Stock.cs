using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace CapaEntidades;

///<author> Miguel Ángel Moreno García</author>
[PrimaryKey("StoreId", "ProductId")]
[Table("stocks", Schema = "production")]
public partial class Stock : IDisposable
{
    private bool disposedValue;

    [Key]
    [Column("store_id")]
    public int StoreId { get; set; }

    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Stocks")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("StoreId")]
    [InverseProperty("Stocks")]
    public virtual Store Store { get; set; } = null!;

    public Stock() { }

    //Constructor con todos los parámetros
    public Stock(int storeId, int productId, int? quantity, Product product, Store store)
    {
        StoreId = storeId;
        ProductId = productId;
        Quantity = quantity;
        Product = product;
        Store = store;

    }

    //Constructor con los parámetros obligatorios
    public Stock(int storeId, int productId)
    {
        StoreId = storeId;
        ProductId = productId;
    }

    public Stock(int storeId, int productId, int? quantity)
    {
        StoreId = storeId;
        ProductId = productId;
        Quantity = quantity;
    }

    //ToString()
    public override string ToString()
    {
        return $"{StoreId}#{ProductId}#{Quantity}#{Product}#{Store}";
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
    // ~Stock()
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
