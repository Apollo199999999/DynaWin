   M S B A M L   `   `   `  ����B  >DynaWin, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DynaWinDynaWin  5          DynaWin.PreferencesWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:DynaWin     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5      -   5          � Title$  DynaWin Preferences��5	      $	��670��5
      $	��620��5      0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � 
ResizeMode$ NoResize=�5       � Topmost .  � WindowStartupLocation$ CenterOwner=�5      .��5      � .+�5   
   �� $��	10,10,0,0q�5      $
��Left=�5      $	��Top=�5      $��Preferences��5      $��20(�5      $
��Bold"�5      �� 5   
   $��	10,62,0,0q�5      $
��Left=�5      $	��Top=�5      $��DynaWin Startup Settings:��5      $��16(�5      $
��Bold"�5       �� 5!   
   -   5         ��Name$ StartupCheckBox��5"      $��	10,98,0,0q�5#      $
��Left=�5$      $	��Top=�5%      $��Run on Windows starup��5&      �� 5'   
   $��
10,151,0,0q�5(      $
��Left=�5)      $	��Top=�5*      $��Updates:��5+      $��16(�5,      $
��Bold"�5-      �� 5.   
   -   5         ��Name$ VersionLabel��5/      $��
10,188,0,0q�50      $
��Left=�51      $	��Top=�52      $��Current Version:��53      �� 54   
   -   5         ��Name$ 	UpdateBtn��55      $	��140��56      $��32��57      $��
10,219,0,0q�58      $
��Left=�59      $	��Top=�5:      $��Check for Updates��5<         AccentButtonStyle#��[  5=      �� 5>   
   $��
422,72,0,0q�5?      $
��Left=�5@      $	��Top=�5A      $��16(�5B      $
��Bold"�5C      $��About DynaWin��5D      �� 5E   
   $	��170��5F      $��
422,98,0,0q�5G      $
��Left=�5H      $	��Top=�5I      $
��Wrap=�5J      �� 6"   $�DynaWin ��6&   �� 69   $�is��6=   �� 6J   $	� a ��6N   �� 6\   $�utility��6`   �� 6r   $� that allow��6v   �� 6�   $�s��6�   �� 6�   $0�* the Windows desktop to change dynamically��6�   �� 6�   $�.��6�   6�   �� 5K   
   $	��170��5L      $	��100��5M      $��422,190,0,0q�5N      $
��Left=�5O      $	��Top=�5P      $8��2pack://siteoforigin:,,,/Resources/DynaWinImage.jpg��5Q      $��UniformToFill=�5R      �� 5T   
   $��422,300,0,0q�5U      $
��Left=�5V      $	��Top=�5W      �� 5X      -   5         ��Name$ 
GithubLink��5Y      $0��*https://github.com/Apollo199999999/DynaWin?�5Z      .�5[   =   Github repository5]      5^      �� 5`   
   $��422,326,0,0q�5a      $
��Left=�5b      $	��Top=�5c      �� 5d      -   5        $ WebsiteLink��5e      $+��%https://clickphase.vercel.app/dynawin?�5f      .�5g   =   Visit DynaWin's website5i      5j      �� 5l   
   $��422,352,0,0q�5m      $
��Left=�5n      $	��Top=�5o      �� 5p      -   5        $ ReportBugLink��5q      $7��1https://github.com/Apollo199999999/DynaWin/issues?�5r      .�5s   =   Report a bug5u      5v      �� 5x   
   $��422,378,0,0q�5y      $
��Left=�5z      $	��Top=�5{      �� 5|      -   5        $ RequestFeatureLink��5}      $7��1https://github.com/Apollo199999999/DynaWin/issues?�5~      .�5   =   Request a feature5�      5�      �� 5�   
   $��422,404,0,0q�5�      $
��Left=�5�      $	��Top=�5�      	 J� RenderTransformOrigin$	 0.548,1.615&�5�      �� 5�      -	   5        $ MITLicenseLink��5�      $F��@https://github.com/Apollo199999999/DynaWin/blob/main/LICENSE.txt?�5�      .�5�   =   MIT License5�      5�      �� 5�   
   $��422,430,0,0q�5�      $
��Left=�5�      $	��Top=�5�      �� 5�      -
   5        $ ThirdPartyLicenseLink��5�      $E��?https://github.com/Apollo199999999/DynaWin/blob/main/NOTICE.txt?�5�      .�5�   =   " Third party notices and licenses5�      5�      �� 5�   
   $��422,456,0,0q�5�      $
��Left=�5�      $	��Top=�5�      �� 5�      -   5        $ PrivacyPolicyLink��5�      $K��Ehttps://github.com/Apollo199999999/DynaWin/blob/main/PRIVACYPOLICY.md?�5�      .�5�   =   Privacy policy5�      5�      �� 5�   
   $��422,482,0,0q�5�      $
��Left=�5�      $	��Top=�5�      �� 5�      -   5        $ RickRoll��5�      $1��+https://www.youtube.com/watch?v=dQw4w9WgXcQ?�5�      .�5�   =   Secret Link (don't click)5�      5�      �� 5�   
   -   5        $ SaveBtn��5�      $	��200��5�      $��36��5�      $��	0,0,15,15q�5�      $��Right=�5�      $��Bottom=�5�      $��Save Preferences and Exit��5�      #��[  5�      5�      5�      