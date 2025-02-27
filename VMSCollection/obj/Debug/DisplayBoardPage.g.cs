﻿#pragma checksum "..\..\DisplayBoardPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2DE0A1B0E0F714573E077E1CAF73C9300ADD54C1C4213BAEC189A3BD2FF36247"
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
using VMSCollection;


namespace VMSCollection {
    
    
    /// <summary>
    /// DisplayBoardPage
    /// </summary>
    public partial class DisplayBoardPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image se_icon;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image cust_icon;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox codeHeader;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameHeader;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox checkinHeader;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox etaHeader;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox statHeader;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel liveStatusList;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\DisplayBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image se_logo;
        
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
            System.Uri resourceLocater = new System.Uri("/VMSCollection;component/displayboardpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DisplayBoardPage.xaml"
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
            this.se_icon = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.cust_icon = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.codeHeader = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.nameHeader = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.checkinHeader = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.etaHeader = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.statHeader = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.liveStatusList = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            
            #line 65 "..\..\DisplayBoardPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnGoBackClicked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.se_logo = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

