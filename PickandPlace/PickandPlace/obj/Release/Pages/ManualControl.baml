   M S B A M L   `   `   `  ���� G  CPickandPlace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:PickandPlace.ImageButtonPickandPlace.ImageButton  M+clr-namespace:PickandPlace.ImageButtonBasicPickandPlace.ImageButtonBasic  &     PickandPlace.Pages.ManualControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  Z VFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  /my&clr-namespace:PickandPlace.ImageButton  4mz+clr-namespace:PickandPlace.ImageButtonBasic  -     >�Name$  	mainframe��.��]� ��.  .+��� $	��Top=�.+��� $��Manual Control��   Heading2#��[  �  � RowDefinitions �� $
��Auto � � ColumnDefinitions �� $	��450 ��� $��* �.+�� $��0��$��0�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��X / Y��$��0��$��0��$��5q� �� TextAlignment$ Center=�$��Center=�$��3��4   .PickandPlace.ImageButtonBasic.ImageButtonBasic  -     Name$ bt_Left��4   .PickandPlace.ImageButtonBasic.ImageButtonBasic   PreviewMouseDown$$ bt_MoveYMinus_PreviewMouseDown��   PreviewMouseUp$ bt_MoveStop��   Image$ /Resources/left.png��   
ImageWidth$ 64Q�	   ImageHeight$	 64Q�$��5q�$��1��$��0��$��2��  -   $ bt_Right��$# bt_MoveYPlus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/right.png��$ 64Q�$	 64Q�$��5q�$��1��$��2��$��2��  -   $ bt_Up��$# bt_MoveXPlus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/up.png��$ 64Q�$	 64Q�$��5q�$��1��$��1��  -   $ bt_Down��$$ bt_MoveXMinus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/down.png��$ 64Q�$	 64Q�$��5q�$��2��$��1��$��Bottom=��� $��Z��$��0��$��3��$��5q�$ Center=�$��Center=�  -   $ bt_ZUp��$$ bt_MoveZMinus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/up.png��$ 64Q�$	 64Q�$��5q�$��1��$��3��  -   $ bt_ZDown��$# bt_MoveZPlus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/down.png��$ 64Q�$	 64Q�$��5q�$��2��$��3��$��Bottom=��� $��A��$��0��$��4��$��5q�$ Center=�$��Center=�  -   $ bt_AUp��$$ bt_MoveAMinus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/up.png��$ 64Q�$	 64Q�$��5q�$��1��$��4��  -	   $ bt_ADown��$# bt_MoveAPlus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/down.png��$ 64Q�$	 64Q�$��5q�$��2��$��4��$��Bottom=��� $��B��$��3��$��0��$��5q�$��2��$ Center=�$��Center=�  -
   $ bt_BLeft��$$ bt_MoveBMinus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/left.png��$ 64Q�$	 64Q�$��5q�$��4��$��0��  -   $ 	bt_BRight��$# bt_MoveBPlus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/right.png��$ 64Q�$	 64Q�$��5q�$��4��$��1���� $��C��$��3��$��2��$��5q�$��2��$ Center=�$��Center=�  -   $ bt_CLeft��$$ bt_MoveCMinus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/left.png��$ 64Q�$	 64Q�$��5q�$��4��$��2��  -   $ 	bt_CRight��$# bt_MoveCPlus_PreviewMouseDown��$ bt_MoveStop��$ /Resources/right.png��$ 64Q�$	 64Q�$��5q�$��4��$��3��� $��0��$��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��X��$��0��$��0��$��5q�$ Right=�$��Center=��� -   
 ��Name$
 txt_CameraX��$��0��$��1��$��5,5,30,5q�$	��0.0���� $��Y��$��0��$��2��$��5q�$ Right=�$��Center=��� -   $
 txt_CameraY��$��0��$��3��$��5q�$	��0.0���� -    ��Name$ 	bt_GetDRO��$��Update��$��5q�$��0��$��4���� $��Z��$��1��$��0��$��5q�$ Right=�$��Center=��� -   $
 txt_CameraZ��$��1��$��1��$��5,5,30,5q�$��0���� $��A��$��1��$��2��$��5q�$ Right=�$��Center=��� -   $
 txt_CameraA��$��1��$��3��$��5q�$��0���� $��B��$��2��$��0��$��5q�$ Right=�$��Center=��� -   $
 txt_CameraB��$��2��$��1��$��5,5,30,5q�$��0���� $��C��$��2��$��2��$��5q�$ Right=�$��Center=��� -   $
 txt_CameraC��$��2��$��3��$��5q�$��0���� $��	Jog Speed��$��5q�$��3��$��0��$ Right=�$��Center=��� -   $��dd_distance�� �� SelectedIndex$ 1��$��5,5,30,5q�$��3��$��1��.@��� .��10.0�� .��5.0�� .��2.0�� .��1.0�� .��0.5�� .��0.1�� .��0.05�� $��Feeder��$��5q�$��3��$��2��$ Right=�$��Center=��� -   $��dd_FeederSelect��$ 0��$��5,5,30,5q�$��3��$��3��.@��� .��0�� .��1�� .��2�� .��3�� .��4�� .��5�� .��6�� .��7�� .��8�� .��9�� .��10�� .��11�� .��12�� .��13�� .��14�� .��15�� -   $ bt_getFeeder��$��Select��$��5q�$��3��$��4���� $��Move to entered location��$��15(�$��5��$��4��$��0��$��5q�$
 Left=�$��Center=��� $��X��$��5��$��0��$��5q�$ Right=�$��Center=��� -   $
 txt_goX��$��5��$��1��$��5,5,30,5q�$	��0.0���� $��Y��$��5��$��2��$��5q�$ Right=�$��Center=��� -   $
 txt_goY��$��5��$��3��$��5q�$	��0.0���� $��Z��$��6��$��0��$��5q�$ Right=�$��Center=��� -   $
 txt_goZ��$��6��$��1��$��5,5,30,5q�$��0���� $��A��$��6��$��2��$��5q�$ Right=�$��Center=��� -   $
 txt_goA��$��6��$��3��$��5q�$��0���� $��B��$��7��$��0��$��5q�$ Right=�$��Center=��� -   $
 txt_goB��$��7��$��1��$��5,5,30,5q�$��0���� $��C��$��7��$��2��$��5q�$ Right=�$��Center=��� -   $
 txt_goC��$��7��$��3��$��5q�$��0���� $��Speed��$��8��$��0��$��5q�$ Right=�$��Center=��� -   $
 	txt_Speed��$��8��$��1��$��5q�$
��2000���� -   $ bt_runto��$��Run to Location��$��5q�$��8��$��2��$��3���� -     ��Name$ lblInfo��� $��Bottom=�$	��130��$	��130�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -!    ��Name$ chk_HeadLED��$��Head LED��$��36.667��$��76.668��$
��Left=� �� 	ClickMode$ Press=�$��0��$��0���� -"   $ chk_BaseLED��$��Base LED��$��5q�$��36.667��$	��100��$
��Left=�$ Press=�$��0��$��1���� -#   $ chk_Vac1��$��Vac 1��$��5q�$��36.667��$	��100��$
��Left=�$ Press=�$��0��$��2���� -$   $ chk_Vac2��$��Vac 2��$��5q�$��36.667��$	��100��$
��Left=�$ Press=�$��0��$��3��*   $PickandPlace.ImageButton.ImageButton  -%     Name$ bt_Stop��*   $PickandPlace.ImageButton.ImageButton   Click$ button1_Click��   Image$" /Resources/appbar.camera.png��$
��Left=�$	��Top=�   
ImageWidth$ 76Q�   ImageHeight$ 76Q�$��10q�   Text$ Camera�� � ToolTip$ Camera��$��5��  -&   $ bt_Home��$ bt_HomeAll_Click��$  /Resources/appbar.home.png��$
��Left=�$	��Top=�$ 76Q�$ 76Q�$��10q�$
 Home��$
 Home��$��6��  -'   $ bt_ChipFeeder��$ bt_ChipFeeder_Click��$ /Resources/appbar.cog.png��$
��Left=�$	��Top=�$ 76Q�$ 76Q�$��10q�$ Chip Feeder��$ Activate Chip Feeder��$��7��  -(   $ bt_eStop��$ bt_eStop_Click��$% /Resources/appbar.sign.stop.png��$
��Left=�$	��Top=�$ 76Q�$ 76Q�$��10q�$ E-Stop��$ E-Stop��$��8��