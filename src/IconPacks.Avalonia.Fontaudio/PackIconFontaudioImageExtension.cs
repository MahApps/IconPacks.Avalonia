using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Fontaudio
{
    public class FontaudioImageExtension : BasePackIconImageExtension
    {
        public FontaudioImageExtension()
        {
        }

        public FontaudioImageExtension(PackIconFontaudioKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconFontaudioKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}