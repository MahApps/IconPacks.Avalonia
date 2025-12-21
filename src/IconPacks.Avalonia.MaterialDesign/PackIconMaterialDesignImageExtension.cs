using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MaterialDesign
{
    public class MaterialDesignImageExtension : BasePackIconImageExtension
    {
        public MaterialDesignImageExtension()
        {
        }

        public MaterialDesignImageExtension(PackIconMaterialDesignKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMaterialDesignKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}