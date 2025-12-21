using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Entypo
{
    public class EntypoImageExtension : BasePackIconImageExtension
    {
        public EntypoImageExtension()
        {
        }

        public EntypoImageExtension(PackIconEntypoKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconEntypoKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}