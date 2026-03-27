using System;
using Avalonia.Media;
using Avalonia.Metadata;
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