using System;
using Avalonia.Media;
using Avalonia.Metadata;
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