using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.VaadinIcons
{
    public class VaadinIconsImageExtension : BasePackIconImageExtension
    {
        public VaadinIconsImageExtension()
        {
        }

        public VaadinIconsImageExtension(PackIconVaadinIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconVaadinIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}