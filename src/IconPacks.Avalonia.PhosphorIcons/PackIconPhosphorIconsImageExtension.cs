using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.PhosphorIcons
{
    public class PhosphorIconsImageExtension : BasePackIconImageExtension
    {
        public PhosphorIconsImageExtension()
        {
        }

        public PhosphorIconsImageExtension(PackIconPhosphorIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconPhosphorIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}