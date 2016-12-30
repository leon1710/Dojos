using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace CodingDojo6.ViewModel
{
    public class ItemVM:ViewModelBase
    {
        private string ageRec;
        private string description;
        private BitmapImage image;
        private ObservableCollection<ItemVM> items;

        #region props
        public BitmapImage Image
        {
            get { return image; }
            set { image = value; }
        }



        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public string AgeRec
        {
            get { return ageRec; }
            set { ageRec = value; }
        }

        public ObservableCollection<ItemVM> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }
        #endregion

        public ItemVM(string ageRec, string description, BitmapImage image)
        {
            this.ageRec = ageRec;
            this.description = description;
            this.image = image;
            //this.items = items;
        }

   

    }
}
