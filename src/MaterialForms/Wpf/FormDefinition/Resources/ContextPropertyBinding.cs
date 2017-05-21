using System.Windows;
using System.Windows.Data;

namespace MaterialForms.Wpf.Resources
{
    public class ContextPropertyBinding : Resource
    {
        public ContextPropertyBinding(string propertyPath, bool oneTimeBinding)
        {
            PropertyPath = propertyPath;
            OneTimeBinding = oneTimeBinding;
        }

        public string PropertyPath { get; }

        public bool OneTimeBinding { get; }

        public override bool IsDynamic => !OneTimeBinding;

        public override BindingBase GetBinding(FrameworkElement element)
        {
            var path = string.IsNullOrEmpty(PropertyPath) ? "" : "." + PropertyPath;
            return new Binding(nameof(MaterialForm.Context) + path)
            {
                Source = element,
                Mode = OneTimeBinding ? BindingMode.OneTime : BindingMode.OneWay
            };
        }

        public override bool Equals(Resource other)
        {
            if (other is ContextPropertyBinding resource)
            {
                return PropertyPath == resource.PropertyPath && OneTimeBinding == resource.OneTimeBinding;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return PropertyPath.GetHashCode() ^ (OneTimeBinding ? 741852963 : 123456789);
        }
    }
}