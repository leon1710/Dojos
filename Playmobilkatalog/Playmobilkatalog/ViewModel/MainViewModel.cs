using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;

namespace Playmobilkatalog.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public ObservableCollection<PlaymobilItem> Items { get; set; }

        private PlaymobilItem currentItem;
        public PlaymobilItem CurrentItem
        {
            get
            {
                return currentItem;
            }

            set
            {
                currentItem = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Items = new ObservableCollection<PlaymobilItem>();
            GenerateDemoData();

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private void GenerateDemoData()
        {
            Items.Add(new PlaymobilItem("Auto", 2343, "S+", 10, new System.Windows.Media.Imaging.BitmapImage(new Uri("Images/auto.jpg",UriKind.Relative)),100,100));
            Items.Add(new PlaymobilItem("Playmobilhaus", 2343, "S+", 10, new System.Windows.Media.Imaging.BitmapImage(new Uri("Images/playmobilhouse.png", UriKind.Relative)), 50, 50));
            Items.Add(new PlaymobilItem("Rutsche", 2343, "S+", 10, new System.Windows.Media.Imaging.BitmapImage(new Uri("Images/rutsche.jpg", UriKind.Relative)), 300, 30));
            Items.Add(new PlaymobilItem("Wohnmobil", 2343, "S+", 10, new System.Windows.Media.Imaging.BitmapImage(new Uri("Images/wohnmobil.jpg", UriKind.Relative)), 250, 10));

        }
    }
}