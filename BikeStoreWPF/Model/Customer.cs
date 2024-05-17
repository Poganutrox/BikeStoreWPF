using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CapaEntidades;

///<author> Miguel Ángel Moreno García</author>
[Table("customers", Schema = "sales")]
public partial class Customer : IDisposable
{
    private bool disposedValue;

    [Key]
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("first_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("phone")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("street")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Street { get; set; }

    [Column("city")]
    [StringLength(50)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("state")]
    [StringLength(25)]
    [Unicode(false)]
    public string? State { get; set; }

    [Column("zip_code")]
    [StringLength(5)]
    [Unicode(false)]
    public string? ZipCode { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public Customer() { }

    //Constructor con todos los parámetros
    public Customer(int customerId, string firstName, string lastName, string? phone, string email, 
        string? street, string? city, string? state, string? zipCode, ICollection<Order> orders)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Orders = orders;
    }

    //Constructor con los parámetros obligatorios
    public Customer(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    //ToString()
    public override string ToString()
    {
        return $"{CustomerId}#{FirstName}#{LastName}#{Phone}#{Email}#{Street}#{City}#{State}#{ZipCode}#{Orders.Count}";
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
    // ~Customer()
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
