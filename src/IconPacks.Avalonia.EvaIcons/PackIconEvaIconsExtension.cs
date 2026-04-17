using System;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.EvaIcons
{
    public class EvaIconsExtension : BasePackIconExtension
    {
        public EvaIconsExtension()
        {
        }

        public EvaIconsExtension(PackIconEvaIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconEvaIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetPackIcon<PackIconEvaIcons, PackIconEvaIconsKind>(this.Kind);
        }
    }
}