   M S B A M L   `   `   `  ����  Steganography    Steganography.Encrypting   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  Encrypt��5   	    � Title$ Шифровка��5   	   $	��606��6   $
��1011��6'    � WindowStartupLocation$ CenterScreen=�6L    � WindowStyle$ 
ToolWindow=�6q   ��5      �� 5   
    �� ImageSource$ Image/Substrates.png��6   .��5      � .+�5	   
   �� -   5         ��Name$
 Img1��5	      $
��Left=�6   $	��510��69   $��	10,54,0,0q�6F   $	��Top=�6Y   $	��659��6q   $
��Fill=�6}   �� 5   
   -   5         ��Name$ OpenImg1��5      $%��Открыть картинку��6#   $
��Left=�6>   $��46��6Y   $��
674,54,0,0q�6e   $	��Top=�6y   $	��304��6�   $��Times New Roman)�6�   $��24(�6�   ���	#FF57F30E��6�   Z� ��6�   Z� 6  �� 5   
   $��Сообщение��6   $
��Left=�6$   $��674,105,0,0q�6?   $	��Top=�6T   $��Times New Roman)�6l   $��20(�6�   ���	#FFFBAB006�   �� 5   
   -   5         ��Name$ 	TextEncr1��5      $
��Left=�6%   $	��106��6@   $��674,143,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��319��6�   $��Times New Roman)�6�   $	 �� HorizontalScrollBarVisibility$	 Visible=�6�   ��. "
 �� VerticalScrollBarVisibility$
 Visible=�6  �� 5   
   -   5        $ AutoKey��5      $#��Генерация ключа��6"   $
��Left=�6<   $��36��6W   $��674,254,0,0q�6c   $	��Top=�6x   $	��319��6�   $��Times New Roman)�6�   $��24(�6�   ���	#FF3AFF00��6�   Z� ��6�   Z� 6  �� 5   
   $��Ключ��6   $
��Left=�6   $��701,295,0,0q�6:   $	��Top=�6O   ���	#FFFF9700$��Times New Roman)�6~   $��20(�6�   �� 5   
   -   5        $	 Key��5      $
��Left=�6   $��36��6:   $��674,328,0,0q�6F   $	��Top=�6[   $	��304��6s   $	 Visible=�6   $��Times New Roman)�6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ ClearKey��5      $��Очистить��6#   $
��Left=�66   $��38��6Q   $��674,369,0,0q�6]   $	��Top=�6r   $	��148��6�   $��Times New Roman)�6�   $��20(�6�   ���	#FF74FF00��6�   Z� ��6�   Z� 6  �� 5   
   -   5        $ SaveKey��5      $!��Сохранить ключ��6"   $
��Left=�6;   $��38��6V   $��829,369,0,0q�6b   $	��Top=�6w   $	��149��6�   $��Times New Roman)�6�   $��20(�6�   ���	#FF74FF00��6�   Z� ��6�   Z� 6
  �� 5   
   -	   5        $ 	Encrpting��5      $��Шифровать��6$   $
��Left=�68   $��45��6S   $��674,419,0,0q�6_   $	��Top=�6t   $	��304��6�   
���  ��$��Times New Roman)�6�   $��36(�6�   ��6�   Z� ��6�   Z� 6  �� 5   
   -
   5        $ 
MainScreen��5      $��Главное меню��6%   $
��Left=�6<   $��50��6W   $��674,514,0,0q�6c   $	��Top=�6x   $	��148��6�   $��Times New Roman)�6�   $��22(�6�   ���	#FFAEFF00��6�   Z� ��6�   Z� 6  �� 5   
   -   5        $ Ending��5      $��Завершить��6!   $
��Left=�65   $��50��6P   $��830,514,0,0q�6\   $	��Top=�6q   $	��148��6�   $��Times New Roman)�6�   $��22(�6�   ���	#FFAEFF00��6�   Z� ��6�   Z� 6  �� 5   
   -   5         ��Name$ Help2��5      $
��Left=�6#   $��34��6>   $��	954,0,0,0q�6J   
���   �$	��Top=�6l   $��39��6�    J� RenderTransformOrigin$ -0.388,0.64&�6�    � Cursor$
 Hand��6�   ��5      �� 5       j� TileMode$
 Tile=�6   $ Image/help.png��6-   5      �� 5   
   -   5        $ SaveImg��5      $)��#Сохранить картинку��6"   $
��Left=�6?   $��674,469,0,0q�6Z   $	��Top=�6o   $	��304��6�   $��45��6�   $��Times New Roman)�6�   $��24(�6�   ���	#FF8BFF00��6�   Z� ��6�   Z� 6  �� 5   
   $4��.Размер файла до шифровки:��6   $
��Left=�64   $��	10,23,0,0q�6O   $	��Top=�6b   
���  ��$��Times New Roman)�6�   $��20(�6�   �� 5   
   -   5         ��Name$ 	StartSize��5      $
��Left=�6#   $��31��6>   $��
265,23,0,0q�6J   $	��Top=�6^   $��65��6v   $��Times New Roman)�6�   $��20(�6�   �� 5   
   $��После:��6   $
��Left=�6!   $��31��6<   $��
335,23,0,0q�6H   $	��Top=�6\   $��74��6t   $ 0.426,0.481&�6   $��Times New Roman)�6�   $��20(�6�   
���  ����6�   Z� 6�   �� 5   
   -   5        $ EndSize��5      $
��Left=�6!   $��31��6<   $��
409,25,0,0q�6H   $	��Top=�6\   $��71��6t   $ 	0.5,0.532&�6   $��Times New Roman)�6�   $��20(�6�   
���  ����6�   Z� 6�   5!      5"      