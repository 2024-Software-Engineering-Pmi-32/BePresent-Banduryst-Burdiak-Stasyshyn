   M S B A M L   `   `   `  ����  bepresent_wpf+    %bepresent_wpf.Presentation.BoardsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Boards��5      $	��500��6   $
��1000��6#    � 	Resources 5         ButtonClickAnimation �� TargetProperty W� From	 W� To g� Duration g� AutoReverse  BoardSelectionAnimation �� From	 �� To  BoardNameTextAnimation  BoardNameTextResetAnimation  GiftSelectionAnimation  GiftNameTextAnimation  GiftNameTextResetAnimation��%b  &	        &	 �     &	 �    &	 �    &	 ~    &	 $    &	      �� 5   
   .��5      W� $ Width�5      $	 150X�5	      $	 200X�6   $ 0:0:0.9D�6%    . 68   W� 5
      $ Height�5      $ 40X�5      $	 100X�6   $ 0:0:0.9D�6$    . 67   5      �� 5   
   .��5      �� $7 1(ListViewItem.Background).(SolidColorBrush.Color)�5      $ WhiteX�5      $ 	LightGrayX�6   $ 0:0:0.3D�6-   5      �� 5   
   .��5      �� $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�5      $ BlackX�5      $ DarkBlueX�6   $ 0:0:0.3D�6,   W� 5      $ FontSize�5      $ 16X�5      $ 20X�6   $ 0:0:0.3D�6#   5      �� 5   
   .��5      �� $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�5       $ DarkBlueX�5!      $ BlackX�6!   $ 0:0:0.3D�6,   W� 5"      $ FontSize�5#      $ 20X�5$      $ 16X�6   $ 0:0:0.3D�6#   5%      �� 5'   
   .��5(      �� $7 1(ListViewItem.Background).(SolidColorBrush.Color)�5)      $ WhiteX�5*      $ 	LightCyanX�6   $ 0:0:0.3D�6-   5+      �� 5-   
   .��5.      �� $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�5/      $ BlackX�50      $ 	TurquoiseX�6   $ 0:0:0.3D�6-   W� 51      $ FontSize�52      $ 16X�53      $ 20X�6   $ 0:0:0.3D�6#   54      �� 56   
   .��57      �� $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�58      $ 	TurquoiseX�59      $ BlackX�6"   $ 0:0:0.3D�6-   W� 5:      $ FontSize�5;      $ 20X�5<      $ 16X�6   $ 0:0:0.3D�6#   5=      5>      .��5@      � 	 � ColumnDefinitions	 5A   
   �� 5B      $��2* �6   �� 5C      $��3* �6   �� 5D      $��1* �6   .+�5G   
   �� $��0��6   $��10q�6%   .+�5H      �� $��Boards��6   $
��Bold"�6&   $��16(�68   $��0,0,0,10q�6F   �� 5I      -   5        
 ��Name$
 BoardsListView��5I       �� DisplayMemberPath$
 name��6/   $	��Top=�5J      ��5K      �� 5L       �� 
TargetType" ��6    �� Triggers 5M      �� 5N       �� Binding 6*   �� *
IsSelected+ �� RelativeSource �� *Self+ �� Value True6o    N� EnterActions 5O   "   �� 5P   &   #��[ 66   �� 5Q   &   #��[ 66    N� ExitActions 5S   "   �� 5T   &   #��[ 66   5V      5X      5Z      �� 5[      -   5        $��AddBoardButton��5\      $��Create Board��5[      $��0,10,0,0q�6I   5\      5]      �� 5_   
   $��1��6   $��10q�6%   .+�5`      �� $��Board Details��6   $
��Bold"�6-   $��16(�6?   $��0,0,0,10q�6M   �� 5a      $��Name:��6   $
��Bold"�6%   �� 5b      -   5         ��Name$ BoardNameTextBlock��5b      $��0,0,0,10q�64   �� 5c      $��Description:��6   $
��Bold"�6,   �� 5d      -   5        $ BoardDescriptionTextBlock��5d      $��0,0,0,10q�6;   �� 5e      $��Celebration Date:��6   $
��Bold"�61   �� 5f      -   5        $# BoardCelebrationDateTextBlock��5f      $��0,0,0,10q�6?   �� 5g      $��Access Level:��6   $
��Bold"�6-   �� 5h      -   5        $ BoardAccessLevelTextBlock��5h      $��0,0,0,10q�6;   �� 5i      $��Created At:��6   $
��Bold"�6+   �� 5j      -   5        $ BoardCreatedAtTextBlock��5j      $��0,0,0,10q�69   �� 5k      $��Gifts:��6   $
��Bold"�6&   $��0,10,0,5q�68   �� 5l      -   5        $
 GiftsListView��5l      $
 name��6.   $��0,0,0,10q�6G   ��5m      �� 5n      " ��6    5o      �� 5p       6*   �� *
IsSelected+ �� *Self+ True6o    5q   "   �� 5r   &   #��[ 66   �� 5s   &   #��[ 66    5u   "   �� 5v   &   #��[ 66   5x      5z      5|      �� 5}      -	   5        $��AddGiftButton��5}   V   $��Add Gift��6   $��0,10,0,0q�6D   6V   5~      5      5�      