   M S B A M L   `   `   `  ����S  Ocapuli_MidtermAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:capuli_MidtermAssignmentcapuli_MidtermAssignment  5   	   -    'capuli_MidtermAssignment.CustomerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:capuli_MidtermAssignment     5   	   -   5          �Name$  customerPage��5   	    � Title$ Customer Page��5   	   $	��450��6   $	��800��6,    � ContextMenu 5	      �� 5
   
   .@�5      m� -   5         m�Name$ mnuWinInsert��5      $��Insert��6-   6=   m� 5      -   5        $ mnuWinUpdate��5      $��Update��6-   6=   m� 5      -   5        $ mnuWinDelete��5      $��Delete��6-   6=   m� 5      -   5        $ mnuWinClose��5      $
��Quit��6,   6:   5      .��5      � 
���ؿ�� � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      .+�5   
   ]� $��False��6   $��	0,0,0,185q�6*   $��2��6=   .+�5      o� -   5         o�Name$ mainmenu��5      $	��800��6%   $��19��61   $��	0,-12,0,0q�6=   .@�5      m� -   5        $ menuFile��5      $
��File��6-   .@�5      m� -   5        $ menuNew��5      $
��_New��60   ${�False��6>   m� 5      -	   5        $ menuSave��5      $��_Save��61   ${�False��6@   m� 5      -
   5        $ menuQuit��5      $��E_xit��61   6@   5       m� 5!      -   5        $ menuEdit��5!      $��_Edit��6-   .@�5"      m� -   5        $ 
menuInsert��5"      $��Insert��63   6C   m� 5#      -   5        $ 
menuUpdate��5#      $��Update��63   6C   m� 5$      -   5        $ 
menuDelete��5$      $��Delete��63   6C   5%      m� 5&      -   5        $ menuHelp��5&      $
��Help��6-   6;   5'      5(      �� 5)   
   $��0��6   $��10,59,10,10q�6%   $��2��6:   .+�5*      �� -   5         ��Name$ lstCustomer��5*      $��Stretch=�5+      $��Visible=�5-      $��Disabled=�5.      $	��170��6L   ��5,      �� 5.   L   &   System.Windows.Controls.DataGrid  5/      $	��384��6   $��36��6$   51      �� 52   
   $��1��6   $��
10,24,10,0q�6%   .+�53      �� $��Name:��6   $��0,10,0,0q�6$   $
��Bold"�66   �� 54      -   5         ��Name$ tbName��54      6(   �� 55      $��Address:��6   $
��Bold"�6'   �� 56      -   5        $ 	tbAddress��56      6+   �� 57      $��Email:��6   $
��Bold"�6%   �� 58      -   5        $ tbEmail��58      6)   �� 59      $��Phone:��6   $
��Bold"�6%   �� 5:      -   5        $ tbPhone��5:      6)   5;      �� 5<   
   $��1��6   $��1��6%   $��10,12,10,20q�62   .+�5=      �� -   5        	 ��Name$	 	btnInsert��5=      $��Insert��6(   $��
10,0,10,10q�69   $	��145��6e   $��52��6q   
 � Cursor$

 Hand��6}   ���	#FFB5C0846�   �� 5>      -   5        $	 	btnUpdate��5>      $��Update��6(   $��
10,0,10,10q�69   $	��145��6e   $��52��6q   ���	#FF9BD4D36}   �� 5?      -   5        $	 	btnDelete��5?      $��Delete��6(   $��
10,0,10,10q�69   $	��145��6e   $��52��6q   ���	#FFFC594C6}   5@      5B      5C      