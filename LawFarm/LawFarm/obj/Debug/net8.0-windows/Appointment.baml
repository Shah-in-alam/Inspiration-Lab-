   M S B A M L   `   `   `  ����B  >LawFarm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LawFarmLawFarm  5          LawFarm.Appointment   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:LawFarm     5        N� Title$  Appointment��5	      .��5
      � ���#D1E7DD.+�5   
      LawFarm.Navbar  $��Stretch=�6   $	��Top=�65   �� 5   
   $��Appointment��6   $��Center=�6'   $	��Top=�6D   $��50(�5      $��0,60,0,0q�6   $��Georgia)�5      
����=H�$
��Bold"�6@   �� 5   
   $��Center=�6   $��Center=�62   $��	0,100,0,0q�6M   .+�5      �� $	��500��6    �� Padding$ 20q�6!   
������� �� CornerRadius$ 10��6A   ���#CCCCCC$��1q�5   +    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6'      
BlurRadius$ 8Q�65      ShadowDepth$ 4Q�6D      Opacity$	 0.3Q�6T   ._�5      �� .+�5      �� $��
Your Name:��6    $
��Bold"�62   $��0,5,0,2q�6D   �� 5      -   5         ��Name$ NameBox��5      $��30��6/   �� 5"      $��Select Lawyer ID:��6    $
��Bold"�69   $��0,10,0,2q�6K   �� 5#      -   5        	 ��Name$	 LawyerIdBox��5#      $��30��64   �� 5&      $��Select Date:��6    $
��Bold"�64   $��0,10,0,2q�6F   (  "System.Windows.Controls.DatePicker  5'      -   5        
  Name$
 
DatePicker��5'   !   $��30��65   �� 5*      $��Description:��6    $
��Bold"�64   $��0,10,0,2q�6F   �� 5+      -   5        $ DescriptionBox��5+      $��80��66    �� AcceptsReturn$
 True��6B    �� TextWrapping$
 Wrap=�6W   5-      5.      �� 51      -   5        $��Confirm��51      $��35��6'   $	��120��63   
���� ��
�������$
��Bold"�52   <   $��0,20,0,0q�53      54      55      56      57      