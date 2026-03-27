using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Modern
{
    public class ModernImageExtension : BasePackIconImageExtension
    {
        public ModernImageExtension()
        {
        }

        public ModernImageExtension(PackIconModernKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconModernKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}