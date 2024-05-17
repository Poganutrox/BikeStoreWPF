using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CapaEntidades;

///<author> Miguel Ángel Moreno García</author>
[Table("products", Schema = "production")]
public partial class Product : IDisposable
{
    private bool disposedValue;

    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string ProductName { get; set; } = null!;

    [Column("brand_id")]
    public int BrandId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("model_year")]
    public short ModelYear { get; set; }

    [Column("list_price", TypeName = "decimal(10, 2)")]
    public decimal ListPrice { get; set; }

    [Column("image_product")]
    public byte[]? ImageProduct { get; set; }

    [ForeignKey("BrandId")]
    [InverseProperty("Products")]
    public virtual Brand Brand { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Product")]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public Product() { }

    //Constructor con todos los parámetros
    public Product(int productId, string productName, int brandId, int categoryId, short modelYear, decimal listPrice, 
        byte[]? imageProduct, Brand brand, Category category, ICollection<OrderItem> orderItems, ICollection<Stock> stocks)
    {
        ProductId = productId;
        ProductName = productName;
        BrandId = brandId;
        CategoryId = categoryId;
        ModelYear = modelYear;
        ListPrice = listPrice;
        ImageProduct = imageProduct;
        Brand = brand;
        Category = category;
        OrderItems = orderItems;
        Stocks = stocks;
    }

    //Constructor con los parámetros obligatorios
    public Product(int productId, string productName, int brandId, int categoryId, short modelYear, decimal listPrice)
    {
        ProductId = productId;
        ProductName = productName;
        BrandId = brandId;
        CategoryId = categoryId;
        ModelYear = modelYear;
        ListPrice = listPrice;
    }

    public int CompareTo(Product? other)
    {
        if (other == null) return 1;

        int categoryComparison = String.Compare(Category.CategoryName, other.Category.CategoryName, StringComparison.OrdinalIgnoreCase);
        if (categoryComparison != 0)
        {
            return categoryComparison;
        }

        return String.Compare(ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);
    }

    //ToString()
    public override string ToString()
    {
        return $"{ProductId}#{ProductName}#{BrandId}#{CategoryId}#{ModelYear}#{ListPrice}#{ImageProduct}#{Brand}#" +
            $"{Category}#{OrderItems.Count}#{Stocks.Count}";
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
    // ~Product()
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
