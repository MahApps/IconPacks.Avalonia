using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.FeatherIcons
{
    public class FeatherIconsImageExtension : BasePackIconImageExtension
    {
        public FeatherIconsImageExtension()
        {
        }

        public FeatherIconsImageExtension(PackIconFeatherIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconFeatherIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}