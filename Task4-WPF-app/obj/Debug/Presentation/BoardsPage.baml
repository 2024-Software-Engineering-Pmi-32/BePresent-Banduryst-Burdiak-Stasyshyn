   M S B A M L   `   `   `  ����  bepresent_wpf+    %bepresent_wpf.Presentation.BoardsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Boards��5      $	��500��6   $
��1000��6#   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��3* �6   �� 5	      $��1* �6   .+�5   
   �� $��0��6   $��10q�6%   .+�5      �� $��Boards��6   $
��Bold"�6&   $��16(�68   $��0,0,0,10q�6F   �� 5      -   5         ��Name$ BoardsListView��5       �� DisplayMemberPath$
 name��6/   $	��Top=�5      6/   �� 5      -   5        $��Create Board��5      $��0,10,0,0q�6I   5      �� 5   
   $��1��6   $��10q�6%   .+�5      �� $��Board Details��6   $
��Bold"�6-   $��16(�6?   $��0,0,0,10q�6M   �� 5      $��Name:��6   $
��Bold"�6%   �� 5      -   5         ��Name$ BoardNameTextBlock��5      $��0,0,0,10q�64   �� 5      $��Description:��6   $
��Bold"�6,   �� 5      -   5        $ BoardDescriptionTextBlock��5      $��0,0,0,10q�6;   �� 5      $��Celebration Date:��6   $
��Bold"�61   �� 5      -   5        $# BoardCelebrationDateTextBlock��5      $��0,0,0,10q�6?   �� 5       $��Access Level:��6   $
��Bold"�6-   �� 5!      -   5        $ BoardAccessLevelTextBlock��5!      $��0,0,0,10q�6;   �� 5#      $��Created At:��6   $
��Bold"�6+   �� 5$      -   5        $ BoardCreatedAtTextBlock��5$      $��0,0,0,10q�69   �� 5&      $��Gifts:��6   $
��Bold"�6&   $��0,10,0,5q�68   �� 5'      -   5        $ GiftsListView��5'      $
 name��6.   $��0,0,0,10q�6G   �� 5(      -	   5        $��Add Gift��5(      $��0,10,0,0q�6D   5)      5*      5+      