using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CapaEntidades;

///<author> Miguel Ángel Moreno García</author>
[PrimaryKey("OrderId", "ItemId")]
[Table("order_items", Schema = "sales")]
public partial class OrderItem : IDisposable
{
    private bool disposedValue;

    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("list_price", TypeName = "decimal(10, 2)")]
    public decimal ListPrice { get; set; }

    [Column("discount", TypeName = "decimal(4, 2)")]
    public decimal Discount { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product Product { get; set; } = null!;

    public OrderItem() { }

    //Constructor con todos los parámetros (todos los atributos son obligatorios)
    public OrderItem(int orderId, int itemId, int productId, int quantity, decimal listPrice, 
        decimal discount, Order order, Product product)
    {
        OrderId = orderId;
        ItemId = itemId;
        ProductId = productId;
        Quantity = quantity;
        ListPrice = listPrice;
        Discount = discount;
        Order = order;
        Product = product;
    }

    //Constructor con todos los parámetros obligatorios
    public OrderItem(int orderId, int itemId, int productId, int quantity, decimal listPrice,
        decimal discount)
    {
        OrderId = orderId;
        ItemId = itemId;
        ProductId = productId;
        Quantity = quantity;
        ListPrice = listPrice;
        Discount = discount;
    }

    //ToString()
    public override string ToString()
    {
        return $"{OrderId}#{ItemId}#{ProductId}#{Quantity}#{ListPrice}#{Discount}#{Order}#{Product}";
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
    // ~OrderItem()
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
