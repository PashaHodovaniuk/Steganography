   M S B A M L   `   `   `  ����  Steganography    Steganography.Decrypting   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  Decrypt��5   	    � Title$ Дешифровка��5   	   $	��606��6   $
��1011��6)    � WindowStartupLocation$ CenterScreen=�6N    � WindowStyle$ 
ToolWindow=�6s   ��5      �� 5   
    �� ImageSource$ Image/Substrates.png��6   .��5      � .+�5	   
   �� -   5         ��Name$
 Img1��5	      $
��Left=�6   $	��527��69   $��	10,25,0,0q�6F   $	��Top=�6Y   $	��659��6q   $
��Fill=�6}   �� 5
   
   -   5         ��Name$ OpenImg1��5
      $%��Открыть картинку��6#   $
��Left=�6>   $��46��6Y   $��
674,54,0,0q�6e   $	��Top=�6y   $	��304��6�   $��Times New Roman)�6�   $��24(�6�   ���	#FF57F30E��6�   Z� ��6�   Z� 6  �� 5   
   -   5        $ OpenKey��5      $!��Загрузить ключ��6"   $
��Left=�6;   $��46��6V   $��674,105,0,0q�6b   $	��Top=�6w   $	��304��6�   $��Times New Roman)�6�   $��24(�6�   ���	#FF57F30E��6�   Z� ��6�   Z� 6�   �� 5   
   $��Ключ��6   $
��Left=�6   $��701,155,0,0q�6:   $	��Top=�6O   ���	#FFFF9700$��Times New Roman)�6~   $��20(�6�   �� 5   
   -   5         ��Name$	 Key��5      $
��Left=�6   $��36��6:   $��674,188,0,0q�6F   $	��Top=�6[   $	��304��6s   $ �� HorizontalScrollBarVisibility$ Visible=�6   $��Times New Roman)�6�   	 �� 
IsReadOnly	 . 6�   �� 5   
   -   5        $ 	Decrpting��5      $��Дешифровать��6$   $
��Left=�6:   $��45��6U   $��669,247,0,0q�6a   $	��Top=�6v   $	��304��6�   
���  ��$��Times New Roman)�6�   $��36(�6�   ��6�   Z� ��6�   Z� 6�   �� 5   
   $��Сообщение��6   $
��Left=�6$   $��674,301,0,0q�6?   $	��Top=�6T   $��Times New Roman)�6l   $��20(�6�   ���	#FFFBAB006�   �� 5   
   -   5        $ 	TextDecr1��5      $
��Left=�6%   $	��106��6@   $��674,339,0,0q�6M   
 �� TextWrapping$

 Wrap=�6b   $	��Top=�6v   $	��319��6�   $��Times New Roman)�6�   $ Visible=�6�   ��. " �� VerticalScrollBarVisibility$ Visible=�6  �� 5   
   -   5        $ 
MainScreen��5      $��Главное меню��6%   $
��Left=�6<   $��50��6W   $��674,481,0,0q�6c   $	��Top=�6x   $	��148��6�   $��Times New Roman)�6�   $��22(�6�   ���	#FFAEFF00��6�   Z� ��6�   Z� 6  �� 5   
   -	   5        $ Ending��5      $��Завершить��6!   $
��Left=�65   $��50��6P   $��830,481,0,0q�6\   $	��Top=�6q   $	��148��6�   $��Times New Roman)�6�   $��22(�6�   ���	#FFAEFF00��6�   Z� ��6�   Z� 6  �� 5   
   -
   5         ��Name$ Help3��5      $
��Left=�6#   $��34��6>   $��	954,0,0,0q�6J   
���   �$	��Top=�6l   $��39��6�    J� RenderTransformOrigin$ -0.388,0.64&�6�    � Cursor$
 Hand��6�   ��5      �� 5       j� TileMode$
 Tile=�6   $ Image/help.png��6-   5      5      5      