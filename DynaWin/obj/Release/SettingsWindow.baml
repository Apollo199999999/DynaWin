   M S B A M L   `   `   `  ���� B  >DynaWin, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin      DynaWin.SettingsWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:DynaWin     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   -     �Name$  Window�� � Title$ DynaWin Settings��$
��1006��$��653.5��0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � Icon$0 *pack://siteoforigin:,,,/Resources/icon.ico�� � 
ResizeMode$ CanMinimize=�.��� ���� -   GridBackground�� �� ImageSource$6 0pack://siteoforigin:,,,/Resources/Background.jpg��.+��� -    ��Name$ 
LogoHeader��$	��142��$��40��$��	10,10,0,0q�$
��Left=�$	��Top=�$:��4pack://siteoforigin:,,,/Resources/icon with text.png���� $��	10,85,0,0q�$
��Left=�$	��Top=�$��Dynamic Theme:��$��14(��� $��
10,355,0,0q�$
��Left=�$	��Top=�$��Dynamic Wallpaper:��$��14(��� -    ��Name$ DynamicThemeListBox��$	��980��$	��232��$��10,119,10,0q�$	��Top=����	#33808080��.  @�� -    �Name$ AddDynamicThemeTaskBtn��$	��500��$��30��.+��� $��23��$��23��$
��Left=�$3��-pack://siteoforigin:,,,/Resources/AddIcon.png���� $��30,0,0,0q�$
��Left=�$��Center=�$%��Create a new Dynamic Theme task���� -   $ DynamicWallpaperListBox��$	��980��$	��232��$��10,389,10,0q�$	��Top=����	#33808080��.  @�� -   $  AddDynamicWallpaperTaskBtn��$	��500��$��30��.+��� $��23��$��23��$
��Left=�$3��-pack://siteoforigin:,,,/Resources/AddIcon.png���� $��30,0,0,0q�$
��Left=�$��Center=�$)��#Create a new Dynamic Wallpaper task���� -   	 ��Name$	 PreferencesBtn��$	��130��$��45��$��
860,10,0,0q�$
��Left=�$	��Top=����	#33808080.��� $	��115��$��35��.+��� $��28��$��28��$
��Left=�$��Center=�$8��2pack://siteoforigin:,,,/Resources/SettingsIcon.png���� $��33,0,0,0q�$
��Left=�$��Center=�$��Preferences��