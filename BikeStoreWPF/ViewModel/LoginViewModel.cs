using BikeStoreWPF.Services;
using BikeStoreWPF.View;
using BikeStoreWPF.ViewModel.Base;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BikeStoreWPF.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private Staff usuarioSeleccionado;
        private string password;
        private List<Staff> usuarios;
        private int oportunidades = 3;
        private string intentos;

        public string Intentos
        {
            get { return intentos; }
            set
            {
                intentos = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public List<Staff> Usuarios
        {
            get { return usuarios; }
            set
            {
                usuarios = value;
                OnPropertyChanged();
            }
        }
        public Staff UsuarioSeleccionado
        {
            get { return usuarioSeleccionado; }
            set
            {
                usuarioSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public ICommand IniciarSersionCommand { get; }
        public LoginViewModel()
        {
            usuarios = LoginService.ListarStaff().ToList();
            IniciarSersionCommand = new RelayCommand( PerformIniciarSesion, CanExecuteIniciarSesion);
        }

        private bool CanExecuteIniciarSesion(object parameter)
        {
            return usuarioSeleccionado != null && !string.IsNullOrEmpty(password);
        }

        private void PerformIniciarSesion(object? parameter)
        {
            if(usuarioSeleccionado.PasswordStaff.ToLower() != HashPassword(password).ToLower())
            {
                oportunidades -= 1;
                Intentos = "Intentos disponibles: " + oportunidades;

                if(oportunidades == 0)
                {
                    Application.Current.Shutdown();
                }
            }
            else
            {
                MainView m = new MainView(usuarioSeleccionado);
                m.Show();

                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Close();
                }
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var hashPassword = sha256.ComputeHash(passwordBytes);
                return Convert.ToHexString(hashPassword);
            }
        }
    }
}
