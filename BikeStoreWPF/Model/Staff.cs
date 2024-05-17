using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace CapaEntidades;

///<author> Miguel Ángel Moreno García</author>
[Table("staffs", Schema = "sales")]
[Index("Email", Name = "UQ__staffs__AB6E6164B5EF9AB8", IsUnique = true)]
public partial class Staff : IDisposable
{
    private bool disposedValue;

    [Key]
    [Column("staff_id")]
    public int StaffId { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("phone")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("active")]
    public byte Active { get; set; }

    [Column("store_id")]
    public int StoreId { get; set; }

    [Column("manager_id")]
    public int? ManagerId { get; set; }

    [Column("password_staff")]
    [StringLength(64)]
    public string PasswordStaff { get; set; } = null!;

    [Column("image_staff")]
    public byte[]? ImageStaff { get; set; }

    [InverseProperty("Manager")]
    public virtual ICollection<Staff> InverseManager { get; set; } = new List<Staff>();

    [ForeignKey("ManagerId")]
    [InverseProperty("InverseManager")]
    public virtual Staff? Manager { get; set; }

    [InverseProperty("Staff")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("StoreId")]
    [InverseProperty("Staff")]
    public virtual Store Store { get; set; } = null!;

    public Staff() { }

    //Constructor con todos los parámetros
    public Staff(int staffId, string firstName, string lastName, string email, string? phone, 
        byte active, int storeId, int? managerId, string passwordStaff, byte[]? imageStaff, ICollection<Staff> inverseManager,
        Staff? manager, ICollection<Order> orders, Store store)
    {
        StaffId = staffId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Active = active;
        StoreId = storeId;
        ManagerId = managerId;
        PasswordStaff = passwordStaff;
        ImageStaff = imageStaff;
        InverseManager = inverseManager;
        Manager = manager;
        Orders = orders;
        Store = store;
    }

    //Constructor con los parámetros obligatorios
    public Staff(int staffId, string firstName, string lastName, string email, byte active, int storeId, 
        string passwordStaff)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Active = active;
        StoreId = storeId;
        PasswordStaff = passwordStaff;
    }

    //Constructor para hacer los inserts en la base de datos
    public Staff(string firstName, string lastName, string passwordStaff,string email, string telefono, byte active, int storeId,
        byte[]? imageStaff, int? managerId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = telefono;
        Active = active;
        StoreId = storeId;
        PasswordStaff = passwordStaff;
        ImageStaff = imageStaff;
        ManagerId = managerId;
    }

    //ToString()
    public override string ToString()
    {
        return StaffId + "#" + FirstName + "#" + LastName + "#" + Email + "#" + Phone + "#" +
            Active + "#" + StoreId + "#" + ManagerId + "#" + PasswordStaff + "#" + ImageStaff + "#" +
            InverseManager.Count + "#" + Manager + "#" + Orders.Count + "#" + Store;
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
    // ~Staff()
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
