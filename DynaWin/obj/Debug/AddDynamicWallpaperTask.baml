   M S B A M L   `   `   `  ����B  >DynaWin, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  5      %    DynaWin.AddDynamicWallpaperTask   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:DynaWin     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5      -   5          � Title$   New Dynamic Wallpaper Task��5	      $
��1000��5
      $	��800��5      0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � 
ResizeMode$ NoResize=�5       � Topmost .  � WindowStartupLocation$ CenterOwner=�5      .��5      � .+�5   
   �� -   5         ��Name$ 
TitleLabel��5      $��	10,10,0,0q�5      $
��Left=�5      $	��Top=�5      $ ��New Dynamic Wallpaper task��5      $��20(�5      $
��Bold"�5      �� 5   
   $��	10,62,0,0q�5      $
��Left=�5      $	��Top=�5      $Q��KName of Dynamic Wallpaper task (the name cannot contain illegal characters)��5      $
��Bold"�5       �� 5"   
   -   5         ��Name$ TaskNameTextBox��5#      $��32��5$      $��
10,93,10,0q�5%      $	��Top=�5&       �� MaxLines$ 1��5'       �� TextWrapping$ NoWrap=�5)      �� 5+   
   $��
10,140,0,0q�5,      $
��Left=�5-      $	��Top=�5.      $��Events:��5/      $��16(�50      $
��Bold"�51      �� 52   
   $��
10,177,0,0q�53      $
��Left=�54      $	��Top=�55      $����Add or remove the events that you want this task to do. (e.g changing the wallpaper when the time is 12 PM, or changing the wallpaper when the battery percentage is 10%)��56      $
��Wrap=�57      �� 59   
   -   5        	 ��Name$	 AddTimeActionBtn��5:      $	��165��5;      $��37��5<      $��
10,224,0,0q�5=      $
��Left=�5>      $	��Top=�5?      
 ^� InitialShowDelay$
 0��5A      ��5B      � 5C      $	��155��6   .+�5D      �� $��23��5E      $��23��5F      $
��Left=�5G      $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��5H      �� 5I      $��	30,0,10,0q�5J      $��Center=�5K      $��Add a Time Event��5L      5M       � ToolTip 5P      _� 5Q      -   5         _�Name$ AddTimeActionBtnToolTip��5Q      $��Add a Time Event��6;   5S      �� 5U   
   -   5        $	 AddBatteryActionBtn��5V      $	��174��5W      $��37��5X      $��195,224,0,0q�5Y      $
��Left=�5Z      $	��Top=�5[      $
 0��5]      ��5^      � 5_      $	��165��6   .+�5`      �� $��23��5a      $��23��5b      $
��Left=�5c      $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��5d      �� 5e      $��	30,0,10,0q�5f      $��Center=�5g      $��Add a Battery Event��5h      5i       5l      _� 5m      -   5        $ AddBatteryBtnToolTip��5m      $��Add a Battery Event��68   5o      �� 5q   
   -   5        $	 RemoveActionBtn��5r      $	��170��5s      $��37��5t      $��390,224,0,0q�5u      $
��Left=�5v      $	��Top=�5w      $
 0��5y       ^� ShowOnDisabled . ��5{      � 5|      $	��160��6   .+�5}      �� $��23��5~      $��23��5      $
��Left=�5�      $6��0pack://siteoforigin:,,,/Resources/DeleteIcon.png��5�      �� 5�      $��30,0,0,0q�5�      $��Center=�5�      $��Remove an Event��5�      5�       5�      _� 5�      -	   5        $ RemoveActionBtnToolTip��5�      $��Remove an Event��6:   5�      �� 5�   
   -
   5         ��Name$ ActionsListBox��5�      $	��435��5�      $��10,270,10,0q�5�      $	��Top=�5�      ��.  $
��Auto=�5�      $��Disabled=�5�      ��5�      �� 5�      .R�5�      �� 
������  �� Orientation$ 
Horizontal=�6:   5�      5�      �� 5�   
   -   5        $	 SaveBtn��5�      $	��140��5�      $��37��5�      $��
0,715,10,0q�5�      $��Right=�5�      $	��Top=�5�      $��Save and Exit��5�         AccentButtonStyle#��[  5�      5�      5�      