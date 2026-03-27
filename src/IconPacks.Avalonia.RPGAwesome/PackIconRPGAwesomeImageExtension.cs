using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.RPGAwesome
{
    public class RPGAwesomeImageExtension : BasePackIconImageExtension
    {
        public RPGAwesomeImageExtension()
        {
        }

        public RPGAwesomeImageExtension(PackIconRPGAwesomeKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconRPGAwesomeKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}