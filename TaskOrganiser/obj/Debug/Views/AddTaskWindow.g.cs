﻿#pragma checksum "..\..\..\Views\AddTaskWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5448AD7365F442B880DCA08C490366EB59E7AB539CE249D8289FB55040347A44"
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
using TaskOrganiser.Views;


namespace TaskOrganiser.Views {
    
    
    /// <summary>
    /// AddTaskWindow
    /// </summary>
    public partial class AddTaskWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox StatusCheckBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PriorityComboBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DeadlineDatePicker;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateOfFinishDatePicker;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryComboBox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Views\AddTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitButton;
        
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
            System.Uri resourceLocater = new System.Uri("/TaskOrganiser;component/views/addtaskwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AddTaskWindow.xaml"
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
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.StatusCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.PriorityComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.TypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.DeadlineDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.DateOfFinishDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.CategoryComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.SubmitButton = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\Views\AddTaskWindow.xaml"
            this.SubmitButton.Click += new System.Windows.RoutedEventHandler(this.SubmitButtonClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

