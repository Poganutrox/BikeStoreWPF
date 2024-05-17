using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{

    ///<author> Miguel Ángel Moreno García</author>
    public class OrderItemDAO : IDisposable
    {
        private bool disposedValue;

        public static IList<OrderItem> Listar()
        {
            using (var context = new BikeStoresContext())
            {
                return context.OrderItems.ToList();
            }
        }
        public static void Insertar(OrderItem dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Actualizar(OrderItem modificado)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Borrar(OrderItem dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static DataTable? ListarProductosPedido(int idPedido)
        {
           using (var context = new BikeStoresContext())
            {
                var query = from o in context.OrderItems
                            join p in context.Products
                            on o.ProductId equals p.ProductId
                            where o.OrderId == idPedido
                            select new
                            {
                                Cantidad = o.Quantity,
                                Producto = p.ProductName,
                                Descuento = o.Discount,
                                Precio = o.ListPrice
                            };
                var list = query.ToList();

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Cantidad", typeof(int));
                dataTable.Columns.Add("Producto", typeof(string));
                dataTable.Columns.Add("Descuento", typeof(decimal));
                dataTable.Columns.Add("Precio", typeof(decimal));
                foreach (var item in list)
                {
                    dataTable.Rows.Add(item.Cantidad, item.Producto, item.Descuento, item.Precio);
                }

                return dataTable;
            }
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
        // ~OrderItemDAO()
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
}
