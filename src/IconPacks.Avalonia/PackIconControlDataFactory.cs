using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using IconPacks.Avalonia.Core;
using IconPacks.Avalonia.BootstrapIcons;
using IconPacks.Avalonia.BoxIcons2;
using IconPacks.Avalonia.BoxIcons;
using IconPacks.Avalonia.CircumIcons;
using IconPacks.Avalonia.Codicons;
using IconPacks.Avalonia.Coolicons;
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
using SkiaSharp;

namespace IconPacks.Avalonia
{
    /// ******************************************
    /// This code is auto generated. Do not amend.
    /// ******************************************
    public static class PackIconControlDataFactory
    {
        public static Lazy<ReadOnlyDictionary<Enum, string>> DataIndex { get; }

        static PackIconControlDataFactory()
        {
            DataIndex = new Lazy<ReadOnlyDictionary<Enum, string>>(() => new ReadOnlyDictionary<Enum, string>(GetAllIcons()));
        }

        public static string ProvideSvgPathData(Enum kind)
        {
            string data = null;
            DataIndex.Value?.TryGetValue(kind, out data);

            // For some icons we need to flip them 
            switch (kind)
            {
                case PackIconBootstrapIconsKind:
                case PackIconBoxIconsKind:
                case PackIconCodiconsKind:
                case PackIconCooliconsKind:
                case PackIconEvaIconsKind:
                case PackIconFileIconsKind:
                case PackIconFontaudioKind:
                case PackIconFontistoKind:
                case PackIconForkAwesomeKind:
                case PackIconJamIconsKind:
                case PackIconLucideKind:
                case PackIconRPGAwesomeKind:
                case PackIconTypiconsKind:
                case PackIconVaadinIconsKind:
                    var skPath = SKPath.ParseSvgPathData(data);
                    skPath.Transform(SKMatrix.CreateScale(1,-1));
                    return skPath.ToSvgPathData();
                
                default:
                    return data;
            }
        }

        public static async Task<Bitmap> GetIconAsBitmapAsync(Enum kind, Color foreground, int width = 48, int height = 48)
        {
            try
            {
                await using var ms = new MemoryStream();
            
                await Task.Run(() =>
                {
                    var data = ProvideSvgPathData(kind);
                    var skPath = SKPath.ParseSvgPathData(data);
                    var originalBounds = skPath.Bounds;
                    
                    switch (kind)
                    {
                        case PackIconFeatherIconsKind:
                            originalBounds.Inflate(2f, 2f);
                            break;
                    }
                    
                    if (width < 0) width = (int)(Math.Ceiling(originalBounds.Width));
                    if (height < 0) height = (int)(Math.Ceiling(originalBounds.Height));

                    float scale = Math.Min(width / originalBounds.Width, height / originalBounds.Height);
                    
                    
                    skPath.Transform(SKMatrix.CreateScale(scale, scale));
                    skPath.Transform(SKMatrix.CreateTranslation( 
                        - skPath.Bounds.Left + (width - skPath.Bounds.Width ) / 2,
                        - skPath.Bounds.Top + (height - skPath.Bounds.Height ) / 2 ));
                
                    var skBitmap = new SKBitmap(width, height, SKColorType.Bgra8888, SKAlphaType.Premul);

                    using var skCanvas = new SKCanvas(skBitmap);

                    using var skPaint = new SKPaint();
                    skPaint.IsAntialias = true;
                    skPaint.Color = new SKColor(foreground.ToUInt32());

                    switch (kind)
                    {
                        case PackIconFeatherIconsKind:
                            skPaint.IsStroke = true;
                            skPaint.StrokeCap = SKStrokeCap.Round;
                            skPaint.StrokeWidth = 2 * scale;
                            break;
                    }

                    skCanvas.DrawPath(skPath, skPaint);

                    skBitmap.Encode(ms, SKEncodedImageFormat.Png, 100);

                    ms.Seek(0, SeekOrigin.Begin);
                });

                return new Bitmap(ms);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        internal static IDictionary<Enum, string> GetAllIcons()
        {
            var allIcons = new ConcurrentDictionary<Enum, string>();
            Parallel.ForEach(PackIconDataFactory<PackIconBootstrapIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconBoxIcons2Kind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconBoxIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconCircumIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconCodiconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconCooliconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconEntypoKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconEvaIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconFeatherIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconFileIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconFontaudioKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconFontAwesome5Kind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconFontAwesome6Kind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconFontAwesomeKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconFontistoKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconForkAwesomeKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconGameIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconIoniconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconJamIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconKeyruneIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconLucideKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconMaterialKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconMaterialLightKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconMaterialDesignKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconMemoryIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconMicronsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconMingCuteIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconModernKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconMynaUIIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconOcticonsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconPhosphorIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconPicolIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconPixelartIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconRadixIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconRemixIconKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconRPGAwesomeKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconSimpleIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconTypiconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconUniconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconVaadinIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconWeatherIconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            Parallel.ForEach(PackIconDataFactory<PackIconZondiconsKind>.Create(), icon => { allIcons.TryAdd(icon.Key, icon.Value); });
            return allIcons;
        }
    }
}