   M S B A M L   `   `   `  ����D  @Aiport_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Aiport_v2.pageFolderAiport_v2.pageFolder  5      &     Aiport_v2.pageFolder.pageManager   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Aiport_v2.pageFolder     5        N� Title$  pageManager��5	      .��5      � .+�5   
   �� .+�5      �� ���#F79420$��3q�5      $��90��5      $��5q�5      $	��Top=�5      ._�5   
   �� $��Center=�5      $	��Top=�5       �� Orientation$ 
Horizontal=�5      $��5q�5      .+�5      �� .+�5      �� $ 
Horizontal=�5      $��Right=�5      .+�5      �� $
��From��6       tbStyle#��[  6,   �� 5      -   5        $��cmbBorderFrom��5    !   $��5q�5!   !   
���  ��$��2q�5#   !   ._�5%      �� -   5        $��CmbFrom��5(      $��0q�5)      $	��126��5*        cmbStyle#��[ 5+      5,      5-      �� 5.      $��Right=�5/      $ 
Horizontal=�50      .+�51      �� $��Outbound��6    #��[  60   �� 52      -   5        $��tbDate��54      
���  ��  
tboxStyle1#��[ 56      57      58      �� 59      .+�5:      �� $��Right=�5;      $ 
Horizontal=�5<      .+�5=      �� $��To��6    #��[  6*   �� 5>      -   5        $��cmbBorderTo��5?   !   $��5q�5@   !   
���  ��$��2q�5B   !   ._�5C   "   �� -   5        $��CmbTo��5G      $	��126��5E      $��0q�5F      #��[ 5I      5J      5K      �� 5L      $ 
Horizontal=�5M      .+�5N      �� $��Flight number��6    #��[  65   �� 5O      -   5        $��
tbFlNumber��5P      
���  ��#��[ 5S      5T      5U      �� 5V      .+�5W      �� $��Right=�5X      $ 
Horizontal=�5Y      .+�5Z      �� $��Sort by��6    #��[  6/   �� 5[      -   5        $��cmbBorderSort��5\   !   $��5q�5]   !   
��� � �$��2q�5_   !   ._�5`   "   �� -   5        $��CmbSort��5a   %   $��0q�5b   %   $	��126��5c   %   #��[ 5d   %   5e      5f      �� 5g      $ 
Horizontal=�5h      $��Right=�5i      .+�5k      �� -	   5        $��btnCancelSort��5m      $��25��5n      $��20(�5o      $��Cancel��5p      $��70��5q        btnAdmin#��[ 5r      �� 5s      -
   5        $��BtnApply��5t      $��25��5v      $��20(�5w      $��Apply��5x      $��70��5y      #��[ 5z      5{      5|      5}      5~      �� 5   
   ._�5�   
   �� .+�5�      �� .+�5�      &   System.Windows.Controls.DataGrid  -   5        $��dataManager��5�         AutoGenerateColumns .  $��5 0 5 0q�5�      $��3q�5�      $	��260��5�      ���#F79420   RowStyle 5�      �� 5�   "    �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6(   .�5�   &   ��  �� Property � �� �� Value 6C   �� *
getBackg+�� 5�   &    � �� 6C   �� *
getForeg+-   5        5�   #      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6-   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6;   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6E   �� *	getDate+  5�      $
 Time��6-   $	 * 6;   
 6E   �� *Time+  5�      $
 From��6-   $	 * 6;   
 6E   �� *	getFrom+  5�      $ To��6-   $	 * 69   
 6C   �� *getTo+  5�      $ Flight number��6-   $	 * 6D   
 6N   �� *FlightNumber+  5�      $ Aircraft��6-   $	 * 6?   
 6I   �� *Aircraft.Name+  5�      $ Economy price��6-   $	 * 6D   
 6N   �� *getEc+  5�      $ Business price��6-   $	 * 6E   
 6O   �� *getBus+  5�      $ Firs class price��6-   $	 * 6G   
 6Q   �� *getFir+5�      5�      � 5�      .+�5�      �� $ 
Horizontal=�5�      .+�5�      �� -   5        $��CancelFl��5�      $��Cancel Flight��5�      $��32��5�      #��[ 5�      �� 5�      -   5        $��	btnEditFl��5�      $��Edit Flight��5�      $��32��5�      #��[ 5�      5�      �� 5�      -   5        $��	btnImport��5�      $��Right=�5�      $��Import Changes��5�      $��32��5�      #��[ 5�      5�      5�      5�      5�      5�      5�      