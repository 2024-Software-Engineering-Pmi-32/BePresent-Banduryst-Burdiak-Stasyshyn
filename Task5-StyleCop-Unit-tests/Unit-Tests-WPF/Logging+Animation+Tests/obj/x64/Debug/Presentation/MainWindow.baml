   M S B A M L   `   `   `  ����  bepresent_wpf+    %bepresent_wpf.Presentation.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Gift Board��5   	   $	��700��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5         AnimatedButtonStyle �� 
TargetType �� Property �� Value �� Triggers :� RoutedEvent �� TargetProperty	 W� From	
 W� To g� Duration��%�  &	        �� 5   
   " ��6,   .�5      ��  � ��$ 40��6'   �� 5       � ��$	 200��6&   �� 5	       � ��
 ��  �6+   �� 5
       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 0,10,0,0q�6'    5      :� 5      $ Button.MouseEnter��6   .[�5      �� .��5      �� .��5      W� $ Height�5      $	 40X�5      $
 55X�6'   $ 0:0:0.5D�5      5      5      5      :� 5      $ Button.MouseLeave��6   .[�5      �� .��5      �� .��5      W� $ Height�5      $	 55X�5      $
 40X�6'   $ 0:0:0.5D�5      5       5!      5"      5$      5%      .��5(      � $	��100q�6   .+�5)   
   � -   5         �Name$ MainContent��5)      $y�Visible=�6$   .+�5*      �� $	��Top=�6   $��Center=�61   $	��200��6N   .+�5+      �� $?��9C:/Users/Юліана/Downloads/Telegram Desktop/logo.jpg��6   $	��Top=�6U   $��40��6m   �� 5,      $��We're glad to see you!��6   $��20(�5-      $
��Bold"�5.      $��0,20,0,0q�5/      50      �� 51      $��Center=�6   $��Center=�64   $	��200��6Q   .+�52      �� -   5        $��Login��52      #��[  6)   6V   �� 53      -   5        $��Register��53      #��[  6,   6Y   54      55       � 56   
   -   5          �Name$ ContentFrame��56        � NavigationUIVisibility$ Hidden=�6&   $��0,60,0,0q�6F   $y�	Collapsed=�6X   57      58      