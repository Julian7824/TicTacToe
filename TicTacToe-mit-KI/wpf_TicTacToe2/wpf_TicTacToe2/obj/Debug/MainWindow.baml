   M S B A M L   `   `   `  ����I  Ewpf_TicTacToe2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:wpf_TicTacToe2wpf_TicTacToe2  5   	       wpf_TicTacToe2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:wpf_TicTacToe2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      � -   5         �Name$
 Grid��5
      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ DarkRed��6    � Offset$ 0Q�6/   � 5      $	 Red��6   $ 1Q�6+   5       J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      .+�5   
   �� -   5         ��Name$ lPatts��5      $�� ��6   $��15(�6+   $��	50,22,0,0q�69   6N   �� 5   
   -   5        $ lXwinns��5      $�� ��6   $��15(�6,   $��
130,22,0,0q�6:   6P   �� 5   
   -   5        $ lOwinns��5      $�� ��6   $��15(�6,   $��
300,22,0,0q�6:   6P   �� 5   
   -   5         ��Name$ bSpielStarten��5   <   $��Arial)�6   $��Spiel Starten��6$   $
��Left=�6k   $��61��6�   $��	10,62,0,0q�6�   $	��Top=�6�   $��86��6�   ���	#FFE67500$��3,3,3,3q�6�   
���   �
���   � 5        5      5      �� 5   
   -   5        $ 
bNeueRunde��5   9   $��Arial)�6   $��
Neue Runde��6$   $y�Visible=�6_   $
��Left=�6t   $��60��6�   $��
10,136,0,0q�6�   $	��Top=�6�   $��86��6�   ���	#FFE67500
���   �$��3,3,3,3q�6�    5        5      5       5!      5"      