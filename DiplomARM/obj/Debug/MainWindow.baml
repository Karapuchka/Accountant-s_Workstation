   M S B A M L   `   `   `  ����D  @DiplomARM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DiplomARM	DiplomARM  5   	       DiplomARM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DiplomARM     5   	     � Title$  Авторизация��5   	   $	��460��6   $	��350��6*    � WindowStartupLocation$ CenterScreen=�66    � Icon$ Resurs/logo.png��5	   	    � WindowStyle$ 
ToolWindow=�6    $	��460��69   $	��350��6I   $	��460��6X   $	��350��6h   .��5
      � ���	#FFFBB857.+�5   
   �� $D��>C:\Users\User\source\repos\DiplomARM\DiplomARM\Resurs\logo.png��6   $	��Top=�5      $	��150��6(   $��Center=�64   $��
93,20,93,0q�6Q    � ToolTip$Y SГерб Новоджерелиевского сельского поселения��5      �� 5   
   $��Georgia)�6   $��20(�6%   $��101,133,99,241q�63   .��6K   Авторизация6X   �� 5   
   $D��>C:\Users\User\source\repos\DiplomARM\DiplomARM\Resurs\user.png��6   $��Center=�6X   $��43,184,251,196q�6u   $��42��6�   �� 5   
   $H��BC:\Users\User\source\repos\DiplomARM\DiplomARM\Resurs\password.png��6   $��37��5      $��Bottom=�6   $��Center=�67   $��46,0,248,138q�6T   $��42��6j   �� 5   
   $��Center=�6   $��Center=�6-   $��
0,0,110,56q�6H   .��6\   Логин:6d   �� 5   
   -   5         ��Name$ TextBoxLogin��5      $	��150��6(   $��20(�64   $	��Top=�6B   $��	0,195,0,0q�6Z   �� 5   
   $��Center=�6   $��Center=�6-   $��88,228,194,166q�6H   .��6`   Пароль:6i   G� 5   
   -   5         G�Name$ TextBoxPassword��5      $��20(�6/   $��93,254,93,138q�6=   �� 5   
   -   5         ��Name$ ButtonEnter��5      $��30��6&   $��16(�62   $��Bottom=�6@   $��
96,0,99,21q�5       � Cursor$
 Hand��6?   	 �� 	IsDefault	 . .��6^   
Вход6d   �� 5   
   $F��@C:\Users\User\source\repos\DiplomARM\DiplomARM\Resurs\status.png��6   $��40��5      $��Bottom=�6   $��Center=�64   $��43,0,251,76q�6Q   $��42��6f   �� 5    
   $��Center=�6   $��Center=�6-   $��88,288,148,106q�6H   $$��Статус аккаунта:��6`   $	��100��6{   �� 5!   
   -   5        
 ��Name$
 ComboBoxStatus��5!      $��15(�6+   $��93,314,93,79q�69   $
 Hand��6O   .@�5"      �� .��6   Пользователь6"   �� 5#      .��6   Администратор6#   5$      5%      5&      