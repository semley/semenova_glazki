   M S B A M L   `   `   `  ����]  YСеменова_Глазки-save, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Семенова_Глазки_save"Семенова_Глазки_save  5      4    .Семенова_Глазки_save.ProdajiPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:Семенова_Глазки_save     5      -   5          N� Title$  ProdajiPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   �� -   5        $��AgentSaleListView��5      $��1��6,   ��5      �� 5      .R�5      �  5      �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��5q�6>   $��0��6I   $
��Left=�6V   .+�5      �� $ ��Наименование: ��6(   $��20(�6>   �� 5      $��20(�6G   ��6(   �� *Product.Title+6G   5      �� 5!      $ 
Horizontal=�6%   $��5q�6>   $��1��6I   $
��Left=�6V   .+�5"      �� $��Количество: ��6(   $��20(�6<   �� 5#      $��20(�6F   ��6(   �� *ProductCount+6F   5$      �� 5&      $ 
Horizontal=�6%   $��5q�6>   $��2��6I   $
��Left=�6V   .+�5'      �� $��
Дата: ��6(   $��20(�66   �� 5(      $��20(�6X   ��6(   �� *
SaleDate+ �� StringFormat$ {0:d}��6X   5)      �� 5*      $��DeleteButton��63   -   5        $��Удалить��5*   !   $��3��6c   $��Center=�6p   5,      5-      5/      �� 50   
   $��2��6   $ 
Horizontal=�6"   .+�51      �� -   5        $��	AddButton��51      $��Добавить��6&   $��10q�6:   6`   52      53      54      