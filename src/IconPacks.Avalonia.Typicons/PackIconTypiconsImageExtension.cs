using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Typicons
{
    public class TypiconsImageExtension : BasePackIconImageExtension
    {
        public TypiconsImageExtension()
        {
        }

        public TypiconsImageExtension(PackIconTypiconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconTypiconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}