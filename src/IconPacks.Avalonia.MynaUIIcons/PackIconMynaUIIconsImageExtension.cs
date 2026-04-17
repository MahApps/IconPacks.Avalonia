using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MynaUIIcons
{
    public class MynaUIIconsImageExtension : BasePackIconImageExtension
    {
        public MynaUIIconsImageExtension()
        {
        }

        public MynaUIIconsImageExtension(PackIconMynaUIIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMynaUIIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}