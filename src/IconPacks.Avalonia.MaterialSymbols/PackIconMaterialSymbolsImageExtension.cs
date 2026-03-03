using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MaterialSymbols
{
    public class MaterialSymbolsImageExtension : BasePackIconImageExtension
    {
        public MaterialSymbolsImageExtension()
        {
        }

        public MaterialSymbolsImageExtension(PackIconMaterialSymbolsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMaterialSymbolsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }

        /// <inheritdoc />
        protected override string GetPathData(object iconKind)
        {
            string data = null;
            if (iconKind is PackIconMaterialSymbolsKind kind)
            {
                PackIconDataFactory<PackIconMaterialSymbolsKind>.DataIndex.Value?.TryGetValue(kind, out data);
            }

            return data;
        }
    }
}