using Avalonia;
using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Attributes;

namespace IconPacks.Avalonia.MaterialSymbols
{
    /// <summary>
    /// All icons sourced from GitHub <see><cref>https://github.com/marella/material-symbols</cref></see>
    /// In accordance of <see><cref>https://github.com/marella/material-symbols?tab=Apache-2.0-1-ov-file</cref></see>
    /// </summary>
    [MetaData("Material Symbols (Google)", "https://github.com/marella/material-symbols", "https://github.com/marella/material-symbols?tab=Apache-2.0-1-ov-file")]
    public class PackIconMaterialSymbols : PackIconControlBase
    {
        public PackIconMaterialSymbols()
        {
            UpdateIconPseudoClasses(true, false, false);
        }

        public static readonly StyledProperty<PackIconMaterialSymbolsKind> KindProperty
            = AvaloniaProperty.Register<PackIconMaterialSymbols, PackIconMaterialSymbolsKind>(nameof(Kind));

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconMaterialSymbolsKind Kind
        {
            get { return GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        // We override OnPropertyChanged of the base class. That way we can react on property changes
        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            // if the changed property is the KindProperty, we need to update the stars
            if (change.Property == KindProperty)
            {
                UpdateData();
            }
        }

        protected override void SetKind<TKind>(TKind iconKind)
        {
            this.SetCurrentValue(KindProperty, iconKind);
        }

        protected override void UpdateData()
        {
            if (Kind != default)
            {
                string data = null;
                PackIconDataFactory<PackIconMaterialSymbolsKind>.DataIndex.Value?.TryGetValue(Kind, out data);
                this.Data = data != null ? StreamGeometry.Parse(data) : null;
            }
            else
            {
                this.Data = null;
            }
        }
    }
}