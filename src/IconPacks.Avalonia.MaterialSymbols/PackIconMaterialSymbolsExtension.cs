using System;
using Avalonia.Markup.Xaml;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MaterialSymbols
{
    public class MaterialSymbolsExtension : BasePackIconExtension
    {
        public MaterialSymbolsExtension()
        {
        }

        public MaterialSymbolsExtension(PackIconMaterialSymbolsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMaterialSymbolsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetPackIcon<PackIconMaterialSymbols, PackIconMaterialSymbolsKind>(this.Kind);
        }
    }
}