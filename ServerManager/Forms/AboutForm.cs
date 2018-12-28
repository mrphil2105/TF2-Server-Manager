using System;
using System.Reflection;
using System.Windows.Forms;

namespace ServerManager.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            Text = "About " + GetAssemblyAttributeValue<AssemblyTitleAttribute>();
            lblProduct.Text = GetAssemblyAttributeValue<AssemblyProductAttribute>();
            lblVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            lblCopyright.Text = GetAssemblyAttributeValue<AssemblyCopyrightAttribute>();
            lblCompany.Text = GetAssemblyAttributeValue<AssemblyCompanyAttribute>();
            lblDescription.Text = GetAssemblyAttributeValue<AssemblyDescriptionAttribute>();
        }

        private static string GetAssemblyAttributeValue<TAttribute>() where TAttribute : Attribute
        {
            var type = typeof(TAttribute);
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(type, false);

            if (attributes.Length > 0)
            {
                string propertyName = type.Name.Replace("Assembly", string.Empty).Replace("Attribute", string.Empty);
                return (string)type.GetProperty(propertyName).GetValue(attributes[0]);
            }

            return string.Empty;
        }
    }
}
