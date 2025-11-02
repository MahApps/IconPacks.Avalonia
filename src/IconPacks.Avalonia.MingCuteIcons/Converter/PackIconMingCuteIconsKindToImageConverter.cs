using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Converter;

namespace IconPacks.Avalonia.MingCuteIcons.Converter
{
    public class PackIconMingCuteIconsKindToImageConverter : PackIconKindToImageConverterBase
    {
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