   M S B A M L   `   `   `  ����B  >LawFarm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LawFarmLawFarm  5          LawFarm.BookingPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:LawFarm     5        N� Title$  BookingPage��5	      .��5      � ���#D1E7DD.+�5   
      LawFarm.Navbar  $��Stretch=�6   $	��Top=�65   � 5   
   $��0,50,0,0q�6    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   
����� �$��25,10,0,137q�6?   .+�5      �� $��Filter by Type��6   $
��Bold"�62   $��16(�6D   $��	0,10,0,20q�6R   �� 5      -   5         ��Name$ CriminalCheckBox��5      $��Criminal��65   $	��0,5q�6H   �� 5      -   5        $ CivilCheckBox��5      $��Civil��62   $	��0,5q�6B   �� 5      -   5        $ DivorceCheckBox��5      $��Divorce��64   $	��0,5q�6F   �� 5      -   5        $ ImmigrationCheckBox��5      $��Immigration��68   $	��0,5q�6N   �� 5      -   5        $ CorporateCheckBox��5      $��	Corporate��66   $	��0,5q�6J   �� 5       -   5        $ FamilyCheckBox��5       $��
Family Law��63   $	��0,5q�6H   �� 5!      -   5        $ 
IPCheckBox��5!      $��Intellectual Property��6/   $	��0,5q�6O   �� 5"      -   5        $ 
EPCheckBox��5"      $��
Employment��6/   $	��0,5q�6D   5#      �� 5$      -	   5        $��Apply Filter��5$      $	��120��6,   $��30��68   $��25,255,55,115q�6D   
����=H�
�������$
��Bold"�5%   K   5&      �� 5*      $��1��6   $��10q�6+   $
��Auto=�67   .��5+      �� .+�5-      �� $��Lawyers��6    $��Center=�6/   $��50(�6L   $��Georgia)�6Z   
���� ��$
��Bold"�6�   $��0,20,0,0q�6�   �� 5.      $��Select your choice��6    $��Center=�6:   $��20(�6W   $��Georgia)�6e   $��SemiBold"�6z   $��	0,10,0,20q�6�   �� 51      -
   5         ��Name$ LawyerListPanel��51   #   $��
20,10,20,0q�6<   ��52      �� 53      .R�54   "   �� ���#DDDDDD$��1q�6?    �� CornerRadius$ 10��6S    �� Padding$ 12q�6e   $��0,10,0,0q�6r   ���#F9F9F9._�55   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   .+�56   *   A� $��60��62   $��60��6=   
�������$��1��6W   $��0,0,15,0q�6k   ��57   .   �� 58   2    �� ImageSource$ Images/New.jpg��6=    j� Stretch$
 Fill=�6Z   5:   +   �� 5<   *   .+�5=   .   �� $
��Bold"�6R   $��16(�6d   ���#333��68   �� *
FullName+6r   �� 5>   .   
��������� 5?   2   $�
Category: ��66   $��SemiBold"�6H    �� 5@   2   �66   �� *
Categories+5A   /   �� 5B   .   ���#555�� 5C   2   $
�ID: ��66   $��SemiBold"�6B    �� 5D   2   �66   �� *
LawyerId+5E   /   �� 5F   .   
��� d ��� 5G   2   $�Rating: ��66   $��SemiBold"�6F    �� 5H   2   �66   �� *Rating+ �� 5I   2   $� ��66   5J   /   5K   +   5L   '   5M   #   5N      5P      5Q      5R      5S      �� 5V   
   -   5        $��Book Now��5V      $��40��6$   $��90��60   
���� ��
�������$
��Bold"�5W   8   $
��Left=�5X      $��Bottom=�6,   $��
535,0,0,10q�6G   5Y      5Z      5[      