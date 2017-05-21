using System.Windows;

namespace MaterialForms.Wpf
{
    public class StringProxy : Freezable
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(string),
                typeof(StringProxy),
                new UIPropertyMetadata(null));

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        protected override Freezable CreateInstanceCore()
        {
            return new StringProxy();
        }
    }
}