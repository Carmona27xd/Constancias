// Updated by XamlIntelliSenseFileGenerator 18/11/2024 10:58:34 p. m.
#pragma checksum "..\..\..\Views\RegisterProfessor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FBA2ADADEB7C07CCD18532C69D48BD9A15D95DDA85420AFC0A170A07BDC2BA83"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Constancias.Views;
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


namespace Constancias.Views
{


    /// <summary>
    /// RegisterProfessor
    /// </summary>
    public partial class RegisterProfessor : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Constancias;component/views/registerprofessor.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\RegisterProfessor.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 23 "..\..\..\Views\RegisterProfessor.xaml"
                    ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Back_Click);

#line default
#line hidden
                    return;
                case 2:

#line 25 "..\..\..\Views\RegisterProfessor.xaml"
                    ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Back_Label_Click);

#line default
#line hidden
                    return;
                case 3:

#line 27 "..\..\..\Views\RegisterProfessor.xaml"
                    ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Register_Click);

#line default
#line hidden
                    return;
                case 4:

#line 29 "..\..\..\Views\RegisterProfessor.xaml"
                    ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Register_Label_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox txtName;
        internal System.Windows.Controls.TextBox txtMiddleName;
        internal System.Windows.Controls.TextBox txtLastname;
        internal System.Windows.Controls.TextBox txtTuition;
        internal System.Windows.Controls.TextBox Email;
        internal System.Windows.Controls.ComboBox cbContractType;
        internal System.Windows.Controls.ComboBox cbCategory;
    }
}

