using BikeStoreWPF.ViewModel.Base;
using CapaEntidades;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BikeStoreWPF.Services;
using LiveCharts.Defaults;
using System.Windows.Input;


namespace BikeStoreWPF.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private Staff usuarioRegistrado;

        public Staff UsuarioRegistrado
        {
            get { return usuarioRegistrado; }
            set 
            { 
                usuarioRegistrado = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(Staff usuarioRegistrado)
        {
            UsuarioRegistrado = usuarioRegistrado;
        }
    }
}
