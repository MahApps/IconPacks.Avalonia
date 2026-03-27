using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Ionicons
{
    public class IoniconsImageExtension : BasePackIconImageExtension
    {
        public IoniconsImageExtension()
        {
        }

        public IoniconsImageExtension(PackIconIoniconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconIoniconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}