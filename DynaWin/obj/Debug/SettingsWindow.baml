   M S B A M L   `   `   `  ����B  >DynaWin, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  5   	       DynaWin.SettingsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:DynaWin     5   	   D @ModernWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   -   5          �Name$  Window��5   �    � Title$ DynaWin Settings��5
   	   $��653.5��6"   $
��1006��61   0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � Icon$0 *pack://siteoforigin:,,,/Resources/icon.ico��5   	    � 
ResizeMode$ CanMinimize=�6k   .��5      � ��5   
   �� 5       �� ImageSource$6 0pack://siteoforigin:,,,/Resources/Background.jpg��6   -   5        GridBackground��5   X   .+�5   
   �� -   5         ��Name$ 
LogoHeader��5   �   $
��Left=�6   $��40��6+   $��	10,10,0,0q�67   $	��Top=�6J   $	��142��6b   $:��4pack://siteoforigin:,,,/Resources/icon with text.png��6n   6�   �� 5   
   $��Dynamic Theme:��6   $
��Left=�6)   $��	10,85,0,0q�6D   $	��Top=�6W   $��14(�6o   �� 5   
   $��Dynamic Wallpaper:��6   $
��Left=�6-   $��
10,355,0,0q�6H   $	��Top=�6\   $��14(�6t   �� 5   
   -   5         ��Name$ DynamicThemeListBox��5      $	��232��6/   $��10,119,10,0q�6<   $	��980��6Q   $	��Top=�6]   ���	#33808080��.  @�5      � 5      -   5         �Name$ AddDynamicThemeTaskBtn��5   0   $��30��6   $	��500��6#   .+�5      �� $��23��6   $��23��6(   $
��Left=�63   $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��6N   �� 5      $%��Create a new Dynamic Theme task��6   $��30,0,0,0q�6F   $
��Left=�6X   $��Center=�6t   5      5      �� 5   
   -   5        $ DynamicWallpaperListBox��5      $	��232��63   $��10,389,10,0q�6@   $	��980��6U   $	��Top=�6a   ���	#33808080��.  @�5      � 5       -   5        $  AddDynamicWallpaperTaskBtn��5    /   $��30��6   $	��500��6#   .+�5!      �� $��23��6   $��23��6(   $
��Left=�63   $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��6N   �� 5"      $)��#Create a new Dynamic Wallpaper task��6   $��30,0,0,0q�6J   $
��Left=�6\   $��Center=�6x   5#      5%      �� 5'   
   -   5        	 ��Name$	 PreferencesBtn��5'   p   $
��Left=�6   $��
860,10,0,0q�6,   $	��Top=�6@   $	��130��6X   $��45��6d   ���	#33808080.��5(      � $��35��6   $	��115��6   .+�5)      �� $��28��6   $��28��6$   $8��2pack://siteoforigin:,,,/Resources/SettingsIcon.png��6/   $
��Left=�6k   $��Center=�6�   �� 5*      $��Preferences��6   $
��Left=�6.   $��33,0,0,0q�6I   $��Center=�6[   5+      5-      50      51      