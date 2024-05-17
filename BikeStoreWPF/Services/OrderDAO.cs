using CapaEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{

    ///<author> Miguel Ángel Moreno García</author>
    public class OrderDAO : IDisposable
    {
        private bool disposedValue;

        //CRUD
        public static IList<Order> Listar()
        {
            using (var context = new BikeStoresContext())
            {

                return context.Orders
                    .Include(o => o.OrderItems)
                    .Include(o => o.Staff)
                    .ToList();
            }
        }
        public static void Insertar(Order dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public static void Actualizar(Order modificado)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Borrar(Order dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static Order RecuperarUltimoPedido()
        {
            using (var context = new BikeStoresContext())
            {
                var ultimoPedido = context.Orders.OrderByDescending(o => o.OrderId).First();
                return ultimoPedido;
            }
        }

        public static DataTable ListarPedidos()
        {
            using (var context = new BikeStoresContext())
            {

                var query = from or in context.Orders
                            join cu in context.Customers
                            on or.CustomerId equals cu.CustomerId
                            join st in context.Stores
                            on or.StoreId equals st.StoreId
                            join sf in context.Staffs
                            on or.StaffId equals sf.StaffId
                            orderby or.OrderId ascending
                            select new
                            {
                                OrderId = or.OrderId,
                                CustomerName = cu.FirstName,
                                CustormerLastName = cu.LastName,
                                CustomerEmail = cu.Email,
                                CustomerPhone = cu.Phone,
                                OrderStatus = or.OrderStatus,
                                OrderDate = or.OrderDate,
                                RequiredDate = or.RequiredDate,
                                ShippedDate = or.ShippedDate,
                                StoreName = st.StoreName,
                                StaffName = sf.FirstName,
                            };

                var products = query.ToList();

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("NºPedido", typeof(string));
                dataTable.Columns.Add("Estado del pedido", typeof(string));
                dataTable.Columns.Add("Fecha creación", typeof(DateTime));
                dataTable.Columns.Add("Fecha preparación", typeof(DateTime));
                dataTable.Columns.Add("Fecha envio", typeof(DateTime));
                dataTable.Columns.Add("Nombre cliente", typeof(string));
                dataTable.Columns.Add("Apellido cliente", typeof(string));
                dataTable.Columns.Add("Email cliente", typeof(string));
                dataTable.Columns.Add("Telefono cliente", typeof(string));
                dataTable.Columns.Add("Nombre tienda", typeof(string));
                dataTable.Columns.Add("Nombre empleado", typeof(string));

                foreach (var item in products)
                {
                    dataTable.Rows.Add(item.OrderId, item.OrderStatus,item.OrderDate, item.RequiredDate, item.ShippedDate,
                        item.CustomerName, item.CustormerLastName, item.CustomerEmail, item.CustomerPhone, item.StoreName, item.StaffName);
                }

                return dataTable;
            }
        }

        //Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
