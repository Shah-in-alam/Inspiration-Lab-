   M S B A M L   `   `   `  ����  LawFarm    LawFarm.StartPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  	StartPage��5      $	��470��6   $	��775��6&    � 	Resources 5         WelcomeAnimation �� 
TargetName �� TargetProperty W� From	 W� To g� Duration  ButtonAnimation g� 	BeginTime��%�  &	        &	 �    �� 5   
   .��5	      W� $ WelcomeText��6   $ Opacity�5
       05       16'   $ 0:0:1D�5      W� 5      $ WelcomeText��6   $- 'RenderTransform.(ScaleTransform.ScaleX)�5       0.85       16)   $ 0:0:0.8D�5      W� 5      $ WelcomeText��6   $- 'RenderTransform.(ScaleTransform.ScaleY)�5       0.85       16)   $ 0:0:0.8D�5      5      �� 5   
   .��5      W� $ ButtonPanel��6   $ Opacity�5       05       16'   $ 0:0:1D�5       0:0:0.56/   W� 5      $ ButtonPanel��6   $, &RenderTransform.(TranslateTransform.Y)�5       405        06(   $ 0:0:0.5D�5!       0:0:0.561   5"      5#      .��5%      � -   5        ���#E6F4EA � RowDefinitions 5&   
   �� 5'      $
��Auto �6   �� 5(      $��* �6   .+�5,   
   �� $��Images/Main.jpg��6   $	��180��5-      $��UniformToFill=�5.      $��0q�5/      $��Center=�50      $	��Top=�51      �� 54   
   $	��Top=�6   $��Center=�6-   $��1��6J   $��0,20,0,0q�6W   .+�56      �� -   5        	 ��Name$	 WelcomeText��56      $��Welcome to Law Firm��57      $��28(�58      $��SemiBold"�59      $��Segoe UI)�5:      ���#2E3B55$��Center=�5<      
 J� Opacity$
 0Q�5=      z�5>      �� 5?       �� ScaleX$	 0.8Q�6%    �� ScaleY$	 0.8Q�62   5A      �� 5D      -   5         ��Name$ ButtonPanel��5D       �� Orientation$ 
Horizontal=�5E      $��Center=�5F      $��0,25,0,0q�5G      $
 0Q�5H      z�5I      T� 5J       T� Y$ 40Q�6)   .+�5M      �� -   5        $��Login��5M      $	��130��5N      $��42��6%   ���#2E7D32
�������$
��Bold"�5Q      $��0q�5R       � Cursor$
 Hand��5S      $��0,0,15,0q�5T      5U      �� 5W      -   5        $��Sign Up��5W      $	��130��5X      $��42��6%   ���#1565C0
�������$
��Bold"�5[      $��0q�5\      $
 Hand��5]      5^      5_      5`      5a      5b      