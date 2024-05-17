using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CapaEntidades;

///<author> Miguel Ángel Moreno García</author>
[Table("stores", Schema = "sales")]
public partial class Store : IDisposable
{
    private bool disposedValue;

    [Key]
    [Column("store_id")]
    public int StoreId { get; set; }

    [Column("store_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string StoreName { get; set; } = null!;

    [Column("phone")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("street")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Street { get; set; }

    [Column("city")]
    [StringLength(255)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("state")]
    [StringLength(10)]
    [Unicode(false)]
    public string? State { get; set; }

    [Column("zip_code")]
    [StringLength(5)]
    [Unicode(false)]
    public string? ZipCode { get; set; }

    [InverseProperty("Store")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Store")]
    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    [InverseProperty("Store")]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public Store() { }

    //Constructor con todos los parámetros
    public Store(int storeId, string storeName, string? phone, string? email, string? street, string? city, string? 
        state, string? zipCode, ICollection<Order> orders, ICollection<Staff> staffs, ICollection<Stock> stocks)
    {
        StoreId = storeId;
        StoreName = storeName;
        Phone = phone;
        Email = email;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Orders = orders;
        Staff = staffs;
        Stocks = stocks;

    }

    //Constructor con los parámetros obligatorios
    public Store(string storeName)
    {
        StoreName = storeName;
    }

    //ToString()
    public override string ToString()
    {
        return $"{StoreId}#{StoreName}#{Phone}#{Email}#{Street}#{City}#{State}#{ZipCode}#" +
            $"{Orders.Count}#{Staff.Count}#{Stocks.Count}";
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
    // ~Store()
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
