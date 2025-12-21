using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.FontAwesome5
{
    public class FontAwesome5ImageExtension : BasePackIconImageExtension
    {
        public FontAwesome5ImageExtension()
        {
        }

        public FontAwesome5ImageExtension(PackIconFontAwesome5Kind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconFontAwesome5Kind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}