using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia.MynaUIIcons
{
    public class MynaUIIconsImageExtension : BasePackIconImageExtension
    {
        public MynaUIIconsImageExtension()
        {
        }

        public MynaUIIconsImageExtension(PackIconMynaUIIconsKind kind)
        {
            this.Kind = kind;
        }

        [ConstructorArgument("kind")] public PackIconMynaUIIconsKind Kind { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Kind, this.Brush ?? Brushes.Black);
        }

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
    }
}