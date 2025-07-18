﻿using Avalonia;
using Avalonia.Media;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Core.Attributes;

namespace IconPacks.Avalonia.GameIcons
{
    /// <summary>
    /// All icons sourced from Game Icons <see><cref>https://github.com/game-icons/icons</cref></see>
    /// In accordance of <see><cref>https://github.com/game-icons/icons?tab=License-1-ov-file</cref></see>.
    /// </summary>
    [MetaData("Game Icons", "https://github.com/game-icons/icons", "https://github.com/game-icons/icons?tab=License-1-ov-file")]
    public class PackIconGameIcons : PackIconControlBase
    {
        public PackIconGameIcons()
        {
            UpdateIconPseudoClasses(true, false, false);
        }

        public static readonly StyledProperty<PackIconGameIconsKind> KindProperty
            = AvaloniaProperty.Register<PackIconGameIcons, PackIconGameIconsKind>(nameof(Kind));

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public PackIconGameIconsKind Kind
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
                PackIconDataFactory<PackIconGameIconsKind>.DataIndex.Value?.TryGetValue(Kind, out data);
                this.Data = data != null ? StreamGeometry.Parse(data) : null;
            }
            else
            {
                this.Data = null;
            }
        }
    }
}