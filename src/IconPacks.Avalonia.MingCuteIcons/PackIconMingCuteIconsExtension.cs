using System;
using Avalonia.Markup.Xaml;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MingCuteIcons
{
    public class MingCuteIconsExtension : BasePackIconExtension
    {
        public MingCuteIconsExtension()
        {
        }

        public MingCuteIconsExtension(PackIconMingCuteIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMingCuteIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetPackIcon<PackIconMingCuteIcons, PackIconMingCuteIconsKind>(this.Kind);
        }
    }
}