using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System;
using CodingDojo5.Communication;

namespace CodingDojo5.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private Server server;
        //private int cntMessages;
        private bool isConnected;
        private string selectedClient;

        private ObservableCollection<string> users;
        private ObservableCollection<string> messages;

        private RelayCommand stopBtn;
        private RelayCommand startBtn;
        private RelayCommand dropBtn;
        private RelayCommand logBtn;

        #region properties
        public string SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; }
        }
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }
        public RelayCommand LogBtn
        {
            get { return logBtn; }
            set { logBtn = value; }
        }


        public RelayCommand DropBtn
        {
            get { return dropBtn; }
            set { dropBtn = value; }
        }


        public RelayCommand StartBtn
        {
            get { return startBtn; }
            set { startBtn = value; }
        }


        public RelayCommand StopBtn
        {
            get { return stopBtn; }
            set { stopBtn = value; }
        }



        public ObservableCollection<string> Messages
        {
            get { return messages; }
            set { messages = value; }
        }


        public ObservableCollection<string> Users
        {
            get { return users; }
            set { users = value; }
        }


       

        public int CntMessages
        {
            get
            {
                return Messages.Count;
            }

        }
        #endregion
        public MainViewModel()
        {
            Messages = new ObservableCollection<string>();
            Users = new ObservableCollection<string>();

            StartBtn = new RelayCommand(StartServer, ()=> { return !IsConnected; });
            StopBtn = new RelayCommand(() => { server.StopAccepting(); IsConnected = false; },
                                       () => { return IsConnected; });
            DropBtn = new RelayCommand(DropSelectedClient, () => { return SelectedClient != null; });
        }

        private void DropSelectedClient()
        {
            server.DisconnectSpecificClient(SelectedClient);
            Users.Remove(SelectedClient);
        }

        private void StartServer()
        {
            server = new Server("127.0.0.1", 8050, ViewUpdater);
            server.Accepting();
            IsConnected = true;

        }



        //Update View
        public void ViewUpdater(string message)
        {
            //switch thread to GUI thread to write to GUI
            App.Current.Dispatcher.Invoke(() =>
            {
                string name = message.Split(':')[0];

                //add to list if doesnt exist
                if (!Users.Contains(name))
                {
                    Users.Add(name);
                }
                //add Message to list
                Messages.Add(message);
                //update counter
                RaisePropertyChanged("CntMessages");
            });
        }

    }
}