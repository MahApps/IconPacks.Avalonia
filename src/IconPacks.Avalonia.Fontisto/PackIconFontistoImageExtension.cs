﻿using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Fontisto
{
    public class FontistoImageExtension : BasePackIconImageExtension
    {
        public FontistoImageExtension()
        {
        }

        public FontistoImageExtension(PackIconFontistoKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconFontistoKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }

        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconFontistoKind kind)
            {
                PackIconDataFactory<PackIconFontistoKind>.DataIndex.Value?.TryGetValue(kind, out data);
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