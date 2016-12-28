using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ItemVM> legoitems;
        private ObservableCollection<ItemVM> playitems;
        private ObservableCollection<ItemVM> categoryItems;
        private ItemVM selectedCategory;

        public MainViewModel()
        {
            Legoitems = new ObservableCollection<ItemVM>();
            Playitems = new ObservableCollection<ItemVM>();
            CategoryItems = new ObservableCollection<ItemVM>();
            FillLists();
        }

        #region props
        public ObservableCollection<ItemVM> Legoitems
        {
            get
            {
                return legoitems;
            }

            set
            {
                legoitems = value;
            }
        }

        public ObservableCollection<ItemVM> Playitems
        {
            get
            {
                return playitems;
            }

            set
            {
                playitems = value;
            }
        }

        public ItemVM SelectedCategory
        {
            get
            {
                return selectedCategory;
            }

            set
            {
                selectedCategory = value;
            }
        }

        public ObservableCollection<ItemVM> CategoryItems
        {
            get
            {
                return categoryItems;
            }

            set
            {
                categoryItems = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public void FillLists()
        {
            Legoitems.Add(new ItemVM("5+", "Ritterburg", new BitmapImage(new Uri("Bilder/Lego_burg.jpg", UriKind.Relative))));
            Legoitems.Add(new ItemVM("12+", "City", new BitmapImage(new Uri("Bilder/Lego_city.jpg", UriKind.Relative))));
            Legoitems.Add(new ItemVM("10+", "Dr. Who", new BitmapImage(new Uri("Bilder/Lego_DrWho.jpg", UriKind.Relative))));
            Legoitems.Add(new ItemVM("8+", "Harry Potter", new BitmapImage(new Uri("Bilder/Lego_harrypotter.jpg", UriKind.Relative))));
            Legoitems.Add(new ItemVM("5+", "Superheroes", new BitmapImage(new Uri("Bilder/Lego_superheroes.jpg", UriKind.Relative))));

            Playitems.Add(new ItemVM("5+", "Piraten", new BitmapImage(new Uri("Bilder/Play_piratenschatz.jpg", UriKind.Relative))));
            Playitems.Add(new ItemVM("3+", "Schulbus", new BitmapImage(new Uri("Bilder/Play_schulbus.jpg", UriKind.Relative))));
            Playitems.Add(new ItemVM("8+", "Schwimmbad", new BitmapImage(new Uri("Bilder/Play_schwimmen.jpg", UriKind.Relative))));
            Playitems.Add(new ItemVM("5+", "Spielplatz", new BitmapImage(new Uri("Bilder/Play_spielplatz.jpg", UriKind.Relative))));
            Playitems.Add(new ItemVM("10+", "Zoo", new BitmapImage(new Uri("Bilder/Play_zoo.jpg", UriKind.Relative))));

            CategoryItems.Add(new ItemVM("10+", "My Playmobil", new BitmapImage(new Uri("Bilder_Play/Play_zoo.jpg", UriKind.Relative))));
            CategoryItems.Add(new ItemVM("5+", "My Lego", new BitmapImage(new Uri("Bilder_Lego/Lego_city.jpg", UriKind.Relative))));
        }
    }
}