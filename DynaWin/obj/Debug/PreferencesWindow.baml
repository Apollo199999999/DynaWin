   M S B A M L   `   `   `  ����B  >DynaWin, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  5   	       DynaWin.PreferencesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:DynaWin     5   	   D @ModernWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   -   5          � Title$  DynaWin Preferences��5	   	   $	��605��6%   $	��670��62    � 
ResizeMode$ NoResize=�6>   0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � WindowStartupLocation$ CenterOwner=�5
   5    � Topmost . .��5      � .+�5   
   �� $��Preferences��6   $
��Left=�6&   $��	10,10,0,0q�6A   $	��Top=�6T   $��20(�6l   $
��Bold"�6z   �� 5   
   $��DynaWin Startup Settings:��6   $
��Left=�64   $��	10,62,0,0q�6O   $	��Top=�6b   $
��Bold"�6z   $��16(�6�   �� 5   
   -   5         ��Name$ StartupCheckBox��5      $��Run on Windows starup��6,   $
��Left=�6L   $��	10,98,0,0q�6g   $	��Top=�6z   �� 5   
   $��Updates:��6   $
��Left=�6#   $��
10,151,0,0q�6>   $	��Top=�6R   $
��Bold"�6j   $��16(�6|   �� 5   
   -   5         ��Name$ VersionLabel��5      $��Current Version:��6&   $
��Left=�6A   $��
10,188,0,0q�6\   $	��Top=�6p   �� 5   
   -   5         ��Name$ 	UpdateBtn��5      $��Check for Updates��6$   $
��Left=�6@   $��
10,219,0,0q�6[   $	��Top=�6o   $	��140��6�   $��32��6�      AccentButtonStyle#��[  5   )   �� 5   
   $��About DynaWin��6   $
��Left=�6)   $��
422,72,0,0q�6D   $	��Top=�6X   $
��Bold"�6p   $��16(�6�   �� 5   
   $
��Left=�6   $��
422,98,0,0q�6/   $	��Top=�6C   $
��Wrap=�6[   $	��170��6o   �� 6|   $�DynaWin ��6�   �� 6�   $�is��6�   �� 6�   $	� a ��6�   �� 6�   $�utility��6�   �� 6�   $� that allow��6�   �� 6�   $�s��6�   �� 6�   $0�* the Windows desktop to change dynamically��6�   �� 6(  $�.��6,  68  �� 5   
   $
��Left=�6   $	��100��6+   $��422,190,0,0q�68   $	��Top=�6M   $	��170��6e   $8��2pack://siteoforigin:,,,/Resources/DynaWinImage.jpg��6q   $��UniformToFill=�6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $��422,300,0,0q�6G   �� 5      -   5         ��Name$ 
GithubLink��5      $0��*https://github.com/Apollo199999999/DynaWin?�6$   .�6�   Github Repository5      5      �� 5   
   $
��Left=�6   $	��Top=�6/   $��422,326,0,0q�6G   �� 5      -   5        $ WebsiteLink��5      $0��*https://clickphase.weebly.com/dynawin.html?�6%   .�6�   Visit DynaWin's Website5       5!      �� 5#   
   $
��Left=�6   $	��Top=�6/   $��422,352,0,0q�6G   �� 5$      -   5        $ ReportBugLink��5$      $7��1https://github.com/Apollo199999999/DynaWin/issues?�6'   .�6�   Report a bug5&      5'      �� 5)   
   $
��Left=�6   $	��Top=�6/   $��422,378,0,0q�6G   �� 5*      -   5        $ RequestFeatureLink��5*      $7��1https://github.com/Apollo199999999/DynaWin/issues?�6,   .�6�   Request a feature5,      5-      �� 5/   
   $
��Left=�6   $	��Top=�6/   $��422,404,0,0q�6G   	 J� RenderTransformOrigin$	 0.548,1.615&�6\   �� 50      -	   5        $ MITLicenseLink��50      $F��@https://github.com/Apollo199999999/DynaWin/blob/main/LICENSE.txt?�6(   .�6�   MIT License52      53      �� 55   
   $
��Left=�6   $	��Top=�6/   $��422,430,0,0q�6G   �� 56      -
   5        $ ThirdPartyLicenseLink��56      $E��?https://github.com/Apollo199999999/DynaWin/blob/main/NOTICE.txt?�6/   .�6�   " Third Party Notices and Licenses58      59      �� 5;   
   $
��Left=�6   $	��Top=�6/   $��422,456,0,0q�6G   �� 5<      -   5        $ RickRoll��5<      $1��+https://www.youtube.com/watch?v=dQw4w9WgXcQ?�6"   .�6�   Secret Link (don't click)5>      5?      �� 5A   
   -   5        $ SaveBtn��5A      $��Save Preferences and Exit��6"   $��Right=�6F   $��	0,0,15,15q�6b   $��Bottom=�6u   $	��200��6�   $��38��6�   #��[  5B      69   5E      5F      