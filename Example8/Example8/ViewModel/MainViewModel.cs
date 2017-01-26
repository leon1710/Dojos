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

        private loadVM selectedItem;

        #region
        public loadVM SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(); }
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
                Ships = new ObservableCollection<ShipVM>();
                CreateDemoData();
                
            }
        }

        private void CreateDemoData()
        {
            var Load = new ObservableCollection<loadVM>();
            Load.Add(new loadVM("Computer", 5, 10));
            Ships = new ObservableCollection<ShipVM>();
            Ships.Add(new ShipVM("4", Load));
        }

        private void updateGui(string obj)
        {
            //string[] unformated = obj.Split('@');
            string[] unformated = obj.Replace("|", "@").Replace(",","@").Split('@');

            var loads = new ObservableCollection<loadVM>();
            

            for (int i = 1; i < unformated.Length; i = i + 3)
            {
                loads.Add(new loadVM(unformated[i],
                                    int.Parse(unformated[i + 1]),
                                    int.Parse(unformated[i + 2])));
            }
            
            ShipVM newShip = new ShipVM(unformated[0], loads);
            
            App.Current.Dispatcher.Invoke(() =>
            {
                Ships.Add(newShip);
            });
        }
    }
}