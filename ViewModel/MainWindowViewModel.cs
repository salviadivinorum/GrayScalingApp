using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GrayScalingApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ImageSource iconBackground;
        private string infoText;
        private bool isGrayscaleToggled;
        private readonly BitmapImage originalImage;

        public MainWindowViewModel()
        {
            try
            {
                originalImage = new BitmapImage();
                originalImage.BeginInit();
                originalImage.UriSource = new Uri("pack://application:,,,/Images/edit.png", UriKind.Absolute);
                originalImage.CacheOption = BitmapCacheOption.OnLoad;
                originalImage.EndInit();
                originalImage.Freeze();

                IconBackground = originalImage;
                isGrayscaleToggled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ImageSource IconBackground
        {
            get => iconBackground;
            set
            {
                if (iconBackground != value)
                {
                    iconBackground = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsGrayscaleToggled
        {
            get => isGrayscaleToggled;
            set
            {
                if (isGrayscaleToggled != value)
                {
                    isGrayscaleToggled = value;
                    OnPropertyChanged();

                    ApplyGrayscaleFilter();
                }
            }
        }

        private void ApplyGrayscaleFilter()
        {
            if (originalImage == null)
            {
                return;
            }

            if (IsGrayscaleToggled)
            {
                // gray scale version of the image
                FormatConvertedBitmap grayscaleBitmap = new FormatConvertedBitmap();
                grayscaleBitmap.BeginInit();
                grayscaleBitmap.Source = originalImage;
                grayscaleBitmap.DestinationFormat = PixelFormats.Gray8;
                grayscaleBitmap.EndInit();
                grayscaleBitmap.Freeze();

                IconBackground = grayscaleBitmap;
            }
            else
            {
                IconBackground = originalImage;
            }
        }
    }
}