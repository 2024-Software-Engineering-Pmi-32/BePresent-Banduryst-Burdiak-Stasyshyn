   M S B A M L   `   `   `  ����   bepresent_wpf+    %bepresent_wpf.Presentation.BoardsPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  Boards��$	��500��$
��1000�� � 	Resources    ButtonClickAnimation �� TargetProperty W� From	 W� To g� Duration g� AutoReverse  BoardSelectionAnimation �� From	 �� To  BoardNameTextAnimation  BoardNameTextResetAnimation  GiftSelectionAnimation  GiftNameTextAnimation  GiftNameTextResetAnimation��%  &	        &	 |     &	 �     &	 �    &	 )    &	 �    &	 8    �� .��W� $ Width�$	 150X�$	 200X�$ 0:0:0.9D� . W� $ Height�$ 40X�$	 100X�$ 0:0:0.9D� . �� .���� $7 1(ListViewItem.Background).(SolidColorBrush.Color)�$ WhiteX�$ 	LightGrayX�$ 0:0:0.3D��� .���� $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�$ BlackX�$ DarkBlueX�$ 0:0:0.3D�W� $ FontSize�$ 16X�$ 20X�$ 0:0:0.3D��� .���� $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�$ DarkBlueX�$ BlackX�$ 0:0:0.3D�W� $ FontSize�$ 20X�$ 16X�$ 0:0:0.3D��� .���� $7 1(ListViewItem.Background).(SolidColorBrush.Color)�$ WhiteX�$ 	LightCyanX�$ 0:0:0.3D��� .���� $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�$ BlackX�$ 	TurquoiseX�$ 0:0:0.3D�W� $ FontSize�$ 16X�$ 20X�$ 0:0:0.3D��� .���� $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�$ 	TurquoiseX�$ BlackX�$ 0:0:0.3D�W� $ FontSize�$ 20X�$ 16X�$ 0:0:0.3D�.��� 	 � ColumnDefinitions	 �� $��2* ��� $��3* ��� $��1* �.+��� $��0��$��10q�.+��� $��Boards��$
��Bold"�$��16(�$��0,0,0,10q��� -   
 ��Name$
 BoardsListView�� �� DisplayMemberPath$
 name��$	��Top=�����  �� 
TargetType" �� �� Triggers ��  �� Binding �� *
IsSelected+ �� RelativeSource �� *Self+ �� Value True N� EnterActions �� #��[ �� #��[  N� ExitActions �� #��[ �� -   $��AddBoardButton��$��Create Board��$��0,10,0,0q��� $��1��$��10q�.+��� $��Board Details��$
��Bold"�$��16(�$��0,0,0,10q��� $��Name:��$
��Bold"��� -    ��Name$ BoardNameTextBlock��$��0,0,0,10q��� $��Description:��$
��Bold"��� -   $ BoardDescriptionTextBlock��$��0,0,0,10q��� $��Celebration Date:��$
��Bold"��� -   $# BoardCelebrationDateTextBlock��$��0,0,0,10q��� $��Access Level:��$
��Bold"��� -   $ BoardAccessLevelTextBlock��$��0,0,0,10q��� $��Created At:��$
��Bold"��� -   $ BoardCreatedAtTextBlock��$��0,0,0,10q��� $��Gifts:��$
��Bold"�$��0,10,0,5q��� -   $
 GiftsListView��$
 name��$��0,0,0,10q����� " �� ��  �� *
IsSelected+ �� *Self+ True �� #��[ �� #��[  �� #��[ �� -	   $��AddGiftButton��$��Add Gift��$��0,10,0,0q�