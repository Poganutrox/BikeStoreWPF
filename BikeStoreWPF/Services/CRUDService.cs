using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreWPF.Services
{
    public class CRUDService
    {
        public static IList<Product> ListarProductos()
        {
            return ProductDAO.Listar();

        }
        public static IList<Brand> ListarBrands()
        {
            return BrandDAO.Listar();

        }
        public static IList<Category> ListarCategories()
        {
            return CategoryDAO.Listar();

        }

        public void InsertarProducto(Product product)
        {
            using(var productDAO = new ProductDAO())
            {
                productDAO.Insertar(product);
            }
        }
        public void ActualizarProducto(Product product)
        {
            using (var productDAO = new ProductDAO())
            {
                productDAO.Actualizar(product);
            }
        }
        public void BorrarProducto(Product product)
        {
            using (var productDAO = new ProductDAO())
            {
                productDAO.Borrar(product);
            }
        }
    }
}
