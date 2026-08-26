using Avalonia;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Attributes;

namespace IconPacks.Avalonia.MingCuteIcons
{
    /// <summary>
    /// MingCute Icon are licensed under [Apache-2.0 license](<see><cref>https://github.com/Richard9394/MingCute?tab=Apache-2.0-1-ov-file</cref></see>).
    /// Contributions, corrections and requests can be made on GitHub <see><cref>https://github.com/Richard9394/MingCute</cref></see>.
    /// </summary>
    [MetaData("MingCute Icon", "https://github.com/Richard9394/MingCute", "https://github.com/Richard9394/MingCute?tab=Apache-2.0-1-ov-file")]
    public class PackIconMingCuteIcons : PackIconControlBase
    {
        public static readonly StyledProperty<PackIconMingCuteIconsKind> KindProperty
            = AvaloniaProperty.Register<PackIconMingCuteIcons, PackIconMingCuteIconsKind>(nameof(Kind));

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconMingCuteIconsKind Kind
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
                this.Data = PackIconGeometryCache.GetOrAdd(Kind);
            }
            else
            {
                this.Data = null;
            }
        }
    }
}