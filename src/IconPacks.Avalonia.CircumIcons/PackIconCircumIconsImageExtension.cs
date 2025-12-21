using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.CircumIcons
{
    public class CircumIconsImageExtension : BasePackIconImageExtension
    {
        public CircumIconsImageExtension()
        {
        }

        public CircumIconsImageExtension(PackIconCircumIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconCircumIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}