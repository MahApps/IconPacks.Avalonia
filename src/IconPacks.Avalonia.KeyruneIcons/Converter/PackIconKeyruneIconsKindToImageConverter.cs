using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Converter;

namespace IconPacks.Avalonia.KeyruneIcons.Converter
{
    public class PackIconKeyruneIconsKindToImageConverter : PackIconKindToImageConverterBase
    {
        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconKeyruneIconsKind kind)
            {
                PackIconDataFactory<PackIconKeyruneIconsKind>.DataIndex.Value?.TryGetValue(kind, out data);
            }

            return data;
        }
    }
}