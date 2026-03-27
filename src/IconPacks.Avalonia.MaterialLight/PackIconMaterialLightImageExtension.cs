using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MaterialLight
{
    public class MaterialLightImageExtension : BasePackIconImageExtension
    {
        public MaterialLightImageExtension()
        {
        }

        public MaterialLightImageExtension(PackIconMaterialLightKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMaterialLightKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}