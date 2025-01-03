﻿using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.Entypo
{
    public class EntypoImageExtension : BasePackIconImageExtension
    {
        public EntypoImageExtension()
        {
        }

        public EntypoImageExtension(PackIconEntypoKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconEntypoKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }

        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconEntypoKind kind)
            {
                PackIconDataFactory<PackIconEntypoKind>.DataIndex.Value?.TryGetValue(kind, out data);
            }

            return data;
        }
    }
}