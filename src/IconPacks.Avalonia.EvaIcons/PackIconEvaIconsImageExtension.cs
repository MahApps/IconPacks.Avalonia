using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.EvaIcons
{
    public class EvaIconsImageExtension : BasePackIconImageExtension
    {
        public EvaIconsImageExtension()
        {
        }

        public EvaIconsImageExtension(PackIconEvaIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconEvaIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}