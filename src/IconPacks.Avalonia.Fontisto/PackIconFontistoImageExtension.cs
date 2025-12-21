using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Fontisto
{
    public class FontistoImageExtension : BasePackIconImageExtension
    {
        public FontistoImageExtension()
        {
        }

        public FontistoImageExtension(PackIconFontistoKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconFontistoKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}