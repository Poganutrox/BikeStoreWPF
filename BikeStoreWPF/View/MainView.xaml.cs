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
using BikeStoreWPF.UserControls;
using BikeStoreWPF.ViewModel;
using CapaEntidades;
using LiveCharts;
using LiveCharts.Wpf;

namespace BikeStoreWPF.View
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    /// 
    
    public partial class MainView : Window
    {
        private Staff usuarioRegistrado;
        public MainView(Staff usuarioRegistrado)
        {
            InitializeComponent();
            this.usuarioRegistrado = usuarioRegistrado;
            var mainViewModel = new MainViewModel(usuarioRegistrado); 

            DataContext = mainViewModel;

            var dashBoardViewModel = new DashBoardViewModel(usuarioRegistrado);
            dashBoard.DataContext = dashBoardViewModel;
            dashBoard.totalPedidosUserControl.DataContext = dashBoardViewModel;
            dashBoard.graficosBarrasUserControl.DataContext = dashBoardViewModel;
            dashBoard.graficosPieChartUserControl.DataContext = dashBoardViewModel;
            dashBoard.totalProductosUserControl.DataContext = dashBoardViewModel;
            dashBoard.importePedidosRealizadosUserControl.DataContext = dashBoardViewModel;
            dashBoard.importePedidosUsuarioUserControl.DataContext = dashBoardViewModel;
        }

        private double anchoOriginalColumn1;
        private double anchoOriginalColumn2;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Guardar los tamaños originales al cargar la ventana
            anchoOriginalColumn1 = cMenu.Width.Value;
            anchoOriginalColumn2 = cDashboard.Width.Value;
        }


        private bool estadoOriginal = true;
        private void onClick(object sender, RoutedEventArgs e)
        {
            if (estadoOriginal)
            {
                // Cambiar a nuevos valores
                cMenu.Width = new GridLength(2, GridUnitType.Star);
                cDashboard.Width = new GridLength(8, GridUnitType.Star);
            }
            else
            {
                // Restaurar valores originales
                cMenu.Width = new GridLength(anchoOriginalColumn1, GridUnitType.Star);
                cDashboard.Width = new GridLength(anchoOriginalColumn2, GridUnitType.Star);
            }

            estadoOriginal = !estadoOriginal;

        }

        private void moveToProductUserControl_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Clear();

            var crudViewModel = new CRUDViewModel();
            var crudProductosUserControl = new CRUDProductosUserControl();
            crudProductosUserControl.DataContext = crudViewModel;
            Grid.SetRowSpan(crudProductosUserControl, 2);
            panel.Children.Add(crudProductosUserControl);
        }

        private void moveToDashboardUserControl_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Clear();

            var dashBoardViewModel = new DashBoardViewModel(usuarioRegistrado);
            var dashBoardUserControl = new DashBoardUserControl();
            dashBoardUserControl.DataContext = dashBoardViewModel;
            dashBoardUserControl.totalPedidosUserControl.DataContext = dashBoardViewModel;
            dashBoardUserControl.graficosBarrasUserControl.DataContext = dashBoardViewModel;
            dashBoardUserControl.graficosPieChartUserControl.DataContext = dashBoardViewModel;
            dashBoardUserControl.totalProductosUserControl.DataContext = dashBoardViewModel;
            dashBoardUserControl.importePedidosRealizadosUserControl.DataContext = dashBoardViewModel;
            dashBoardUserControl.importePedidosUsuarioUserControl.DataContext = dashBoardViewModel;

            Grid.SetRowSpan(dashBoardUserControl, 2);

            panel.Children.Add(dashBoardUserControl);
        }

        private void moveToNoImplemented_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Clear();
            var noImplementado = new NoImplementadoUserControl();
            Grid.SetRowSpan(noImplementado, 2);
            panel.Children.Add(noImplementado);
        }

        private void PreguntarSalida_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SalirAppView salida = new SalirAppView();
            salida.ShowDialog();

            if (salida.salir)
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
