﻿#pragma checksum "..\..\JoinExistingGamePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5FD348E1EDCEC8FB2B14922A02CA394D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MazeSolver.Client.Wpf;
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


namespace MazeSolver.Client.Wpf {
    
    
    /// <summary>
    /// JoinExistingGamePage
    /// </summary>
    public partial class JoinExistingGamePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\JoinExistingGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\JoinExistingGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblExplain;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\JoinExistingGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSeeExistingGame;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\JoinExistingGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGameKey;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\JoinExistingGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tBGameKey;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\JoinExistingGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPseudo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\JoinExistingGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tBPseudo;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\JoinExistingGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnJoinGame;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/joinexistinggamepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\JoinExistingGamePage.xaml"
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
            this.lblTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblExplain = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnSeeExistingGame = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\JoinExistingGamePage.xaml"
            this.btnSeeExistingGame.Click += new System.Windows.RoutedEventHandler(this.btnSeeExistingGame_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblGameKey = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.tBGameKey = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.lblPseudo = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.tBPseudo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnJoinGame = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\JoinExistingGamePage.xaml"
            this.btnJoinGame.Click += new System.Windows.RoutedEventHandler(this.btnJoinGame_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
