﻿#pragma checksum "..\..\SettingsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6193F147655905E51151F6EFD7FB3B79311F97E0F692C50715AAE446B8F4509F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DynaWin;
using ModernWpf;
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;
using ModernWpf.DesignTime;
using ModernWpf.Markup;
using ModernWpf.Media.Animation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DynaWin {
    
    
    /// <summary>
    /// SettingsWindow
    /// </summary>
    public partial class SettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// Window Name Field
        /// </summary>
        
        #line 9 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public DynaWin.SettingsWindow Window;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush GridBackground;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LogoHeader;
        
        #line default
        #line hidden
        
        /// <summary>
        /// DynamicThemeListBox Name Field
        /// </summary>
        
        #line 47 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.ListBox DynamicThemeListBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddDynamicThemeTaskBtn;
        
        #line default
        #line hidden
        
        /// <summary>
        /// DynamicWallpaperListBox Name Field
        /// </summary>
        
        #line 76 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.ListBox DynamicWallpaperListBox;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddDynamicWallpaperTaskBtn;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PreferencesBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DynaWin;component/settingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SettingsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window = ((DynaWin.SettingsWindow)(target));
            
            #line 15 "..\..\SettingsWindow.xaml"
            this.Window.Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 17 "..\..\SettingsWindow.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GridBackground = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.LogoHeader = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.DynamicThemeListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 55 "..\..\SettingsWindow.xaml"
            this.DynamicThemeListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DynamicThemeListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddDynamicThemeTaskBtn = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.DynamicWallpaperListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 84 "..\..\SettingsWindow.xaml"
            this.DynamicWallpaperListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DynamicWallpaperListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddDynamicWallpaperTaskBtn = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.PreferencesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\SettingsWindow.xaml"
            this.PreferencesBtn.Click += new System.Windows.RoutedEventHandler(this.PreferencesBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

