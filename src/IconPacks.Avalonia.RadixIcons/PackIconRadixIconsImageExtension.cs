using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.RadixIcons
{
    public class RadixIconsImageExtension : BasePackIconImageExtension
    {
        public RadixIconsImageExtension()
        {
        }

        public RadixIconsImageExtension(PackIconRadixIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconRadixIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}