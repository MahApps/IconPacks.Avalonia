using System;
using Avalonia.Markup.Xaml;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.FontAwesome5
{
    public class FontAwesome5Extension : BasePackIconExtension
    {
        public FontAwesome5Extension()
        {
        }

        public FontAwesome5Extension(PackIconFontAwesome5Kind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconFontAwesome5Kind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetPackIcon<PackIconFontAwesome5, PackIconFontAwesome5Kind>(this.Kind);
        }
    }
}