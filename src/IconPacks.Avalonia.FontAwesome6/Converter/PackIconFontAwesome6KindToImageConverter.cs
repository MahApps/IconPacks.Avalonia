using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Converter;

namespace IconPacks.Avalonia.FontAwesome6.Converter
{
    public class PackIconFontAwesome6KindToImageConverter : PackIconKindToImageConverterBase
    {
        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconFontAwesome6Kind kind)
            {
                PackIconDataFactory<PackIconFontAwesome6Kind>.DataIndex.Value?.TryGetValue(kind, out data);
            }

            return data;
        }
    }
}