using System;
using Avalonia.Media;
using Avalonia.Metadata;
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