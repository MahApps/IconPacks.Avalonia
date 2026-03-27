using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.FontAwesome
{
    public class FontAwesomeImageExtension : BasePackIconImageExtension
    {
        public FontAwesomeImageExtension()
        {
        }

        public FontAwesomeImageExtension(PackIconFontAwesomeKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconFontAwesomeKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}