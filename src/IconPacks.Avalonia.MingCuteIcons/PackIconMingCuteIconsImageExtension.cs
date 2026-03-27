using System;
using Avalonia.Media;
using Avalonia.Metadata;
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