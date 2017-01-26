using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Truck_LV_Uebung.Communication;
using System;

namespace Truck_LV_Uebung.ViewModel
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
        public ObservableCollection<TruckVM> Trucks { get; set; }
        private TruckVM currentSelectedTruck;

        public TruckVM CurrentSelectedTruck
        {
            get { return currentSelectedTruck; }
            set { currentSelectedTruck = value;
                RaisePropertyChanged();
            }
        }


        public MainViewModel()
        {
            //if is in Design wird nur ausgeführt wenn man im xaml arbeitet
            if (IsInDesignMode)
            {

            }
            else //erst bei runtime ausführen - nicht wenn xaml bearbeitet
            {
                Server server = new Server(GuiUpdate);
            }

            CreateDemoData();
        }

        //wird von ClientHandler ausgeführt wenn etwas empfangen wird -> Delegate
        private void GuiUpdate(string obj)
        {
            //obj = "S1-A54AB@Graz@Ladung1@10@4@Ladung2@100@400";
            //ein Array wird empfangen und Split zeigt verschiedene IDs : Name, Source ...
            String[] unformated = obj.Split('@');

            var loads = new ObservableCollection<LoadVM>();

            for(int i=2; i< unformated.Length; i= i+3)
            {
                loads.Add(new LoadVM(unformated[i],
                                    int.Parse(unformated[i + 1]), 
                                    int.Parse(unformated[i + 2])));
            }
            //Dem Truck werden Index von Array übergeben
            TruckVM newTruck = new TruckVM(unformated[0], unformated[1], loads);


            //braucht man wenn mehrere Threads zugreifen können
            App.Current.Dispatcher.Invoke(() =>
            {
                Trucks.Add(newTruck);
            });
            
        }

        public void CreateDemoData()
        {
            Trucks = new ObservableCollection<TruckVM>();

            Trucks.Add(new TruckVM("SL-45AB", "Salzburg", 
                new ObservableCollection<LoadVM>()
                {
                    new LoadVM("Ladung A", 10, 10),
                    new LoadVM("Ladung B", 130, 50),
                    new LoadVM("Ladung C", 25, 100)
                }));

            Trucks.Add(new TruckVM("W-7722", "Wien",
                new ObservableCollection<LoadVM>()
                {
                    new LoadVM("Ladung D", 200, 100),
                    new LoadVM("Ladung E", 130, 500),
                    new LoadVM("Ladung F", 25, 1000)
                }));
        }
    }
}