﻿#pragma checksum "..\..\BuyTicket.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CC38E01713CF9193D9DBFC35914FD74F87E4FB239C3E356FD0B0BAFE6A50EDA7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ITAirOffice;
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


namespace ITAirOffice {
    
    
    /// <summary>
    /// BuyTicket
    /// </summary>
    public partial class BuyTicket : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbFromAir;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbInAir;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnexit;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbtimeFrom;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbtimeIn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tst;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbnumber;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbrow;
        
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
            System.Uri resourceLocater = new System.Uri("/ITAirOffice;component/buyticket.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BuyTicket.xaml"
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
            
            #line 8 "..\..\BuyTicket.xaml"
            ((ITAirOffice.BuyTicket)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbFromAir = ((System.Windows.Controls.ComboBox)(target));
            
            #line 10 "..\..\BuyTicket.xaml"
            this.cmbFromAir.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbFromAir_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmbInAir = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\BuyTicket.xaml"
            this.cmbInAir.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbInAir_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnexit = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\BuyTicket.xaml"
            this.btnexit.Click += new System.Windows.RoutedEventHandler(this.btnexit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbtimeFrom = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\BuyTicket.xaml"
            this.cmbtimeFrom.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbtimeFrom_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmbtimeIn = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\BuyTicket.xaml"
            this.cmbtimeIn.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbtimeIn_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 15 "..\..\BuyTicket.xaml"
            this.cmbtimeIn.MouseMove += new System.Windows.Input.MouseEventHandler(this.cmbtimeIn_MouseMove);
            
            #line default
            #line hidden
            
            #line 15 "..\..\BuyTicket.xaml"
            this.cmbtimeIn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.cmbtimeIn_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 15 "..\..\BuyTicket.xaml"
            this.cmbtimeIn.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.cmbtimeIn_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tst = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\BuyTicket.xaml"
            this.tst.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.tst_LoadingRow);
            
            #line default
            #line hidden
            
            #line 16 "..\..\BuyTicket.xaml"
            this.tst.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.tst_SelectedCellsChanged);
            
            #line default
            #line hidden
            
            #line 16 "..\..\BuyTicket.xaml"
            this.tst.Loaded += new System.Windows.RoutedEventHandler(this.tst_Loaded);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmbnumber = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\BuyTicket.xaml"
            this.cmbnumber.Initialized += new System.EventHandler(this.comtest_Initialized);
            
            #line default
            #line hidden
            
            #line 24 "..\..\BuyTicket.xaml"
            this.cmbnumber.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbnumber_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cmbrow = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\BuyTicket.xaml"
            this.cmbrow.Initialized += new System.EventHandler(this.cmbrow_Initialized);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

