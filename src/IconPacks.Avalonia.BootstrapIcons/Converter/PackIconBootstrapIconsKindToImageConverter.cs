﻿using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Converter;

namespace IconPacks.Avalonia.BootstrapIcons.Converter
{
    public class PackIconBootstrapIconsKindToImageConverter : PackIconKindToImageConverterBase
    {
        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconBootstrapIconsKind kind)
            {
                PackIconDataFactory<PackIconBootstrapIconsKind>.DataIndex.Value?.TryGetValue(kind, out data);
            }

            return data;
        }

        /// <inheritdoc />
        protected override ScaleTransform GetScaleTransform(object iconKind)
        {
            return new ScaleTransform(1, -1);
        }
    }
}