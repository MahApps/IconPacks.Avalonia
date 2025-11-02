using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MingCuteIcons
{
    public class MingCuteIconsImageExtension : BasePackIconImageExtension
    {
        public MingCuteIconsImageExtension()
        {
        }

        public MingCuteIconsImageExtension(PackIconMingCuteIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMingCuteIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }

        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconMingCuteIconsKind kind)
            {
                PackIconDataFactory<PackIconMingCuteIconsKind>.DataIndex.Value?.TryGetValue(kind, out data);
            }

            return data;
        }
    }
}