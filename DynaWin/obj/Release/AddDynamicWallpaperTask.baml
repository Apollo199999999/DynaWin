   M S B A M L   `   `   `  ���� B  >DynaWin, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  %    DynaWin.AddDynamicWallpaperTask   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:DynaWin     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   -     � Title$   New Dynamic Wallpaper Task��$
��1000��$	��800��0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � 
ResizeMode$ NoResize=� � Topmost .  � WindowStartupLocation$ CenterOwner=�.��� .+��� -    ��Name$ 
TitleLabel��$��	10,10,0,0q�$
��Left=�$	��Top=�$ ��New Dynamic Wallpaper task��$��20(�$
��Bold"��� $��	10,62,0,0q�$
��Left=�$	��Top=�$Q��KName of Dynamic Wallpaper task (the name cannot contain illegal characters)��$
��Bold"��� -    ��Name$ TaskNameTextBox��$��32��$��
10,93,10,0q�$	��Top=� �� MaxLines$ 1�� �� TextWrapping$ NoWrap=��� $��
10,140,0,0q�$
��Left=�$	��Top=�$��Events:��$��16(�$
��Bold"��� $��
10,177,0,0q�$
��Left=�$	��Top=�$����Add or remove the events that you want this task to do. (e.g changing the wallpaper when the time is 12 PM, or changing the wallpaper when the battery percentage is 10%)��$
��Wrap=��� -   	 ��Name$	 AddTimeActionBtn��$	��165��$��37��$��
10,224,0,0q�$
��Left=�$	��Top=�
 ^� InitialShowDelay$
 0����� $	��155��.+��� $��23��$��23��$
��Left=�$3��-pack://siteoforigin:,,,/Resources/AddIcon.png���� $��	30,0,10,0q�$��Center=�$��Add a Time Event�� � ToolTip _� -    _�Name$ AddTimeActionBtnToolTip��$��Add a Time Event���� -   $	 AddBatteryActionBtn��$	��174��$��37��$��195,224,0,0q�$
��Left=�$	��Top=�$
 0����� $	��165��.+��� $��23��$��23��$
��Left=�$3��-pack://siteoforigin:,,,/Resources/AddIcon.png���� $��	30,0,10,0q�$��Center=�$��Add a Battery Event�� _� -   $ AddBatteryBtnToolTip��$��Add a Battery Event���� -   $	 RemoveActionBtn��$	��170��$��37��$��390,224,0,0q�$
��Left=�$	��Top=�$
 0�� ^� ShowOnDisabled . ��� $	��160��.+��� $��23��$��23��$
��Left=�$6��0pack://siteoforigin:,,,/Resources/DeleteIcon.png���� $��30,0,0,0q�$��Center=�$��Remove an Event�� _� -	   $ RemoveActionBtnToolTip��$��Remove an Event���� -
    ��Name$ ActionsListBox��$	��435��$��10,270,10,0q�$	��Top=���.  $
��Auto=�$��Disabled=����� .R��� 
������  �� Orientation$ 
Horizontal=��� -   $	 SaveBtn��$	��140��$��37��$��
0,715,10,0q�$��Right=�$	��Top=�$��Save and Exit��   AccentButtonStyle#��[  