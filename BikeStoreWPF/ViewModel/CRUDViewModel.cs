using BikeStoreWPF.Services;
using BikeStoreWPF.ViewModel.Base;
using CapaEntidades;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BikeStoreWPF.ViewModel
{
    public class CRUDViewModel : BaseViewModel
    {
        private CRUDService crudService = new CRUDService();
        private ObservableCollection<Product> listaProductos;
        private ObservableCollection<Brand> listaBrands;
        private ObservableCollection<Category> listaCategories;
        private string productName;
        private string modelYear;
        private string listPrice;
        private string busqueda;
        private byte[]? imageProduct;
        private Product? selectedProducto;
        private Brand selectedBrand;
        private Category selectedCategory;
        private Regex regexPrecio = new Regex(@"^\d{1,8}(\,\d{1,2})?$");
        
        public string Busqueda
        {
            get { return busqueda; } 
            set 
            { 
                busqueda = value;
                OnPropertyChanged();
            }
        }
        public byte[]? ImageProduct
        {
            get { return imageProduct; }
            set
            {
                imageProduct = value;
                OnPropertyChanged();
            }
        }
        public Product? SelectedProducto
        {
            get { return selectedProducto; }
            set
            {
                selectedProducto = value;
                OnPropertyChanged();
            }
        }
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                selectedBrand = value;
                OnPropertyChanged();
            }
        }
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;

                ClearErrors("ProductName");
                if (value.Length == 0)
                {
                    AddError("ProductName", "No puede estar vacio");
                }
                OnPropertyChanged();
            }
        }
        public string ModelYear
        {
            get { return modelYear; }
            set
            {
                modelYear = value;

                ClearErrors("ModelYear");
                if (value.IsNullOrEmpty())
                {
                    AddError("ModelYear", "No puede estar vacio");
                }
                else if(!short.TryParse(value, out short resultado))
                {
                    AddError("ModelYear", "Número no válido");
                }
                OnPropertyChanged();
            }
        }
        public string ListPrice
        {
            get { return listPrice; }
            set
            {
                listPrice = value;

                ClearErrors("ListPrice");

                if (value.IsNullOrEmpty())
                {
                    AddError("ListPrice", "No puede estar vacio");
                }
                else if (!regexPrecio.IsMatch(value))
                {
                    AddError("ListPrice", "Formato no válido");
                }
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Category> ListaCategories
        {
            get { return listaCategories; }
            set
            {
                listaCategories = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Brand> ListaBrands
        {
            get { return listaBrands; }
            set
            {
                listaBrands = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Product> ListaProductos
        {
            get { return listaProductos; }
            set
            {
                listaProductos = value;
                OnPropertyChanged();
            }
        }

        public ICommand CargarCRUDCommand { get; }
        public ICommand LlenarFormularioCommand { get; }
        public ICommand RealizarBusquedaCommand { get; }
        public ICommand AdjuntarImagenCommand { get; }
        public ICommand InsertarActualizarBorrarProductoCommand { get; }
        public CRUDViewModel()
        {
            CargarCRUDCommand = new RelayCommand(PerformCargarCRUD);
            LlenarFormularioCommand = new RelayCommand(PerformLlenarFormulario);
            AdjuntarImagenCommand = new RelayCommand(PerformAdjuntarImagen);
            InsertarActualizarBorrarProductoCommand = new RelayCommand(PerformInsertarActualizarBorrarProducto, CanInsertarActualizarBorrarProducto);
            RealizarBusquedaCommand = new RelayCommand(PerfomRealizarBusqueda);
        }

        private void PerfomRealizarBusqueda(object obj)
        {
            var busqueda = Busqueda.ToLower();
            ListaProductos = new ObservableCollection<Product>(CRUDService.ListarProductos()
                .Where(p => p.ProductName.ToLower().Contains(busqueda) 
                              || p.ModelYear.ToString().Contains(busqueda) 
                              || p.ListPrice.ToString().Contains(busqueda)
                              || p.Brand.BrandName.ToLower().Contains(busqueda)));
        }

        private bool CanInsertarActualizarBorrarProducto(object obj)
        {
            return !HasErrors && !ProductName.IsNullOrEmpty();
        }

        private void PerformInsertarActualizarBorrarProducto(object obj)
        {
            //Insertar
            if(selectedProducto == null)
            {
                Product nuevoProducto = new Product(
                      0,
                      ProductName,
                      SelectedBrand.BrandId,
                      SelectedCategory.CategoryId,
                      Convert.ToInt16(modelYear),
                      Convert.ToDecimal(listPrice)
                      );

                if (!ImageProduct.IsNullOrEmpty())
                {
                    nuevoProducto.ImageProduct = ImageProduct;
                }

                try
                {
                    crudService.InsertarProducto(nuevoProducto);
                    MessageBox.Show("Producto insertado con éxito");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha ocurrido un error al insertar el producto", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            //Actualizar
            else if(selectedProducto.ProductName != ProductName || selectedProducto.BrandId != SelectedBrand.BrandId 
                ||  selectedProducto.CategoryId != SelectedCategory.CategoryId || selectedProducto.ModelYear != Convert.ToInt16(modelYear)
                || selectedProducto.ListPrice != Convert.ToDecimal(listPrice))
            {
                selectedProducto.ProductName = ProductName;
                selectedProducto.BrandId = SelectedBrand.BrandId;
                selectedProducto.CategoryId = SelectedCategory.CategoryId;
                selectedProducto.ModelYear = Convert.ToInt16(modelYear);
                selectedProducto.ListPrice = Convert.ToDecimal(listPrice);

                if (!ImageProduct.IsNullOrEmpty())
                {
                    selectedProducto.ImageProduct = ImageProduct;
                }

                crudService.ActualizarProducto(selectedProducto);
                MessageBox.Show("Producto actualizado con éxito");
            }
            //Borrar
            else
            {
                if (MessageBox.Show("¿Seguro que quieres borrar el producto: " + selectedProducto.ProductName + "?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    crudService.BorrarProducto(selectedProducto);
                    MessageBox.Show("Producto borrado con éxito");
                    ListaProductos = new ObservableCollection<Product>(CRUDService.ListarProductos());
                    ProductName = "";
                    ModelYear = "";
                    ListPrice = "";
                    ImageProduct = null;
                }

            }

            RestablecerCampos();

        }
        private void RestablecerCampos()
        {
            ListaProductos = new ObservableCollection<Product>(CRUDService.ListarProductos());
            ProductName = "";
            ModelYear = "";
            ListPrice = "";
            ImageProduct = null;
            ClearErrors("ProductName");
            ClearErrors("ModelYear");
            ClearErrors("ListPrice");
        }
       
        private void PerformAdjuntarImagen(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.jpg; *.png)|*.jpg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                ImageProduct = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void PerformLlenarFormulario(object obj)
        {
            if(selectedProducto != null)
            {
                ProductName = selectedProducto.ProductName;
                ModelYear = selectedProducto.ModelYear.ToString();
                ListPrice = selectedProducto.ListPrice.ToString();
                SelectedBrand = listaBrands.Where(b => b.BrandId == selectedProducto.Brand.BrandId).First();
                SelectedCategory = listaCategories.Where(c => c.CategoryId == selectedProducto.Category.CategoryId).First();

                if (SelectedProducto.ImageProduct != null)
                {
                    ImageProduct = SelectedProducto.ImageProduct;
                }
                else
                {
                    ImageProduct = null;
                }
            }
           
        }

        private void PerformCargarCRUD(object obj)
        {
            ListaProductos = new ObservableCollection<Product>(CRUDService.ListarProductos());
            ListaBrands = new ObservableCollection<Brand>(CRUDService.ListarBrands());
            ListaCategories = new ObservableCollection<Category>(CRUDService.ListarCategories());

            //Marcar una opción por defecto en los combo box
            SelectedBrand = ListaBrands[0];
            SelectedCategory = ListaCategories[0];
        }
    }
}
