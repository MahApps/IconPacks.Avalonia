using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia
{
    public class PackIconImageExtension : BasePackIconImageExtension
    {
        public PackIconImageExtension()
        {
        }

        public PackIconImageExtension(Enum kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public Enum Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}