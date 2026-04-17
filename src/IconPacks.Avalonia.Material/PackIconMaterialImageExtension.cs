using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Material
{
    public class MaterialImageExtension : BasePackIconImageExtension
    {
        public MaterialImageExtension()
        {
        }

        public MaterialImageExtension(PackIconMaterialKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMaterialKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}