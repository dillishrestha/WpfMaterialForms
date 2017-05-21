﻿using System;
using System.Windows;
using System.Windows.Data;

namespace MaterialForms.Wpf.Resources
{
    public class StringProxyResource : Resource
    {
        public StringProxyResource(StringProxy proxy, bool oneTimeBinding)
            : this(proxy, oneTimeBinding, null)
        {
        }

        public StringProxyResource(StringProxy proxy, bool oneTimeBinding, IValueConverter valueConverter)
            : base(valueConverter)
        {
            Proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
            OneTimeBinding = oneTimeBinding;
        }

        public StringProxy Proxy { get; }

        public bool OneTimeBinding { get; }

        public override bool IsDynamic => !OneTimeBinding;

        public override BindingBase GetBinding(FrameworkElement element)
        {
            return new Binding
            {
                Source = Proxy,
                Path = new PropertyPath(BindingProxy.ValueProperty),
                Converter = ValueConverter,
                Mode = OneTimeBinding ? BindingMode.OneTime : BindingMode.OneWay
            };
        }

        public override bool Equals(Resource other)
        {
            if (other is StringProxyResource resource)
            {
                return ReferenceEquals(Proxy, resource.Proxy) && Equals(ValueConverter, resource.ValueConverter);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Proxy.GetHashCode();
        }
    }
}
