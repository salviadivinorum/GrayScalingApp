using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GrayScalingApp.Model
{
    class AutoDisableImage : Image
    {
        static AutoDisableImage()
        {
            IsEnabledProperty.OverrideMetadata(
                typeof(AutoDisableImage),
                new FrameworkPropertyMetadata(
                    true,
                    OnAutoDisableImagePropertyChanged));
        }

        private static void OnAutoDisableImagePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
        {
            if (source is AutoDisableImage me)
            {
                me.UpdateImage();
            }
        }

        protected void UpdateImage()
        {
            if (Source == null)
            {
                return;
            }

            if (IsEnabled)
            {
                if (Source is FormatConvertedBitmap fcb)
                {
                    Source = fcb.Source;
                    OpacityMask = null;
                }

                // Opacity = 1.0;
            }
            else
            {
                if (Source is BitmapSource bmp && Source is not FormatConvertedBitmap)
                {
                    var grayscaleBitmap = new FormatConvertedBitmap();
                    grayscaleBitmap.BeginInit();
                    grayscaleBitmap.Source = bmp;
                    grayscaleBitmap.DestinationFormat = PixelFormats.Gray8;
                    grayscaleBitmap.EndInit();
                    grayscaleBitmap.Freeze(); // Freeze for performance

                    Source = grayscaleBitmap;

                    // Create opacity mask
                    var brush = new ImageBrush(bmp);
                    brush.Freeze(); // Freeze for performance
                    OpacityMask = brush;

                    // Opacity = 0.25;
                }

               
            }
        }
    }
}
