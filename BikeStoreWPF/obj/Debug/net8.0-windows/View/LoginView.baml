   M S B A M L   `   `   `  ����G  CBikeStoreWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BikeStoreWPF.ViewBikeStoreWPF.View  5   	   !    BikeStoreWPF.View.LoginView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:BikeStoreWPF.View     5   	   -   5          � Title$  Iniciar sesión��5   	   $	��400��6    $	��300��6-    � WindowStartupLocation$ CenterScreen=�69    � 	Resources 5	         BotonAccion �� 
TargetType �� Property �� Value  ValidationErrorTemplate2 ��Name �� Padding��%  &	        &	 :    �� 5
   
   " ��6$   .�5      ��  � �� �#FFECB36+   �� 5       � ��
 �����6,   �� 5       � ��$ 2q�60   �� 5       � �� �	#FF1364D46+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Arial Black)�6+   �� 5       � ��$ 40��6'   5      �� 5   
   .R�5      �� $	��200��6   .+�5      �� 
���  ��$��1q�6+   ._�5      �� $ AdornedElement��60   5      �� 5      
�������
���  ��$ 4q�6>   $��1,0,1,1q�6J   $
��Left=�6d   ._�5      �� $
��Left=�6;   ��6#   �� ��5      �� 5      .R�5   "   �� $��8(�6J   $��Arial Black)�6W   
���  ����6,   �� *ErrorContent+6p   5      5!      5"      5#      5$      5%      .��5(      �  � ColumnDefinitions 5)   
   �� 5*      $	��57* �6   �� 5+      $	��43* �6   	 � RowDefinitions	 5-   
   �� 5.      $
��111* �6   �� 5/      $	��17* �6   �� 50      $	��64* �6   .+�53   
   �� $��0��6   
 �� Orientation$
 Vertical=�6"   $��
10,14,10,9q�69    J� RenderTransformOrigin$ 0.5,0.5&�54      $��2��65   ��55      �� 56       �� ImageSource$' !/View/foto-pozuelo-interior-3.jpg��6    j� Stretch$
 Fill=�6M    j� TileMode$
 Tile=�6\    �� Opacity$	 0.5Q�6l   z�58      V� 59      .~�5:      �� �� 5;       �� AngleX$ 0.221Q�6$   �� 5<      T� 5=       T� X$ 0.761Q�6)   5>      .+�5@      �� $��Usuario��6   $��Arial Black)�6&   ���	#FF1364D4$	��200��6V   �� 5A      -   5        $��Usuarios��5A      $	��200��6'   $��0,5,0,10q�63   ��6F   �� *
Usuarios+ �� SelectedItem 6g   �� *UsuarioSeleccionado+��5B      �� 5C      .R�5D      �� $
 
Horizontal=�6%   $��40��6>   .+�5E      �� $
��Fill=�6B   ��6$   �� *
ImageStaff+6B   �� 5F      $��Center=�6C   $��10,0,0,0q�6^   ��6(   �� *	FirstName+6^   5G      5H      5J      �� 5K      $��Contraseña��6   $��Arial Black)�6)   ���	#FF1364D4$	��200��6Y   G� 5L      -   5        $��Password��5L      $	��200��6+   $��0,5,0,15q�67   6I   �� 5M      $��Iniciar Sesión��6   $	��100��6.   #��[  5N      ��5O      �� *IniciarSersionCommand+5P      �� 5Q   
   $��1��6   $��Center=�6"   $
��Left=�6=   $��16��6Y   $��	150,0,0,0q�6e   .+�5R      �� 
���  ����6   �� *
Intentos+6E   5S      � 5T   
   $��2��6   $��0,12,0,0q�6   $��2��6.   .+�5U      �� $c��]/View/inspirational_cycling_quotes_poster-re7bc72595dd5450e8f7dfde0b1ee7512_wh5_8byvr_630.jpg��6   $	��Top=�6|   $
��Left=�6�   $��50��5V   	   $��50��6   $��
123,16,0,0q�6     K� ZIndex$ 1��64   �� 5W      $
��Left=�6   $��76��6/   $��	-8,56,0,0q�6;   $	��Top=�6N   $	��308��6f   $H��B/View/silhouette-design-of-mountain-for-decoration-free-vector.jpg��6r   5X      5[      5\      