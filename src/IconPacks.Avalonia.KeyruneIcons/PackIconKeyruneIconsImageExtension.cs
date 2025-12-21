using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
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