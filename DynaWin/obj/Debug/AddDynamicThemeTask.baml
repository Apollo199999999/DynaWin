   M S B A M L   `   `   `  ����B  >DynaWin, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  5   	   !    DynaWin.AddDynamicThemeTask   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   D @ModernWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   #localclr-namespace:DynaWin   5   	   -   5          � Title$  New Dynamic Theme Task��5	   	   $	��800��6(   $	��600��65    � 
ResizeMode$ NoResize=�6A   0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � WindowStartupLocation$ CenterOwner=�5
   5    � Topmost . .��5      � .+�5   
   �� -   5         ��Name$ 
TitleLabel��5      $��New Dynamic Theme task��6$   $
��Left=�6E   $��	10,10,0,0q�6`   $	��Top=�6s   $
��Bold"�6�   $��20(�6�   �� 5   
   $M��GName of Dynamic Theme task (the name cannot contain illegal characters)��6   $
��Left=�6b   $��	10,62,0,0q�6}   $	��Top=�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ TaskNameTextBox��5   V   $��32��6   $��
10,93,10,0q�6   $	��Top=�62   $	��574��6J    �� TextWrapping$ NoWrap=�6o    �� MaxLines$ 1��6�   6�   �� 5   
   $��Events:��6   $
��Left=�6"   $��
10,140,0,0q�6=   $	��Top=�6Q   $
��Bold"�6i   $��16(�6{   �� 5   
   $���~Add or remove the events that you want this task to do. (e.g switching the system theme to light or dark at a specified time.)��6   $
��Left=�6�   $��
10,177,0,0q�6�   $	��Top=�6�   $
��Wrap=�6�   �� 5   
   -   5        	 ��Name$	 SaveBtn��5      $��Save and Exit��6"   $��Right=�6:   $��
0,715,10,0q�6V   $	��Top=�6j   $	��140��6�   $��37��6�      AccentButtonStyle#��[  6�   6�   �� 5   
   -   5        $	 AddActionBtn��5      $
��Left=�6'   $��
10,224,0,0q�6B   $	��Top=�6V   $	��155��6n   $��37��6z   
 ^� InitialShowDelay$
 0��5   ,   ��5      � 5      $	��145��6   .+�5      �� $3��-pack://siteoforigin:,,,/Resources/AddIcon.png��6   $
��Left=�6S   $��23��6n   $��23��6y   �� 5      $��Add an Event��6   $��	30,0,10,0q�63   $��Center=�6F   5       � ToolTip 5      _� 5      -   5         _�Name$ AddActionBtnToolTip��5      $��Add an Event��67   5       �� 5"   
   -   5        $	 RemoveActionBtn��5"      $
��Left=�6*   $��185,224,0,0q�6E   $	��Top=�6Z   $	��170��6r   $��37��5#      $
 0��6;    ^� ShowOnDisabled . ��5$      � 5%      $	��160��6   .+�5&      �� $6��0pack://siteoforigin:,,,/Resources/DeleteIcon.png��6   $
��Left=�6V   $��23��6q   $��23��6|   �� 5'      $��Remove an Event��6   $��30,0,0,0q�66   $��Center=�6H   5(       5+      _� 5,      -   5        $ RemoveActionBtnToolTip��5,      $��Remove an Event��6:   5.      �� 50   
   -	   5         ��Name$ ActionsListBox��50      $	��435��6*   $��10,270,10,0q�67   $	��Top=�6L   $	��574��6d   ��.  6�   52      53      