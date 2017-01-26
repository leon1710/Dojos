using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ServerApp.Communication;
using System.Collections.ObjectModel;
using System;

namespace ServerApp.ViewModel
{
  
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<HardwareVM> teile;
        private ObservableCollection<string> clients;
        private RelayCommand startBtnClicked;
        private bool isConnected;

        #region
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }


        public RelayCommand StartBtnClicked
        {
            get { return startBtnClicked; }
            set { startBtnClicked = value; }
        }





        public ObservableCollection<string> Clients
        {
            get { return clients; }
            set { clients = value; RaisePropertyChanged(); }
        }


        public ObservableCollection<HardwareVM> Teile
        {
            get { return teile; }
            set { teile = value; RaisePropertyChanged(); }
        }
        #endregion
        public MainViewModel()
        {
             
            if (IsInDesignMode)
            {

            }

            else
            {
                
            }
            Teile = new ObservableCollection<HardwareVM>();
            StartBtnClicked = new RelayCommand(startServer, checkIfStarted);
            Clients = new ObservableCollection<string>();
            CreateClientList();
        }

        private bool checkIfStarted()
        {
            return !IsConnected;
        }

        private void startServer()
        {
            Server server = new Server("127.0.0.1", 10100, updateGui);
            IsConnected = true;
        }

        private void CreateClientList()
        {
            Clients.Add("Motherboard");
            Clients.Add("Prozessor");
            Clients.Add("Speicher");
            Clients.Add("Festplatte");
            Clients.Add("DVD RAM");
        }

        private void updateGui(string obj)
        {
            int total = 0;
            string[] unformated = obj.Split('$');
            string hw = unformated[0];
            total = int.Parse(unformated[1]);

            
            //adds what client sent to Teile List
            App.Current.Dispatcher.Invoke(() =>
            {
                Teile.Add(new HardwareVM(hw, total));

                for(int i =0; i<Clients.Count; i++)
                {
                    if (Clients[i].Equals(hw))
                    {
                        Clients.Remove(Clients[i]);
                        break;
                    }
                }
            });
            

        }
    }
}