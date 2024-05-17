using BikeStoreWPF.Services;
using BikeStoreWPF.ViewModel.Base;
using CapaEntidades;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BikeStoreWPF.ViewModel
{
    public class DashBoardViewModel : BaseViewModel
    {
        public static Staff? usuarioRegistrado;

        //GraficosPieChart
        private ObservableCollection<Category> categorias;
        private SeriesCollection seriesCollectionPieChart;
        public SeriesCollection SeriesCollectionPieChart
        {
            get { return seriesCollectionPieChart; }
            set
            {
                seriesCollectionPieChart = value;
                OnPropertyChanged();
            }
        }

        //GraficosBarras
        private SeriesCollection seriesCollectionBarras;
        private string[] labels;
        private Func<double, string> formatter;
        private List<Staff> staff;
        public SeriesCollection SeriesCollectionBarras
        {
            get { return seriesCollectionBarras; }
            set
            {
                seriesCollectionBarras = value;
                OnPropertyChanged();
            }
        }
        public Func<double, string> Formatter
        {
            get { return formatter; }
            set
            {
                formatter = value;
                OnPropertyChanged();
            }
        }
        public string[] Labels
        {
            get { return labels; }
            set
            {
                labels = value;
                OnPropertyChanged();
            }
        }

        //Cards
        private long totalPedidos;
        private long totalProductos;
        private decimal importePedidos;
        private decimal importePedidosUsuario;
        private string nombreUsuario;
        private DateTime actualizado;
        
        public long TotalPedidos
        {
            get { return totalPedidos;}
            set
            {
                totalPedidos = value;
                OnPropertyChanged();
            }
        }
        public decimal ImportePedidos
        {
            get { return importePedidos; }
            set
            {
                importePedidos = value;
                OnPropertyChanged();
            }
        }
        public decimal ImportePedidosUsuario
        {
            get { return importePedidosUsuario; }
            set
            {
                importePedidosUsuario = value;
                OnPropertyChanged();
            }
        }
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set
            {
                nombreUsuario = value;
                OnPropertyChanged();
            }
        }

        public long TotalProductos
        {
            get { return totalProductos; }
            set
            {
                totalProductos = value;
                OnPropertyChanged();
            }
        }

        public DateTime Actualizado
        {
            get { return actualizado; }
            set
            {
                actualizado = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand CargarGraficoBarrasCommand { get; }
        public ICommand CargarPieChartCommand { get; }
        public ICommand TotalPedidosCommand { get; }
        public ICommand TotalProductosCommand { get; }
        public ICommand ImportePedidosCommand { get; }
        public ICommand ImportePedidosUsuarioCommand { get; }

        public DashBoardViewModel(Staff usuarioRegistrado = null) 
        {
            DashBoardViewModel.usuarioRegistrado = usuarioRegistrado;

            CargarPieChartCommand = new RelayCommand(PerformCargarPieChart);
            CargarGraficoBarrasCommand = new RelayCommand(PerformCargarGraficoBarras);
            TotalPedidosCommand = new RelayCommand(PerfomTotalPedidos);
            TotalProductosCommand = new RelayCommand(PerfomTotalProductos);
            ImportePedidosCommand = new RelayCommand(PerfomImportePedidos);
            ImportePedidosUsuarioCommand = new RelayCommand(PerfomImportePedidosUsuario);
        }

        private void PerfomImportePedidosUsuario(object obj)
        {
            NombreUsuario = "€ pedidos para " + usuarioRegistrado.FirstName;
            ImportePedidosUsuario = DashBoardService.ListarOrders()
            .Where(o => o.Staff.Email == usuarioRegistrado.Email)
            .Sum(o =>
            {
                decimal listPrice = 0;

                foreach (var orderitem in o.OrderItems)
                {
                    listPrice += orderitem.ListPrice;
                }
                return listPrice;
            });
        }

        private void PerfomImportePedidos(object obj)
        {

            ImportePedidos = DashBoardService.ListarOrders()
            .Where(o => o.OrderDate.Date == DateTime.Today)
            .Sum(o =>
            {
                decimal listPrice = 0;

                foreach (var orderitem in o.OrderItems)
                {
                    listPrice += orderitem.ListPrice;
                }
                return listPrice;
            });
        }

        private void PerfomTotalProductos(object obj)
        {
            TotalProductos = DashBoardService.ObtenerStock().Where(s => s.Quantity < 10).Count();
        }

        private void PerfomTotalPedidos(object obj)
        {
            var mesActual = DateTime.Today.Month;
            var anyo = DateTime.Today.Year;

            TotalPedidos = usuarioRegistrado.Orders
                .Where(order => order.OrderDate.Month == mesActual && order.OrderDate.Year == anyo)
                .Count();
            Actualizado = DateTime.Now;
        }

        private void PerformCargarPieChart(object obj)
        {
            categorias = new ObservableCollection<Category>(DashBoardService.ListarCategorias());
            SeriesCollectionPieChart = new SeriesCollection();

            foreach (var categoria in categorias)
            {
                var s = new PieSeries
                {
                    Title = categoria.CategoryName,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(categoria.Products.Count) },
                    DataLabels = true
                };

                SeriesCollectionPieChart.Add(s);
            }
        }
        private void PerformCargarGraficoBarras(object obj)
        {
            staff = DashBoardService.ListarStaff().ToList();
            SeriesCollectionBarras = new SeriesCollection();
            List<string> labels = new List<string>();
            List<double> values = new List<double>();

            foreach (var staff in staff)
            {
                labels.Add(staff.FirstName);
                values.Add(staff.Orders.Count);
            }

            SeriesCollectionBarras.Add(
                new ColumnSeries
                {
                    Title = "Pedidos realizados",
                    Values = new ChartValues<double>(values)
                });

            Labels = labels.ToArray();
            Formatter = value => value.ToString("N");

        }
    }
}
