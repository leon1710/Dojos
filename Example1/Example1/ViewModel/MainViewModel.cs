using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Example1.Communication;
using System.Collections.ObjectModel;

namespace Example1.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        private bool isClient = false;

        public bool IsClient
        {
            get { return isClient = false; }
            set { isClient  = value; }
        }

        //public bool IsClientMode { get; set; }
        public bool IsEnabled { get; set; }
        public RelayCommand ListenClicked { get; set; }
        public RelayCommand ConnectClicked { get; set; }
        public bool IsConnected { get; private set; }
        public ObservableCollection<string> DataLog { get; set; }
        private Client client;

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                
            }
            else
            {
                ConnectClicked = new RelayCommand(ConnectAsClient);
                //IsToggled = true;
                ListenClicked = new RelayCommand(ConnectAsServer);
                
            }

        }

        private void ConnectAsServer()
        {
            Server server = new Server(GuiUpdater);
            //server.StartAccepting();
            IsConnected = true;
            IsClient = false;
        }

        private void GuiUpdater(string obj)
        {
            
        }

        //connects as server
        private void ConnectAsClient()
        {
            client = new Client(ShowDataLog);
            IsClient = true;
        }

        private void ShowDataLog(string obj)
        {
            App.Current.Dispatcher.Invoke(() => {
                DataLog.Add(obj);
            });
        }

        //disables Toggle Buttons
        private bool CheckIfIsEnabled()
        {
            return !IsEnabled;
        }
    }
}