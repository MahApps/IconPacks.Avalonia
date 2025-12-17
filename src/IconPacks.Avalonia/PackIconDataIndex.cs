using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IconPacks.Avalonia.BootstrapIcons;
using IconPacks.Avalonia.BoxIcons2;
using IconPacks.Avalonia.BoxIcons;
using IconPacks.Avalonia.CircumIcons;
using IconPacks.Avalonia.Codicons;
using IconPacks.Avalonia.Coolicons;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.Entypo;
using IconPacks.Avalonia.EvaIcons;
using IconPacks.Avalonia.FeatherIcons;
using IconPacks.Avalonia.FileIcons;
using IconPacks.Avalonia.Fontaudio;
using IconPacks.Avalonia.FontAwesome5;
using IconPacks.Avalonia.FontAwesome6;
using IconPacks.Avalonia.FontAwesome;
using IconPacks.Avalonia.Fontisto;
using IconPacks.Avalonia.ForkAwesome;
using IconPacks.Avalonia.GameIcons;
using IconPacks.Avalonia.Ionicons;
using IconPacks.Avalonia.JamIcons;
using IconPacks.Avalonia.KeyruneIcons;
using IconPacks.Avalonia.Lucide;
using IconPacks.Avalonia.Material;
using IconPacks.Avalonia.MaterialLight;
using IconPacks.Avalonia.MaterialDesign;
using IconPacks.Avalonia.MemoryIcons;
using IconPacks.Avalonia.Microns;
using IconPacks.Avalonia.MingCuteIcons;
using IconPacks.Avalonia.Modern;
using IconPacks.Avalonia.MynaUIIcons;
using IconPacks.Avalonia.Octicons;
using IconPacks.Avalonia.PhosphorIcons;
using IconPacks.Avalonia.PicolIcons;
using IconPacks.Avalonia.PixelartIcons;
using IconPacks.Avalonia.RadixIcons;
using IconPacks.Avalonia.RemixIcon;
using IconPacks.Avalonia.RPGAwesome;
using IconPacks.Avalonia.SimpleIcons;
using IconPacks.Avalonia.Typicons;
using IconPacks.Avalonia.Unicons;
using IconPacks.Avalonia.VaadinIcons;
using IconPacks.Avalonia.WeatherIcons;
using IconPacks.Avalonia.Zondicons;

namespace IconPacks.Avalonia;

public static class PackIconDataIndex
{
    private static readonly object Gate = new();
    private static readonly Dictionary<Type, Lazy<ReadOnlyDictionary<Enum, string>>> Packs = new();

    static PackIconDataIndex()
    {
        Register<PackIconBootstrapIconsKind>();
        Register<PackIconBoxIcons2Kind>();
        Register<PackIconBoxIconsKind>();
        Register<PackIconCircumIconsKind>();
        Register<PackIconCodiconsKind>();
        Register<PackIconCooliconsKind>();
        Register<PackIconEntypoKind>();
        Register<PackIconEvaIconsKind>();
        Register<PackIconFeatherIconsKind>();
        Register<PackIconFileIconsKind>();
        Register<PackIconFontaudioKind>();
        Register<PackIconFontAwesome5Kind>();
        Register<PackIconFontAwesome6Kind>();
        Register<PackIconFontAwesomeKind>();
        Register<PackIconFontistoKind>();
        Register<PackIconForkAwesomeKind>();
        Register<PackIconGameIconsKind>();
        Register<PackIconIoniconsKind>();
        Register<PackIconJamIconsKind>();
        Register<PackIconKeyruneIconsKind>();
        Register<PackIconLucideKind>();
        Register<PackIconMaterialKind>();
        Register<PackIconMaterialLightKind>();
        Register<PackIconMaterialDesignKind>();
        Register<PackIconMemoryIconsKind>();
        Register<PackIconMicronsKind>();
        Register<PackIconMingCuteIconsKind>();
        Register<PackIconModernKind>();
        Register<PackIconMynaUIIconsKind>();
        Register<PackIconOcticonsKind>();
        Register<PackIconPhosphorIconsKind>();
        Register<PackIconPicolIconsKind>();
        Register<PackIconPixelartIconsKind>();
        Register<PackIconRadixIconsKind>();
        Register<PackIconRemixIconKind>();
        Register<PackIconRPGAwesomeKind>();
        Register<PackIconSimpleIconsKind>();
        Register<PackIconTypiconsKind>();
        Register<PackIconUniconsKind>();
        Register<PackIconVaadinIconsKind>();
        Register<PackIconWeatherIconsKind>();
        Register<PackIconZondiconsKind>();
    }

    private static void Register<TKind>() where TKind : struct, Enum
    {
        var type = typeof(TKind);
        lock (Gate)
        {
            if (!Packs.ContainsKey(type))
            {
                Packs[type] = new Lazy<ReadOnlyDictionary<Enum, string>>(
                    () =>
                    {
                        // Convert IDictionary<TKind, string> to IDictionary<Enum, string>
                        var src = PackIconDataFactory<TKind>.Create();
                        var dst = new Dictionary<Enum, string>(src.Count);
                        foreach (var kv in src)
                        {
                            dst[kv.Key] = kv.Value; // box TKind to Enum
                        }
                        return new ReadOnlyDictionary<Enum, string>(dst);
                    });
            }
        }
    }

    public static bool TryGetPath(Enum kind, out string path)
    {
        var type = kind.GetType();
        Lazy<ReadOnlyDictionary<Enum, string>> lazyPack;
        lock (Gate)
        {
            Packs.TryGetValue(type, out lazyPack);
        }

        if (lazyPack is null)
        {
            path = null;
            return false;
        }

        var dict = lazyPack.Value; // triggers per-pack build on first use
        return dict.TryGetValue(kind, out path);
    }
}