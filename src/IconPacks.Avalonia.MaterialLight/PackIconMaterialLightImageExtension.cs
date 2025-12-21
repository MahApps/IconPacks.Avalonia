using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
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