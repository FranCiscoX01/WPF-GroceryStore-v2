   M S B A M L   `   `   `  ����M  IGrocerieStore v2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GrocerieStore_v2._0GrocerieStore_v2._0  5   	   $    GrocerieStore_v2._0.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GrocerieStore_v2._0     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�65    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�6{   .��5
      � .+�5   
   ��  �� CornerRadius$ 15��6   $��0q�6#   
�������._�5      �  � ColumnDefinitions 5      �� 5      6)   �� 5      6)   .+�5      �� $��2��6   $��	0,0,0,404q�60   ���	#FF7ABAF9 �� RadiusY$ 13.006��6T    �� RadiusX$ 13.006��6e   �� 5      -   5        $
��Left=�5      $��25��64   $��
364,10,0,0q�6@   $	��Top=�6T   $��26��6l   $��1��6w   ��6�   Z� ��6�   Z� ��6�   Z� .��5      �� $��	close.png��6   5      �� 5      $��logo.png��6   $
��Left=�6*   $��44��6E   $��	10,10,0,0q�6Q   $	��Top=�6d   $��34��6|   �� 5      $
��Left=�6   $��	49,10,0,0q�67   $
��Wrap=�6J   $��Grocery Store��6^   $	��Top=�6s   $��Segoe UI Emoji)�6�   $��20(�6�   �� 5      -   5        $��New Product��5      $��1��6/   $��297,63,10,354q�6?   6V   �� 5      $
��Left=�6   $	��389��68   $��	10,51,0,0q�6E   $	��Top=�6X   $	��780��6p   $��2��6|   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��ProductsDataGrid��5      $��0,50,0,0q�67   $	��338��6I      AutoGenerateColumns .  	   CanUserAddRows	 .  
   
IsReadOnly
 .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6H      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+6a     5      $ product��6M   $	 100 6^    61   �� *	product+6l     5      $ descript��6N   $	 200 6`    61   �� *
descript+6n     5      $ price��6K   $	 100 6Z    61   �� *price+6h     5       $ quantity��6N   $	 100 6`    61   �� *
quantity+6n   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $	 100 65   $
 Edit��5"   d      CellTemplate 5#   "   �� 5$   &   .R�5%   *   �� -   5        $
��Edit��5%   1   6]   5&   '   5(        5)      $	 100 65   $ Delete��5*   f    5+   "   �� 5,   &   .R�5-   *   �� -   5        $��Delete��5-   1   6a   5.   '   50      52      53      �� 54      -   5        $��Refresh DataGrid��54      $
��Left=�64   $��	10,63,0,0q�6O   $	��Top=�6b   $	��105��6z   $��33��6�   6�   55      56      57      58      