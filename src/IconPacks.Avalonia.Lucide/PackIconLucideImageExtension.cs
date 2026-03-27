using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Lucide
{
    public class LucideImageExtension : BasePackIconImageExtension
    {
        public LucideImageExtension()
        {
        }

        public LucideImageExtension(PackIconLucideKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconLucideKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}