   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	       TaskManager.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	   -   5          �Name$
  task��5   ?    � WindowState$ Normal=�5   1    � WindowStartupLocation$ CenterScreen=�5       � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)   $	��700��65   $	��800��6E   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��4* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��150��6   $��35��6#   $
��10 0q�6/   ��6=   �� *ProcessList+ �� Text 6a   �� *Name+�� 5      $	��120��6   $��35��6"   $��
10 20 0 20q�6.   
���/kU�
���/kU�$��Create process��5      
�������$��15(�6C   ��5      �� *Create+��6(   ��  �� ElementName$
 task���� 5      $	��120��6   $��35��6"   $��220 20 0 20q�6.   
���/kU�
���/kU�$��End process��5      
�������$��15(�6@   ��5      �� *End+��6%   �� $
 task���� 5      $	��120��6   $��35��6"   $��10 20q�6.   
���/kU�
���/kU�$��Add Blacklist��5!      
�������$��15(�6B   ��5"      �� *AddBlackList+��6.   �� $
 task��5%      �� 5&   
   $��1��65   ��6   �� *	Processes+ �� SelectedItem 6B   �� *selectedItem+	 �� View	 5'      �� 5(      .P�5)      �� $
��Name��6%   
 �� Width$	
 150��6`    �� DisplayMemberBinding 63   �� *ProcessName+6`   �� 5*      $��Id��6%   $	
 100��6U    61   �� *Id+6U   �� 5+      $��Machine Name��6%   $	
 100��6h    6;   �� *MachineName+6h   5,      5.      50      51      