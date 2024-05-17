using CapaEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{

    ///<author> Miguel Ángel Moreno García</author>
    public class StaffDAO : IDisposable
    {
        private bool disposedValue;

        //CRUD
        public static IList<Staff> Listar()
        {
            using (var context = new BikeStoresContext())
            {
                var data = context.Staffs
                    .Include(s => s.Orders)
                    .TagWith("ListarStaffs")
                    .ToList();
                return data;
            }
                
        }
        public static void Insertar(Staff dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public static void Actualizar(Staff modificado)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Borrar(Staff dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public  Staff ObtenerEmpleadoRegistrado(string email, string password)
        {
            using(var context = new BikeStoresContext())
            {
                var query = from s in context.Staffs
                            where s.Email == email
                            && s.PasswordStaff == password
                            select s;
                return query.FirstOrDefault();
            }
        }

        public bool VerificarEmail(string email)
        {
            using(var context = new BikeStoresContext())
            {
                var queryEmail = from s in context.Staffs
                                 where s.Email.ToLower() == email.ToLower()
                                 select s;
                if (queryEmail.IsNullOrEmpty()) return false;
                
                return true;
            } 
        }

        public  Staff ObtenerStaff(int id)
        {
            using(var context = new BikeStoresContext())
            {
                var query = from s in context.Staffs
                                 where s.StaffId == id
                                 select s;
                

                return query.FirstOrDefault();
            }
        }

        public IList<Staff?> ListarEmpleadoActivos()
        {
            using(var contex = new BikeStoresContext())
            {
                var query = from s in contex.Staffs
                            .Include(s => s.Store)
                            .Include(s => s.Manager)
                            where s.Active == 1
                            select s; 
                return query.ToList();
            }
        }

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
