using System.Windows.Input;
using System.Windows.Media;
using GrayScalingApp.Model;

namespace GrayScalingApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ImageSource? iconBackground;
        private string searchText;
        private bool isGrayscaleToggled;

        public MainWindowViewModel()
        {
            // TODO: Initialize the icon background.
            // For now, IconBackground can be set when the image is loaded.
            GrayscaleCommand = new RelayCommand(ExecuteGrayscale, CanExecuteGrayscale);
            UpdateSearchText();
        }

        public ICommand GrayscaleCommand { get; }

        public ImageSource? IconBackground
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

        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText != value)
                {
                    searchText = value;
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
                    UpdateSearchText();
                }
            }
        }

        private bool CanExecuteGrayscale(object parameter)
        {
            // Enable the command by default.
            return true;
        }

        private void ExecuteGrayscale(object parameter)
        {
            // TODO: Add gray scaling logic here.
        }

        private void UpdateSearchText()
        {
            SearchText = IsGrayscaleToggled ? "Grayscale is ON" : "Grayscale is OFF";
        }
    }
}
