   M S B A M L   `   `   `  ����B  >LawFarm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LawFarmLawFarm  5          LawFarm.BookingPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:LawFarm     5        N� Title$  BookingPage��5	      .��5      � 
�������.+�5   
      LawFarm.Navbar  $��Stretch=�6   $	��Top=�65   � 5   
   $��0,50,0,0q�6    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   ���#F0F0F0$��25,10,0,145q�6>   .+�5      �� $��Filter by Type��6   $
��Bold"�62   $��16(�6D   $��	0,10,0,20q�6R   �� 5      $��Criminal��6   $	��0,5q�6.   �� 5      $��Civil��6   $	��0,5q�6+   �� 5      $��Divorce��6   $	��0,5q�6-   $��14��6:   �� 5       $��Immigration��6   $	��0,5q�61   �� 5!      $��	Corporate��6   $	��0,5q�6/   �� 5"      $��
Family Law��6   $	��0,5q�60   �� 5#      $��Intellectual Property��6   $	��0,5q�6;   5$      � 5'      $��1��6   $��10q�6#   .+�5(      �� .+�5*      �� $��Lawyers��6    $��Center=�6/   $��50(�6L   $��Georgia)�6Z   
���� ��$
��Bold"�6�   $��0,20,0,0q�6�   �� 5+      $��Select your choice��6    $��Center=�6:   $��20(�6W   $��Georgia)�6e   $��SemiBold"�6z   $��	0,10,0,20q�6�   �� 5.      -   5         ��Name$ LawyerListPanel��5.   #   $��
20,10,20,0q�6<   ��5/      �� 50      .R�51   "   �� 
�������$��1q�6A    �� CornerRadius$ 8��6U   $��0,10,0,0q�6f   ���#FAFAFA �� Padding$ 10q�6�   ._�52   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   .+�54   *   A� $��60��62   $��60��6=   
�������$��1��6W   $��0,0,15,0q�6k   ��55   .   �� 56   2    �� ImageSource$ Images/New.jpg��6=    j� Stretch$
 Fill=�6Z   58   +   �� 5:   *   .+�5;   .   �� $
��Bold"�6R   $��16(�6d   ��68   �� *
FullName+6d   �� 5<   .   �� 5=      $
�ID: ��6"   $��SemiBold"�6.    �� 5>      �6"   �� *
LawyerId+5?   /   �� 5@   .   �� 5A      $�Rating: ��6"   $��SemiBold"�62    �� 5B      �6"   �� *Rating+ �� 5C      $�%��6"   5D   /   5E   +   5F   '   5G   #   5H      5J      5K      5L      5M      �� 5P   
   -   5        $��Book Now��5P      $��40��6$   $��90��60   
���� ��
�������$
��Bold"�5Q   8   $
��Left=�5R      $��Bottom=�6,   $��
535,0,0,10q�6G   5S      5T      5U      