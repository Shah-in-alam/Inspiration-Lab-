   M S B A M L   `   `   `  ����B  >LawFarm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LawFarmLawFarm  5          LawFarm.ProgressPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:LawFarm     5        N� Title$  ProgressPage��5	       N� 
Background �#F0F4F8.��5      � .+�5   
   ]� ���#2E7D32$��50��6)   $	��Top=�65   .+�5      �� $��Progress Dashboard��6   $��20(�5      $
��Bold"�5      
�������$��Center=�5      $��20,0,0,0q�5      �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��Right=�6N   $��0,0,15,0q�6e   $��Center=�6w   .+�5      �� -   5        $��Lawyer Dashboard��5      $	��140��5      $��30��6   ���#1976D2
�������$
��Bold"�5      $��0,0,10,0q�5      5      �� 5      -   5        $��Logout��5      $��80��5      $��30��6   ���#D32F2F
�������$
��Bold"�5"      5#      5$      5%      � 5(   
   $��20,70,20,20q�6    � ColumnDefinitions 5)      �� 5*      $��2* �6#   �� 5+      $
��0.5* �6#   �� 5,      $��3* �6#   .+�50      �� $��0��6   $��Center=�6)   $	��Top=�6F   .+�51      �� $��Progress��6   $��24(�52      $
��Bold"�53      ���#2E3B55$��0,0,0,20q�55      $��Center=�56      � 58      $	��200��6   $	��200��6#   .+�59      A� ���#E0E0E06   �� 5:      -   5         ��Name$ ProgressText��5:       $��0%��5;       $��36(�5<       $
��Bold"�5=       ���#388E3C$��Center=�5?       $��Center=�5@       5A      �� 5C      -   5         ��Name$ ProgressSlider��5C       � Minimum$ 0Q�5D       � Maximum$	 100Q�6%   $	��200��5F      $��0,20,0,0q�5G      �� 5H      -   5        $ SuccessMessage��5H      $��Congratulations!��5I      $��18(�5J      $
��Bold"�5K      
��� � �$y�	Collapsed=�5M      $��0,10,0,0q�5N      $��Center=�5O      5P      �� 5S      $��2��6   
������� �� CornerRadius$ 8��5U      ���#B0BEC5$��1q�5W      	 �� Padding$	 15q�5X      ._�5Y      � 
 � RowDefinitions
 5Z      �� 5[      $��* �6(   �� 5\      $
��Auto �6(   .+�5`      �� $
��Auto=�6#   $��0��6F   .��5a      �� -   5         ��Name$ ChatHistory��5a   %   5c      5d      ]� 5g      $��1��6    $��0,10,0,0q�6-   .+�5h      �� -   5         ��Name$ 	ChatInput��5h   "   $��40��5i   "   $��0,0,10,0q�5j   "   $��10q�5k   "   $	��109��5l   "   $
��Left=�5m   "   
����������#B0BEC55o   "   �� 5q      -   5        $
��Send��5q   !   $��70��5r   !   $��40��5s   !   ���#1565C0
�������$
��Bold"�5v   !   5w   !   5x      5y      5z      5{      5|      5}      