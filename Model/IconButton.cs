using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GrayScalingApp.Model
{
    public class IconButton : Button
    {
        private readonly AutoDisableImage? image;

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(IconButton),
                new PropertyMetadata(null, OnImageSourceChanged));

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
            IsEnabledProperty.OverrideMetadata(typeof(IconButton),
                new FrameworkPropertyMetadata(true, OnIsEnabledChanged));
        }

        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var iconButton = (IconButton)d;
            iconButton.UpdateImage();
        }

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var iconButton = (IconButton)d;
            iconButton.UpdateImage();
        }

        private void UpdateImage()
        {
            if (image != null)
            {
                image.Source = ImageSource;
                image.IsEnabled = IsEnabled;
            }
        }
    }
}
