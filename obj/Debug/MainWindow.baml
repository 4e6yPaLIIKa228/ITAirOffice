   M S B A M L   `   `   `  ����F  BITAirOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ITAirOfficeITAirOffice  5   	       ITAirOffice.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ITAirOffice     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��900��6)    � AllowsTransparency .  � WindowStyle$
 None=�6O    � 
ResizeMode$ NoResize=�6b    � WindowStartupLocation$ CenterScreen=�6x   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgInfo��5
      $��	0,60,0,70q�6#   $��0��66      	RowHeight$ 30Q�6F   $��1��6U      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6g      CanUserAddRows .  	   AutoGenerateColumns	 .  
   MinColumnWidth$
 25Q�6�      RowHeaderWidth$ 0Q�6�      SelectionUnit$ FullRow=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      
IsReadOnly .    Width$ 50 6G      FontSize$ 14Q�6k   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *ID+6k     5      $ Самолет��6%    . $	 100 6I   $ 14Q�6p    6V   �� *Model+6p     5      $ Время вылета��6%    . $	 100 6N   $ 14Q�6x    6[   �� *
TimeFrom+6x     5      $ Время прилета��6%    . $	 100 6O   $ 14Q�6w    6\   �� *TimeIn+6w     5      $ Пункт вылета��6%    . $	 225 6N   $ 14Q�6z    6[   �� *
AdressFrom+6z     5      $% Пункт назначения��6%    . $	 223 6R   $ 14Q�6|    6_   �� *
AdressIn+6|     5      $ Статус��6%    . $	 100 6H   $ 14Q�6p    6U   �� *Status+6p   5      �� 5   
   -   5         ��Name$ btnexit��5      $��Button��6"   $
��Left=�63   $��
612,10,0,0q�6N   $	��Top=�6b   $��75��6z   6�   �� 5   
   -   5        $ btnbuybulet��5      $��Button��6&   $
��Left=�67   $��
180,10,0,0q�6R   $	��Top=�6f   $��75��6~   6�   5      5      