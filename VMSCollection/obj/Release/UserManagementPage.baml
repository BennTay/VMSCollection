   M S B A M L   `   `   `  ���� H  DVMSCollection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:VMSCollectionVMSCollection  &     VMSCollection.UserManagementPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:VMSCollection       N� Title$  UserManagementPage��.��� ���	#FF5ED14C � ColumnDefinitions �� $��20 ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $��* ��� $
��auto ��� $
��auto ��� $��20 �.+��� $��1��$��1��$��User Management��$��20(�$��Yu Gothic UI Semibold)��� $��1��$��2�� �� Orientation$ 
Horizontal=�.+��� -   $��uNameHeader��$��Username��
������$	��150��$��Center=� �� 
IsReadOnly . $
��Bold"��� -   $��pwHeader��$��Password��
������$	��150��$��Center=� . $
��Bold"��� -   $��
roleHeader��$
��Role��
������$	��150��$��Center=� . $
��Bold"��� $��1��$��3��.���� -   $��userListView��$ Vertical=�� $��1��$��4��$	��0,5q� �� $
��auto ��� $
��auto � �� $��* ��� $
��auto �.+��� $��0��$��0��$ Vertical=�.+��� $��Username��$��25��$
��0, 5q��� $��Password��$��25��$
��0, 5q��� $
��Role��$��25��$
��0, 5q��� $��1��$��0��$ Vertical=�.+��� -   $��
uNameEntry��$��25��$
��0, 5q�$
��Left=�$	��200���� -   $��pwEntry��$��25��$
��0, 5q�$
��Left=�$	��200���� -   $��	roleEntry��$��25��$
��0, 5q�$
��Left=�$	��200��.@��� $��Guard���� $��	Releasing���� $��Admin���� -   $��0��$��1��$	��100��$��25��$��Add user���� -	   $��1��$��5��$	��100��$��25��$
��Left=�$��Go back��$��0,10,0,0q�