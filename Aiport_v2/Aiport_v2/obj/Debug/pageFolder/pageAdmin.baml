   M S B A M L   `   `   `  ����D  @Aiport_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Aiport_v2.pageFolderAiport_v2.pageFolder  5      $    Aiport_v2.pageFolder.pageAdmin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Aiport_v2.pageFolder     5        N� Title$  Window Admin��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��210 �6   �� 5      $
��609* �6   .+�5   
   �� ���#F79420$��4q�5      $��Center=�5      $��5q�5      $	��263��5      ._�5   
   � $��0��5      ���#196AA6.+�5   
   �� $��Bottom=�5      .+�5      �� $	��180��5      ���#F79420$��5q�5       ._�5!      ��  �� Orientation$ 
Horizontal=�5"      .+�5$      �� 
�������$��24(�5&      $��5 5 0 5q�5'      $��Office:��5(      �� 5*      -   5        $��	cmbOffice��5/       �� TextAlignment$ Center=�5,      $��	Tw Cen MT)�5-      $
��Bold"�5.      $��95��50      $��18(�51      $��2 5 5 5q�52      ���#196AA6
�������$��0q�55      #��� ��6)   56      57      �� 58      -   5        $��
btnAddUser��59      $��Add user��5;         btnAdmin#��[  5<      5>      �� 5?      -   5        $��btnEdit��5@      $��Change role��5B      #��[  5C      5E      �� 5F      -   5        $��	btnDisEna��5G      $��Enable/Disabled��5I      #��[  5J      5L      �� 5M      -   5        $��btnExit��5N      $��5 5 5 10q�5P      $
��Exit��5Q      #��[  5R      5S      5U      5V      5W      � 5X   
   $��1��5Y      .+�5Z      &   System.Windows.Controls.DataGrid  -   5        $��dataMain��5]      ���#F79420$��4q�5\      $y�Visible=�5^         AutoGenerateColumns .     
IsReadOnly .    CanUserAddRows .     CanUserResizeColumns .     CanUserResizeRows .  $��	0 20 2 20q�5d      	   RowStyle	 5e      �� 5f      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5g      ��  �� Property � �� �� Value 67   �� *	getBack+�� 5h       � �� 67   �� *	getFore+-   5        5j         Columns 5m      0  *System.Windows.Controls.DataGridTextColumn  5n      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *	FirstName+  5o      $ 	Last name��6)   $ * 6<    6F   �� *
LastName+  5p      $	 Age��6)   $ * 66    6@   �� *getAge+  5q      $ 	User Role��6)   $ * 6<    6F   �� *	Role.Name+  5r      $ Email Address��6)   $	 120 6@    6L   �� *Email+  5s      $ Office��6)   $ * 69    6C   �� *Office.Title+5u      5w       � 5x   
   -   5        $��frmAdmin��5~      ���#F79420$��4q�5z      $��	0 20 2 20q�5{      $y�Visible=�5|      $��1��5}      5~      5      5�      