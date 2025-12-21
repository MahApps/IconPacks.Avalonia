using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.ForkAwesome
{
    public class ForkAwesomeImageExtension : BasePackIconImageExtension
    {
        public ForkAwesomeImageExtension()
        {
        }

        public ForkAwesomeImageExtension(PackIconForkAwesomeKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconForkAwesomeKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}