using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class CategoryVM:ViewModelBase
    {
        private BitmapImage image;
        private ObservableCollection<ItemVM> itemsInCategory;
        private string description;

        public CategoryVM(string description, BitmapImage image, ObservableCollection<ItemVM> itemsInCategory)
        {
            this.description = description;
            this.image = image;
            this.itemsInCategory = itemsInCategory;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        

        public ObservableCollection<ItemVM> ItemsInCategory
        {
            get { return itemsInCategory; }
            set { itemsInCategory = value; }
        }


        public BitmapImage Image
        {
            get { return image; }
            set { image = value; }
        }

    }
}
