using Example8.Communication;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace Example8.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ShipVM> ships;
        //private int weightSum;

        private ShipVM selectedItem;

        #region
        
        public ShipVM SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged();  }
        }


        public ObservableCollection<ShipVM> Ships
        {
            get { return ships; }
            set { ships = value; }
        }
        #endregion
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                
            }
            else
            {
                Server server = new Server(updateGui);
                 
            }

            CreateDemoData();
        }

        private void CreateDemoData()
        {
            Ships = new ObservableCollection<ShipVM>();
            Ships.Add(new ShipVM(10,
                        new ObservableCollection<loadVM>() 
                        {
                            new loadVM("Computer", 5 ,10),
                            new loadVM("Playstation",10 ,100),
                            new loadVM("Laptops", 20 , 500)
                        }, 10 + 100 + 500));
            Ships.Add(new ShipVM(9,
                        new ObservableCollection<loadVM>()
                        {
                            new loadVM("Computer", 5 ,10),
                            new loadVM("Playstation",10 ,100),
                            new loadVM("Laptops", 20 , 500)
                        }, 10+100+500));
        }

        private void updateGui(string obj)
        {
            /*
            //"4@recorder,20000,25000|DVDPlayer,10000,20000|PC,50000,200000";
            string[] getid = obj.Split('@');
            int id = int.Parse(getid[0]);

            ObservableCollection<loadVM> load = new ObservableCollection<loadVM>();

            string[] getloads = obj.Split('|');
            foreach(var cargo in getloads)
            {
                string[] cargodata = obj.Split(',');
                load.Add(new loadVM(cargodata[0], int.Parse(cargodata[1]), int.Parse(cargodata[2])));
            }

            Ships.Add(new ShipVM(id, load));
            */
            
            string[] unformated = obj.Replace("|", "@").Replace(",","@").Split('@');
            int id = int.Parse(unformated[0]);
            var loads = new ObservableCollection<loadVM>();
            int weightSum=0;

            for (int i = 1; i < unformated.Length; i = i + 3)
            {
                loads.Add(new loadVM(unformated[i],
                                    int.Parse(unformated[i + 1]),
                                    int.Parse(unformated[i + 2])));
                weightSum += int.Parse(unformated[i + 2]);
            }
            
            ShipVM newShip = new ShipVM(id, loads, weightSum);
            
            App.Current.Dispatcher.Invoke(() =>
            {
                Ships.Add(newShip);
            });

    
        }
    }
}