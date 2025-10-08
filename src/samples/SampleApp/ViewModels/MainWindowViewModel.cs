using System;
using System.Collections.Generic;
using IconPacks.Avalonia.FeatherIcons;
using IconPacks.Avalonia.Material;

namespace SampleApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public List<Enum> SampleIcons { get; } =
    [
        PackIconFeatherIconsKind.Activity,
        PackIconMaterialKind.Abacus
    ];
}