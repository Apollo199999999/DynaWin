   M S B A M L   `   `   `  ����B  >DynaWin, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  5   	   %    DynaWin.AddDynamicWallpaperTask   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   D @ModernWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   #localclr-namespace:DynaWin   5   	   -   5          � Title$   New Dynamic Wallpaper Task��5	   	   $	��800��6,   $
��1000��69    � 
ResizeMode$ NoResize=�6F   0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � WindowStartupLocation$ CenterOwner=�5
   5    � Topmost . .��5      � .+�5   
   �� -   5         ��Name$ 
TitleLabel��5      $ ��New Dynamic Wallpaper task��6$   $
��Left=�6I   $��	10,10,0,0q�6d   $	��Top=�6w   $
��Bold"�6�   $��20(�6�   �� 5   
   $Q��KName of Dynamic Wallpaper task (the name cannot contain illegal characters)��6   $
��Left=�6f   $��	10,62,0,0q�6�   $	��Top=�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ TaskNameTextBox��5   J   $��32��6   $��
10,93,10,0q�6   $	��Top=�62    �� TextWrapping$ NoWrap=�6c    �� MaxLines$ 1��6y   6�   �� 5   
   $��Events:��6   $
��Left=�6"   $��
10,140,0,0q�6=   $	��Top=�6Q   $
��Bold"�6i   $��16(�6{   �� 5   
   $����Add or remove the events that you want this task to do. (e.g changing the wallpaper when the time is 12 PM, or changing the wallpaper when the battery percentage is 10%)��6   $
��Left=�6�   $��
10,177,0,0q�6�   $	��Top=�6�   $
��Wrap=�6  �� 5   
   -   5        	 ��Name$	 AddTimeActionBtn��5      $
��Left=�6+   $��
10,224,0,0q�6F   $	��Top=�6Z   $	��165��6r   $��37��6~   
 ^� InitialShowDelay$
 0��5      ��5      � 5      $	��155��6   .+�5      �� $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��6   $
��Left=�6S   $��23��6n   $��23��6y   �� 5      $��Add a Time Event��6   $��	30,0,10,0q�67   $��Center=�6J   5       � ToolTip 5      _� 5      -   5         _�Name$ AddTimeActionBtnToolTip��5      $��Add a Time Event��6;   5       �� 5"   
   -   5        $	 AddBatteryActionBtn��5"      $
��Left=�6.   $��195,224,0,0q�6I   $	��Top=�6^   $	��174��6v   $��37��6�   $
 0��5#      ��5$      � 5%      $	��165��6   .+�5&      �� $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��6   $
��Left=�6S   $��23��6n   $��23��6y   �� 5'      $��Add a Battery Event��6   $��	30,0,10,0q�6:   $��Center=�6M   5(       5+      _� 5,      -   5        $ AddBatteryBtnToolTip��5,      $��Add a Battery Event��68   5.      �� 50   
   -   5        $	 RemoveActionBtn��50      $
��Left=�6*   $��390,224,0,0q�6E   $	��Top=�6Z   $	��170��6r   $��37��51      $
 0��6;    ^� ShowOnDisabled . ��52      � 53      $	��160��6   .+�54      �� $6��0pack://siteoforigin:,,,/Resources/DeleteIcon.png��6   $
��Left=�6V   $��23��6q   $��23��6|   �� 55      $��Remove an Event��6   $��30,0,0,0q�66   $��Center=�6H   56       59      _� 5:      -	   5        $ RemoveActionBtnToolTip��5:      $��Remove an Event��6:   5<      �� 5>   
   -
   5         ��Name$ ActionsListBox��5>      $	��435��6*   $��10,270,10,0q�67   $	��Top=�6L   ��.  $��Disabled=�5?      $
��Auto=�6A   ��5@      �� 5A      .R�5B      �� 
������  �� Orientation$ 
Horizontal=�6:   5C      5E      �� 5G   
   -   5        $	 SaveBtn��5G      $��Save and Exit��6"   $��Right=�6:   $��
0,715,10,0q�6V   $	��Top=�6j   $	��140��6�   $��37��6�      AccentButtonStyle#��[  6�   6�   5H      5I      