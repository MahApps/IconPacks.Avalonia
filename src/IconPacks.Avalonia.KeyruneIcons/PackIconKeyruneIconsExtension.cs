using System;
using Avalonia.Markup.Xaml;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.KeyruneIcons
{
    public class KeyruneIconsExtension : BasePackIconExtension
    {
        public KeyruneIconsExtension()
        {
        }

        public KeyruneIconsExtension(PackIconKeyruneIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconKeyruneIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetPackIcon<PackIconKeyruneIcons, PackIconKeyruneIconsKind>(this.Kind);
        }
    }
}