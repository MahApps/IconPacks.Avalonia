using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MingCuteIcons
{
    public class MingCuteIconsImageExtension : BasePackIconImageExtension
    {
        public MingCuteIconsImageExtension()
        {
        }

        public MingCuteIconsImageExtension(PackIconMingCuteIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMingCuteIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}