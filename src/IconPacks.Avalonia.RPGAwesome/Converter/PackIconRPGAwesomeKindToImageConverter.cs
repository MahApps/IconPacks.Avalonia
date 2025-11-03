using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Converter;

namespace IconPacks.Avalonia.RPGAwesome.Converter
{
    public class PackIconRPGAwesomeKindToImageConverter : PackIconKindToImageConverterBase
    {
        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconRPGAwesomeKind kind)
            {
                PackIconDataFactory<PackIconRPGAwesomeKind>.DataIndex.Value?.TryGetValue(kind, out data);
            }

            return data;
        }
    }
}