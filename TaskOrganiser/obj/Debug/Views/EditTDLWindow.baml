   M S B A M L   `   `   `  ����  TaskOrganiser'    !TaskOrganiser.Views.EditTDLWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Edit TDL��5   	   $	��250��6   $	��300��6'   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Name:��6-   �� 5   
   -   5         ��Name$ NameTextBox��5   /   $��0��6   $��1��6   6/   �� 5   
   $��1��6   $��0��6   $��Image:��6-   �� 5   
   -   5         ��Name$ TDLImage��5   -   $��1��6   $��1��6   $	��100��6�   $��50��6�   ��6?   �� *	ImagePath+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��2��6   $��0��6   $��Select Image:��6-   �� 5   
   -   5         ��Name$ ImageComboBox��5   0   $��2��6   $��1��6    6G   �� 5   
   -   5        $��3��5      $��1��6   $
��Save��6.   6=   5      5      