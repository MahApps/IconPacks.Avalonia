using System;
using Avalonia.Media;
using Avalonia.Metadata;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.WeatherIcons
{
    public class WeatherIconsImageExtension : BasePackIconImageExtension
    {
        public WeatherIconsImageExtension()
        {
        }

        public WeatherIconsImageExtension(PackIconWeatherIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconWeatherIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }
    }
}