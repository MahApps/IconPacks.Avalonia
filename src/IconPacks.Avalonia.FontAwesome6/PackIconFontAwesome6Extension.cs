using System;
using Avalonia.Markup.Xaml;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.FontAwesome6
{
    public class FontAwesome6Extension : BasePackIconExtension
    {
        public FontAwesome6Extension()
        {
        }

        public FontAwesome6Extension(PackIconFontAwesome6Kind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconFontAwesome6Kind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetPackIcon<PackIconFontAwesome6, PackIconFontAwesome6Kind>(this.Kind);
        }
    }
}