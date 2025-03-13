﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GrayScalingApp.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
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
                UpdateInfoText();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading image: {ex.Message}");
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

        public string InfoText
        {
            get => infoText;
            set
            {
                if (infoText != value)
                {
                    infoText = value;
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

                    UpdateInfoText();
                    ApplyGrayscaleFilter();
                }
            }
        }

        private void UpdateInfoText()
        {
            InfoText = IsGrayscaleToggled ? "Grayscale is ON" : "Grayscale is OFF";
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}