   M S B A M L   `   `   `  ����B  >DynaWin, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  5          DynaWin.SettingsWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:DynaWin     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5      -   5          �Name$  Window��5	       � Title$ DynaWin Settings��5
      $
��1006��5      $��653.5��5      0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � Icon$0 *pack://siteoforigin:,,,/Resources/icon.ico��5       � 
ResizeMode$ CanMinimize=�5      .��5      � ��5   
   �� 5      -   5        GridBackground�� �� ImageSource$6 0pack://siteoforigin:,,,/Resources/Background.jpg��5   1   .+�5   
   �� -   5         ��Name$ 
LogoHeader��5      $	��142��5      $��40��5      $��	10,10,0,0q�5      $
��Left=�5      $	��Top=�5      $:��4pack://siteoforigin:,,,/Resources/icon with text.png��5       �� 5!   
   $��	10,85,0,0q�5"      $
��Left=�5#      $	��Top=�5$      $��Dynamic Theme:��5%      $��14(�5&      �� 5'   
   $��
10,355,0,0q�5(      $
��Left=�5)      $	��Top=�5*      $��Dynamic Wallpaper:��5+      $��14(�5,      �� 5.   
   -   5         ��Name$ DynamicThemeListBox��5/      $	��980��50      $	��232��51      $��10,119,10,0q�52      $	��Top=�53      ���	#33808080��.  @�58      � 59      -   5         �Name$ AddDynamicThemeTaskBtn��5:      $	��500��5;      $��30��5<      .+�5=      �� $��23��5>      $��23��5?      $
��Left=�5@      $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��5A      �� 5B      $��30,0,0,0q�5C      $
��Left=�5D      $��Center=�5E      $%��Create a new Dynamic Theme task��5F      5G      5I      �� 5K   
   -   5        $ DynamicWallpaperListBox��5L      $	��980��5M      $	��232��5N      $��10,389,10,0q�5O      $	��Top=�5P      ���	#33808080��.  @�5U      � 5V      -   5        $  AddDynamicWallpaperTaskBtn��5W      $	��500��5X      $��30��5Y      .+�5Z      �� $��23��5[      $��23��5\      $
��Left=�5]      $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��5^      �� 5_      $��30,0,0,0q�5`      $
��Left=�5a      $��Center=�5b      $)��#Create a new Dynamic Wallpaper task��5c      5d      5f      �� 5h   
   -   5        	 ��Name$	 PreferencesBtn��5i      $	��130��5j      $��45��5k      $��
860,10,0,0q�5l      $
��Left=�5m      $	��Top=�5n      ���	#33808080.��5q      � $	��115��6   $��35��6   .+�5r      �� $��28��5s      $��28��5t      $
��Left=�5u      $��Center=�5v      $8��2pack://siteoforigin:,,,/Resources/SettingsIcon.png��5w      �� 5x      $��33,0,0,0q�5y      $
��Left=�5z      $��Center=�5{      $��Preferences��5|      5}      5      5�      5�      