   M S B A M L   `   `   `  ����B  >DynaWin, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  5      !    DynaWin.AddDynamicThemeTask   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:DynaWin     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5      -   5          � Title$  New Dynamic Theme Task��5	      $	��600��5
      $	��800��5      0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � 
ResizeMode$ NoResize=�5       � Topmost .  � WindowStartupLocation$ CenterOwner=�5      .��5      � .+�5   
   �� -   5         ��Name$ 
TitleLabel��5      $��	10,10,0,0q�5      $
��Left=�5      $	��Top=�5      $��New Dynamic Theme task��5      $��20(�5      $
��Bold"�5      �� 5   
   $��	10,62,0,0q�5      $
��Left=�5      $	��Top=�5      $M��GName of Dynamic Theme task (the name cannot contain illegal characters)��5      $
��Bold"�5       �� 5!   
   -   5         ��Name$ TaskNameTextBox��5"      $	��574��5#      $��32��5$      $��
10,93,10,0q�5%      $	��Top=�5&       �� MaxLines$ 1��5'       �� TextWrapping$ NoWrap=�5)      �� 5*   
   $��
10,140,0,0q�5+      $
��Left=�5,      $	��Top=�5-      $��Events:��5.      $��16(�5/      $
��Bold"�50      �� 51   
   $��
10,177,0,0q�52      $
��Left=�53      $	��Top=�54      $���~Add or remove the events that you want this task to do. (e.g switching the system theme to light or dark at a specified time.)��55      $
��Wrap=�56      �� 58   
   -   5        	 ��Name$	 SaveBtn��59      $	��140��5:      $��37��5;      $��
0,715,10,0q�5<      $��Right=�5=      $	��Top=�5>      $��Save and Exit��5@         AccentButtonStyle#��[  5A      �� 5C   
   -   5        $	 AddActionBtn��5D      $	��155��5E      $��37��5F      $��
10,224,0,0q�5G      $
��Left=�5H      $	��Top=�5I      
 ^� InitialShowDelay$
 0��5K      ��5L      � 5M      $	��145��6   .+�5N      �� $��23��5O      $��23��5P      $
��Left=�5Q      $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��5R      �� 5S      $��	30,0,10,0q�5T      $��Center=�5U      $��Add an Event��5V      5W       � ToolTip 5Z      _� 5[      -   5         _�Name$ AddActionBtnToolTip��5[      $��Add an Event��67   5]      �� 5_   
   -   5        $	 RemoveActionBtn��5`      $	��170��5a      $��37��5b      $��185,224,0,0q�5c      $
��Left=�5d      $	��Top=�5e      $
 0��5g       ^� ShowOnDisabled . ��5i      � 5j      $	��160��6   .+�5k      �� $��23��5l      $��23��5m      $
��Left=�5n      $6��0pack://siteoforigin:,,,/Resources/DeleteIcon.png��5o      �� 5p      $��30,0,0,0q�5q      $��Center=�5r      $��Remove an Event��5s      5t       5w      _� 5x      -   5        $ RemoveActionBtnToolTip��5x      $��Remove an Event��6:   5z      �� 5|   
   -	   5         ��Name$ ActionsListBox��5}      $	��574��5~      $	��435��5      $��10,270,10,0q�5�      $	��Top=�5�      ��.  5�      5�      5�      