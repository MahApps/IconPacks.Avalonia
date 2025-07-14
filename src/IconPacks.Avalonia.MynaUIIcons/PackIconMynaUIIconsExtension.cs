using System;
using Avalonia.Markup.Xaml;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MynaUIIcons
{
    public class MynaUIIconsExtension : BasePackIconExtension
    {
        public MynaUIIconsExtension()
        {
        }

        public MynaUIIconsExtension(PackIconMynaUIIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMynaUIIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetPackIcon<PackIconMynaUIIcons, PackIconMynaUIIconsKind>(this.Kind);
        }
    }
}