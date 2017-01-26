using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Truck_LV_Uebung.ViewModel
{
    public class TruckVM : ViewModelBase
    {
        public String Id { get; set; }

        public String Source { get; set; }

        public ObservableCollection<LoadVM> Loads {get;set;}

        private int totalWeight;

        //nur get weil es eine Berechnung zurück gibt
        public int TotalWeight
        {
            get {
                int temp = 0;
                foreach(var item in Loads)
                {
                    temp += item.Weight * item.Amount;
                }
                return temp;
            }
            
        }


        public TruckVM(string id, string source, ObservableCollection<LoadVM> loads)
        {
            Id = id;
            Source = source;
            Loads = loads;
        }
    }
}
