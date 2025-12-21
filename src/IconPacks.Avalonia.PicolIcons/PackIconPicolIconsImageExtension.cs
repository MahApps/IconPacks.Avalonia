using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.PicolIcons
{
    public class PicolIconsImageExtension : BasePackIconImageExtension
    {
        public PicolIconsImageExtension()
        {
        }

        public PicolIconsImageExtension(PackIconPicolIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconPicolIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}