﻿using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Converter;

namespace IconPacks.Avalonia.MynaUIIcons.Converter
{
    public class PackIconMynaUIIconsKindToImageConverter : PackIconKindToImageConverterBase
    {
        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconMynaUIIconsKind kind)
            {
                PackIconDataFactory<PackIconMynaUIIconsKind>.DataIndex.Value?.TryGetValue(kind, out data);
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