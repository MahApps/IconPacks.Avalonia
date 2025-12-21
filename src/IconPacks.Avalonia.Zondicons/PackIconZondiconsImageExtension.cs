using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Zondicons
{
    public class ZondiconsImageExtension : BasePackIconImageExtension
    {
        public ZondiconsImageExtension()
        {
        }

        public ZondiconsImageExtension(PackIconZondiconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconZondiconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}