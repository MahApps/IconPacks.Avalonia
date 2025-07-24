using Avalonia;
using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Attributes;

namespace IconPacks.Avalonia.FontAwesome5
{
    /// <summary>
    /// All icons sourced from Font Awesome Free <see><cref>https://fontawesome.com/</cref></see> - License <see><cref>https://fontawesome.com/license/free</cref></see>
    /// GitHub <see><cref>https://fontawesome.com/</cref></see>
    /// </summary>
    [MetaData("Font Awesome Free v5", "https://fontawesome.com/", "https://fontawesome.com/license/free")]
    public class PackIconFontAwesome5 : PackIconControlBase
    {
        public PackIconFontAwesome5()
        {
            UpdateIconPseudoClasses(true, false, false);
        }

        public static readonly StyledProperty<PackIconFontAwesome5Kind> KindProperty
            = AvaloniaProperty.Register<PackIconFontAwesome5, PackIconFontAwesome5Kind>(nameof(Kind));

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconFontAwesome5Kind Kind
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
                PackIconDataFactory<PackIconFontAwesome5Kind>.DataIndex.Value?.TryGetValue(Kind, out data);
                this.Data = data != null ? StreamGeometry.Parse(data) : null;
            }
            else
            {
                this.Data = null;
            }
        }
    }
}