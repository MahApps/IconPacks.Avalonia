using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.BoxIcons
{
    public class BoxIconsImageExtension : BasePackIconImageExtension
    {
        public BoxIconsImageExtension()
        {
        }

        public BoxIconsImageExtension(PackIconBoxIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconBoxIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}