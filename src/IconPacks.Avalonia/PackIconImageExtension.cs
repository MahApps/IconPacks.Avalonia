using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia
{
    public class PackIconImageExtension : BasePackIconImageExtension
    {
        public PackIconImageExtension()
        {
        }

        public PackIconImageExtension(Enum kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public Enum Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}