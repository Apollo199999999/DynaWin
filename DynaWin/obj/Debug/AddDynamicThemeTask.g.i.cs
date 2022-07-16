﻿#pragma checksum "..\..\AddDynamicThemeTask.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "531BCA4DC3657EC3FD38979B04534D6241492A4AAF586D35CEE1168EF3C6056F"
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
    /// AddDynamicThemeTask
    /// </summary>
    public partial class AddDynamicThemeTask : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\AddDynamicThemeTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TitleLabel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddDynamicThemeTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AddDynamicThemeTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddDynamicThemeTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddActionBtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddDynamicThemeTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip AddActionBtnToolTip;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AddDynamicThemeTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveActionBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\AddDynamicThemeTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip RemoveActionBtnToolTip;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AddDynamicThemeTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ActionsListBox;
        
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
            System.Uri resourceLocater = new System.Uri("/DynaWin;component/adddynamicthemetask.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddDynamicThemeTask.xaml"
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
            
            #line 10 "..\..\AddDynamicThemeTask.xaml"
            ((DynaWin.AddDynamicThemeTask)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TitleLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.TaskNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\AddDynamicThemeTask.xaml"
            this.TaskNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TaskNameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\AddDynamicThemeTask.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddActionBtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\AddDynamicThemeTask.xaml"
            this.AddActionBtn.Click += new System.Windows.RoutedEventHandler(this.AddActionBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddActionBtnToolTip = ((System.Windows.Controls.ToolTip)(target));
            return;
            case 7:
            this.RemoveActionBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\AddDynamicThemeTask.xaml"
            this.RemoveActionBtn.Click += new System.Windows.RoutedEventHandler(this.RemoveActionBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RemoveActionBtnToolTip = ((System.Windows.Controls.ToolTip)(target));
            return;
            case 9:
            this.ActionsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 48 "..\..\AddDynamicThemeTask.xaml"
            this.ActionsListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ActionsListBox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 48 "..\..\AddDynamicThemeTask.xaml"
            this.ActionsListBox.Loaded += new System.Windows.RoutedEventHandler(this.ActionsListBox_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

