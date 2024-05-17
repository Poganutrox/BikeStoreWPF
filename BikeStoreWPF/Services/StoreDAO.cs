using CapaEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{

    ///<author> Miguel Ángel Moreno García</author>
    public class StoreDAO : IDisposable
    {
        private bool disposedValue;

        public static IList<Store> Listar()
        {
            using (var context = new BikeStoresContext())
            {
                return context.Stores.ToList();
            }   
        }
        public void Insertar(Store dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Actualizar(Store modificado)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Borrar(Store dato)
        {
            using (var context = new BikeStoresContext())
            {
                context.Entry(dato).State = EntityState.Deleted;
                context.SaveChanges();
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
        // ~StoreDAO()
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
