using BikeStoreWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BikeStoreWPF.View
{
    public partial class LoginView : Window
    {
        LoginViewModel viewModel;
        public LoginView()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            DataContext = viewModel;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.Password = Password.Password;
        }

        private void PreguntarSalida_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SalirAppView salida = new SalirAppView();
            salida.ShowDialog();

            if(salida.salir)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
