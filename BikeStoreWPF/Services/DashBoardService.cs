using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreWPF.Services
{
    public class DashBoardService
    {
        public static IList<Category> ListarCategorias()
        {
            return CategoryDAO.Listar();

        }

        public static IList<Staff> ListarStaff()
        {
            return StaffDAO.Listar();

        }

        public static List<Stock> ObtenerStock()
        {
            using(var stockDAO = new StockDAO())
            {
                return stockDAO.ObtenerStock();
            }
        }

        public static List<Order> ListarOrders()
        {
            return OrderDAO.Listar().ToList();
        }
    }
}
