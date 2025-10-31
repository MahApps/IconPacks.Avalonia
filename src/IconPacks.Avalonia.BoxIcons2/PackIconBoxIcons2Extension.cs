using System;
using Avalonia.Markup.Xaml;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.BoxIcons2
{
    public class BoxIcons2Extension : BasePackIconExtension
    {
        public BoxIcons2Extension()
        {
        }

        public BoxIcons2Extension(PackIconBoxIcons2Kind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconBoxIcons2Kind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetPackIcon<PackIconBoxIcons2, PackIconBoxIcons2Kind>(this.Kind);
        }
    }
}