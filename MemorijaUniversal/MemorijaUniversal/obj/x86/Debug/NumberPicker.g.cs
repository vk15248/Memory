﻿#pragma checksum "X:\Projekat-test\MemorijaUniversal\MemorijaUniversal\NumberPicker.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "44840428F0AF5DCAF2ECF0E5B07C36A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemorijaUniversal
{
    partial class NumberPicker : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.numberPicker = (global::Windows.UI.Xaml.Controls.UserControl)(target);
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Border element2 = (global::Windows.UI.Xaml.Controls.Border)(target);
                    #line 19 "..\..\..\NumberPicker.xaml"
                    ((global::Windows.UI.Xaml.Controls.Border)element2).Tapped += this.Reduce_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    this.content = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    #line 22 "..\..\..\NumberPicker.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.content).TextChanged += this.TextBox_TextChanged;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Border element4 = (global::Windows.UI.Xaml.Controls.Border)(target);
                    #line 23 "..\..\..\NumberPicker.xaml"
                    ((global::Windows.UI.Xaml.Controls.Border)element4).Tapped += this.Increase_Tapped;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

