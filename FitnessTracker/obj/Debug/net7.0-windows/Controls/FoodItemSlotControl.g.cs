#pragma checksum "..\..\..\..\Controls\FoodItemSlotControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B84DB3CA61C5A90DCE8E4ED8F4C6DBE1AE29F466"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FitnessTracker.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FitnessTracker.Controls {
    
    
    /// <summary>
    /// FoodItemSlotControl
    /// </summary>
    public partial class FoodItemSlotControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Controls\FoodItemSlotControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameBlock;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Controls\FoodItemSlotControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CaloriesBlock;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Controls\FoodItemSlotControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AmountBlock;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Controls\FoodItemSlotControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddOneButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Controls\FoodItemSlotControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveOneButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FitnessTracker;component/controls/fooditemslotcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\FoodItemSlotControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NameBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.CaloriesBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.AmountBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.AddOneButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Controls\FoodItemSlotControl.xaml"
            this.AddOneButton.Click += new System.Windows.RoutedEventHandler(this.AddOneButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RemoveOneButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Controls\FoodItemSlotControl.xaml"
            this.RemoveOneButton.Click += new System.Windows.RoutedEventHandler(this.RemoveOneButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

