   M S B A M L   `   `   `  ����D  @Aiport_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Aiport_v2	Aiport_v2  5   	       Aiport_v2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Aiport_v2     5   	     � Title$  
MainWindow��5   	    � 
ResizeMode$ NoResize=�5	   	   $	��550��5
   	   $	��800��5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��35px �6   �� 5      $	��80* �6   �� 5      $
��284* �6   .+�5   
   � -   5        $��gridMove��5      $��0��5      ���#196AA6.+�5      ��  �� Orientation$ 
Horizontal=�5      .+�5      �� $��./resFolder/white.png��5      $��5q�5      $��23��5      �� 5      -   5        $��tbMain��5#      $��Center=�5       
�������$��24(�5"      $��10 0 0 0q�5$      ��5%      ��  �� ElementName$ frmMain�� �� Path$ Content.Title�5'      5(      �� 5)      $��Right=�5*      .+�5+      �� -   5        $��btnClose��5,      $��25��5.      $��25��5/      $��0 5 10 5q�50      
�������
������ $��0q�53      ���#196AA6$��	ExtraBold"�55      .��6,   X57      58      59      � 5:   
   $��1��5;      ���#F79420.+�5=      �� -   5        $��stcImg��5>      $��Center=�5?      $��Center=�5@      .+�5A      �� $
��92px��5B      $ ��./resFolder/logo-white.png��5C      5D      5F       � 5G   
   -   5        $��frmMain��5J      ���#196AA6$��3��5I        � NavigationUIVisibility$ Hidden=�5L      5M      5N      