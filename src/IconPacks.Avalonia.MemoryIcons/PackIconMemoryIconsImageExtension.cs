using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MemoryIcons
{
    public class MemoryIconsImageExtension : BasePackIconImageExtension
    {
        public MemoryIconsImageExtension()
        {
        }

        public MemoryIconsImageExtension(PackIconMemoryIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMemoryIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}