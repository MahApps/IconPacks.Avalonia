using System;
using Avalonia;
using IconPacks.Avalonia.Core;

namespace IconPacks.Avalonia
{
    /// <summary>
    /// </summary>
    public class PackIconControl : PackIconControlBase
    {
        public static int GeometryCache { get; set; } = 1000;

        public static readonly StyledProperty<Enum> KindProperty
            = AvaloniaProperty.Register<PackIconControl, Enum>(nameof(Kind));

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public Enum Kind
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
            var kind = Kind;
            
            if (kind is null)
            {
                Data = null;
                return;
            }

            var geometry = IconGeometryCache.GetOrAdd(kind, () =>
            {
                return PackIconDataIndex.TryGetPath(kind, out var data) ? data : null;
            });

            Data = geometry;
        }
    }
}