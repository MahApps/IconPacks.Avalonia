using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.BootstrapIcons
{
    public class BootstrapIconsImageExtension : BasePackIconImageExtension
    {
        public BootstrapIconsImageExtension()
        {
        }

        public BootstrapIconsImageExtension(PackIconBootstrapIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconBootstrapIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}