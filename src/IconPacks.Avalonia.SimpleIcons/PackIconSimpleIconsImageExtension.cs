using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.SimpleIcons
{
    public class SimpleIconsImageExtension : BasePackIconImageExtension
    {
        public SimpleIconsImageExtension()
        {
        }

        public SimpleIconsImageExtension(PackIconSimpleIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconSimpleIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}