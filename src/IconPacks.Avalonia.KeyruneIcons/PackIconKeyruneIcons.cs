using Avalonia;
using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Attributes;

namespace IconPacks.Avalonia.KeyruneIcons
{
    /// <summary>
    /// All icons sourced from GitHub <see><cref>https://github.com/andrewgioia/keyrune</cref></see>
    /// In accordance of <see><cref>https://github.com/andrewgioia/keyrune?tab=License-1-ov-file</cref></see>.
    /// </summary>
    [MetaData("Keyrune Icons", "https://github.com/andrewgioia/keyrune", "https://github.com/andrewgioia/keyrune?tab=License-1-ov-file")]
    public class PackIconKeyruneIcons : PackIconControlBase
    {
        public static readonly StyledProperty<PackIconKeyruneIconsKind> KindProperty
            = AvaloniaProperty.Register<PackIconKeyruneIcons, PackIconKeyruneIconsKind>(nameof(Kind));

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconKeyruneIconsKind Kind
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
                PackIconDataFactory<PackIconKeyruneIconsKind>.DataIndex.Value?.TryGetValue(Kind, out data);
                this.Data = data != null ? StreamGeometry.Parse(data) : null;
            }
            else
            {
                this.Data = null;
            }
        }
    }
}