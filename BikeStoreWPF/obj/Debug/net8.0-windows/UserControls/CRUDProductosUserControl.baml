   M S B A M L   `   `   `  ����G  CBikeStoreWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BikeStoreWPF.UserControlsBikeStoreWPF.UserControls  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aeHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.BehaviorsMicrosoft.Xaml.Behaviors 5      8    2BikeStoreWPF.UserControls.CRUDProductosUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:BikeStoreWPF.UserControls     5      ViHclr-namespace:Microsoft.Xaml.Behaviors;assembly=Microsoft.Xaml.Behaviors     5        � 	Resources  5
         Text �� 
TargetType �� Property �� Value  BotonAccion  ValidationErrorTemplate2 ��Name �� Padding��%�  &	        &	 �     &	 �    �� 5   
   " ��6   .�5      ��  � ��$ Arial Black)�6+   �� 5       � ��$ 12(�6)   �� 5       � �� �	#FF1364D46+   5      �� 5   
   " ��6$   .�5      ��  � �� �#FFECB36+   �� 5       � ��
 �����6,   �� 5       � ��$ 2q�60   �� 5       � �� �	#FF1364D46+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Arial Black)�6+   �� 5       � ��$ 40��6'   5      �� 5   
   .R�5      �� $	��150��6   .+�5      �� 
���  ��$��1q�6+   ._�5      �� $ AdornedElement��60   5      �� 5      
�������
���  ��$ 4q�6>   $��1,0,1,1q�6J   $
��Left=�6d   ._�5       �� $
��Left=�6;   ��6#   �� ��5!      �� 5"      .R�5#   "   �� $��8(�6J   
���  ����6,   �� *ErrorContent+6W   5$      5&      5'      5(      5)      5*      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5,      +  %Microsoft.Xaml.Behaviors.EventTrigger  5-   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5.      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   Command	 6$   �� *CargarCRUDCommand+5/      .��52      � $��10,10,10,10q�6   
 � ColumnDefinitions
 53   
   �� 54      $��7* �6   6,   �� 55      $��5* �6   6,   .+�57   
   � $��0��6    � RowDefinitions 58      �� 59      $��* �6    6-   �� 5:      $��4* �6    6.   .+�5<      �� $��0��6   $��Buscador de productos��6$   
������$��Arial Black)�6[   .��5=      ��  �� Orientation$ 
Horizontal=�6   .+�5>      �� $��Buscar��6    $��0,0,10,0q�6/   $��15��6A   #��[  5?      �� 5@      $��Center=�6k   $
��Left=�5A      $	��150��6   ��5@      �� *
Busqueda+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5A   (    5B        5C      $ TextChanged��6-   . 5D   "     	 68   �� *RealizarBusquedaCommand+5E      .��5F   2   5G      5H      5J      �� 5K      $��	Productos��6   $��1��6*   
������$��Arial Black)�6O   $��5q�6h   .��5L      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridProductos��5L         AutoGenerateColumns$ False��5M   .      
IsReadOnly$
 true��6J   ��5L   7   �� *ListaProductos+ �� SelectedItem 5M      �� *SelectedProducto+   Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre del producto��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *ProductName+  5P      $ Año del modelo��6-    6E   �� *	ModelYear+  5Q      $ Nombre de la marca��6-    6I   �� *Brand.BrandName+  5R      $ Precio��6-    6=   �� *	ListPrice+ 5T        5U      $ SelectionChanged��6)   . 5V        	 64   �� *LlenarFormularioCommand+5W      5Y      5Z      5\      � 5]   
   $��1��6   .+�5^      �� $��Gestión de productos��6   
������$��Arial Black)�6M   .��5_      �� $ Vertical=�6   $��4,0,1,0q�65   $��Center=�6F   .+�5`      �� $ 
Horizontal=�6!   $��5q�6:   .+�5a      �� $��Nombre��6$   #��[  5b      $	��125��6@   �� 5c      -   5        $��txtProductName��5c   "    =� ErrorTemplate# [ 5d      $	��150��6M   ��5c   8   �� *ProductName+$ TwoWay=�$ PropertyChanged=�" �� ValidatesOnNotifyDataErrors$
 True��5d   M   5e      �� 5g      $ 
Horizontal=�6!   $��5q�6:   .+�5h      �� $��Marca��6$   $
��Left=�61   $��0,0,85,0q�6L   #��[  5i      �� 5k      -   5        $��
cmbBrandId��5k   #   $	��150��65    �� DisplayMemberPath$ 	BrandName��5m       �� SelectedValuePath$ BrandId��5n      ��5l      �� *ListaBrands+ 5o      �� *SelectedBrand+5p      �� 5r      $ 
Horizontal=�6!   $��5q�6:   .+�5s      �� $��	Categoria��6$   $
��Left=�65   $��0,0,60,0q�6Q   #��[  5t      �� 5u      -   5        $��cmbCategoryId��5u   #   $	��150��68   $ CategoryName��5w      $ 
CategoryId��5x      ��5v      �� *ListaCategories+ 5y      �� *SelectedCategory+5z      �� 5|      $ 
Horizontal=�6!   $��5q�6:   .+�5}      �� $��Año del modelo��6$   $
��Left=�6:   $��0,0,30,0q�6U   #��[  5~      �� 5      -   5        $��txtModelYear��5   "   # [ 5�      $	��150��6M   ��5   6   �� *	ModelYear+$ TwoWay=�$ PropertyChanged=�$
 True��5�   M   5�      �� 5�      $ 
Horizontal=�6!   $��5q�6:   .+�5�      �� $��Precio��6$   $
��Left=�62   $��0,0,90,0q�6M   #��[  5�      �� 5�      -   5        $��txtListPrice��5�   "   # [ 5�      $	��150��6M   ��5�   6   �� *	ListPrice+$ TwoWay=�$ PropertyChanged=�$
 True��5�   M   5�      �� 5�      $ 
Horizontal=�6!   $��5q�6:   .+�5�      �� $��Imagen del producto��6$   $
��Left=�6?   $��0,0,10,0q�6Z   #��[  5�      �� 5�      $��Adjuntar Imagen��6!   $	��151��6;   #��[ 5�      ��5�      �� *AdjuntarImagenCommand+5�      5�      �� 5�      $��50��6<   $��50��6G   $��Center=�6S   ��6   �� *ImageProduct+6S   �� 5�      $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� $ ��Insertar/Actualizar/Borrar��6!   $	��200��6F   $��10q�6R   #��[ 5�      ��5�      �� *)'InsertarActualizarBorrarProductoCommand+5�      5�      5�      5�      5�      5�      5�      