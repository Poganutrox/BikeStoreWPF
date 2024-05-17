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
    /// <summary>
    /// Lógica de interacción para SalirAppView.xaml
    /// </summary>
    public partial class SalirAppView : Window
    {
        public bool salir { get; private set; }
        public SalirAppView()
        {
            InitializeComponent();
            salir = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            salir = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            salir = false;
            Close();
        }
    }
}
