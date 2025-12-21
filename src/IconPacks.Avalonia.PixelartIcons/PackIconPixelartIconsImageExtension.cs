using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.PixelartIcons
{
    public class PixelartIconsImageExtension : BasePackIconImageExtension
    {
        public PixelartIconsImageExtension()
        {
        }

        public PixelartIconsImageExtension(PackIconPixelartIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconPixelartIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}