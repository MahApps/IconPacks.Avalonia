using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.BoxIcons2
{
    public class BoxIcons2ImageExtension : BasePackIconImageExtension
    {
        public BoxIcons2ImageExtension()
        {
        }

        public BoxIcons2ImageExtension(PackIconBoxIcons2Kind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconBoxIcons2Kind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}