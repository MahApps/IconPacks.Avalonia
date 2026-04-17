using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Octicons
{
    public class OcticonsImageExtension : BasePackIconImageExtension
    {
        public OcticonsImageExtension()
        {
        }

        public OcticonsImageExtension(PackIconOcticonsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconOcticonsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}