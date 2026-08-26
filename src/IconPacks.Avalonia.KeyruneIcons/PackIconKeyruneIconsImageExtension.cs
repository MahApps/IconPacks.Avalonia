using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.KeyruneIcons
{
    public class KeyruneIconsImageExtension : BasePackIconImageExtension
    {
        public KeyruneIconsImageExtension()
        {
        }

        public KeyruneIconsImageExtension(PackIconKeyruneIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconKeyruneIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}