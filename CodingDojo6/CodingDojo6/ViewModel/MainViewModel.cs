using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ItemVM> legoitems;
        private ObservableCollection<ItemVM> playitems;
        private ObservableCollection<CategoryVM> categoryItems;
        private ObservableCollection<ItemVM> warenkorb;

        private RelayCommand<ItemVM> buyBtn;
        private CategoryVM selectedCategory;

        public MainViewModel()
        {
            Warenkorb = new ObservableCollection<ItemVM>();
            Legoitems = new ObservableCollection<ItemVM>();
            Playitems = new ObservableCollection<ItemVM>();
            CategoryItems = new ObservableCollection<CategoryVM>();

            BuyBtn = new RelayCommand<ItemVM>(AddToWarenkorb, (item)=> { return true; } );
            FillLists();
        }

        private void AddToWarenkorb(ItemVM obj)
        {
            Warenkorb.Add(obj);
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

        public CategoryVM SelectedCategory
        {
            get
            {
                return selectedCategory;
            }

            set
            {
                selectedCategory = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<CategoryVM> CategoryItems
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

        public ObservableCollection<ItemVM> Warenkorb
        {
            get
            {
                return warenkorb;
            }

            set
            {
                warenkorb = value;
            }
        }

        public RelayCommand<ItemVM> BuyBtn
        {
            get
            {
                return buyBtn;
            }

            set
            {
                buyBtn = value;
            }
        }
        #endregion

        public void FillLists()
        {
            Legoitems.Add(new ItemVM("5+", "Ritterburg", new BitmapImage(new Uri("Bilder_Lego/Lego_burg.jpg", UriKind.Relative))));
            Legoitems.Add(new ItemVM("12+", "City", new BitmapImage(new Uri("Bilder_Lego/Lego_city.jpg", UriKind.Relative))));
            Legoitems.Add(new ItemVM("10+", "Dr. Who", new BitmapImage(new Uri("Bilder_Lego/Lego_DrWho.jpg", UriKind.Relative))));
            Legoitems.Add(new ItemVM("8+", "Harry Potter", new BitmapImage(new Uri("Bilder_Lego/Lego_harrypotter.jpg", UriKind.Relative))));
            Legoitems.Add(new ItemVM("5+", "Superheroes", new BitmapImage(new Uri("Bilder_Lego/Lego_superheroes.jpg", UriKind.Relative))));

            Playitems.Add(new ItemVM("5+", "Piraten", new BitmapImage(new Uri("Bilder_Play/Play_piratenschatz.jpg", UriKind.Relative))));
            Playitems.Add(new ItemVM("3+", "Schulbus", new BitmapImage(new Uri("Bilder_Play/Play_schulbus.jpg", UriKind.Relative))));
            Playitems.Add(new ItemVM("8+", "Schwimmbad", new BitmapImage(new Uri("Bilder_Play/Play_schwimmen.jpg", UriKind.Relative))));
            Playitems.Add(new ItemVM("5+", "Spielplatz", new BitmapImage(new Uri("Bilder_Play/Play_spielplatz.jpg", UriKind.Relative))));
            Playitems.Add(new ItemVM("10+", "Zoo", new BitmapImage(new Uri("Bilder_Play/Play_zoo.jpg", UriKind.Relative))));

            
            CategoryItems.Add(new CategoryVM("My Lego", new BitmapImage(new Uri("Bilder_Lego/Lego_city.jpg", UriKind.Relative)), Legoitems));
            CategoryItems.Add(new CategoryVM("My Playmobil", new BitmapImage(new Uri("Bilder_Play/Play_zoo.jpg", UriKind.Relative)), Playitems));
        }
    }
}