﻿#pragma checksum "..\..\..\Views\FileDisplayWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CFF8509960E03B075885E4AD1A27E34FEBA1735D2A2470C8F6D9D5C25FE80369"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using ViewModel;


namespace VisualTeensy {
    
    
    /// <summary>
    /// FileDisplayWindow
    /// </summary>
    public partial class FileDisplayWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Views\FileDisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbMakefile;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\FileDisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox file;
        
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
            System.Uri resourceLocater = new System.Uri("/VisualTeensy;component/views/filedisplaywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\FileDisplayWindow.xaml"
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
            
            #line 9 "..\..\..\Views\FileDisplayWindow.xaml"
            ((VisualTeensy.FileDisplayWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\Views\FileDisplayWindow.xaml"
            ((VisualTeensy.FileDisplayWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\..\Views\FileDisplayWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).AddHandler(System.Windows.Controls.Primitives.ToggleButton.CheckedEvent, new System.Windows.RoutedEventHandler(this.StackPanel_Checked));
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbMakefile = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.file = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
