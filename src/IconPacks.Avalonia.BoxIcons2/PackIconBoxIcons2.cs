using Avalonia;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Attributes;

namespace IconPacks.Avalonia.BoxIcons2
{
    /// <summary>
    /// BoxIcons licensed under [MIT](<see><cref>https://v2.boxicons.com/usage#license</cref></see>)
    /// Contributions, corrections and requests can be made on GitHub <see><cref>https://github.com/atisawd/boxicons</cref></see>.
    /// </summary>
    [MetaData("Boxicons v2", "https://v2.boxicons.com/", "https://v2.boxicons.com/usage#license")]
    public class PackIconBoxIcons2 : PackIconControlBase
    {
        public static readonly StyledProperty<PackIconBoxIcons2Kind> KindProperty
            = AvaloniaProperty.Register<PackIconBoxIcons2, PackIconBoxIcons2Kind>(nameof(Kind));

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconBoxIcons2Kind Kind
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