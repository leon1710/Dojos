using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

using System;
using ClientApp.Communication;

namespace ClientApp.ViewModel
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
        private ObservableCollection<string> hardware;
        private ObservableCollection<int> menge;
        private string selectedHW;
        private int selectedTotal;
        private bool checkIfConnected;
        

        private RelayCommand connectBtnClicked;
        private Client client;
        private string msg;

        private RelayCommand sendBtnClicked;
        #region
      


        public bool CheckIfConncted
        {
            get { return checkIfConnected; }
            set { checkIfConnected = value; }
        }
        public int SelectedTotal
        {
            get { return selectedTotal; }
            set { selectedTotal = value; RaisePropertyChanged(); }
        }


        public string SelectedHW
        {
            get { return selectedHW; }
            set { selectedHW = value; RaisePropertyChanged(); }
        }
        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        public RelayCommand SendBtnClicked
        {
            get { return sendBtnClicked; }
            set { sendBtnClicked = value; }
        }



        
        public RelayCommand ConnectBtnClicked
        {
            get { return connectBtnClicked; }
            set { connectBtnClicked = value; }
        }


        public ObservableCollection<int> Menge
        {
            get { return menge; }
            set { menge = value; }
        }


        public ObservableCollection<string> Hardware
        {
            get { return hardware; }
            set { hardware = value; }
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
            Msg = "";
            SendBtnClicked = new RelayCommand(sendData, checkIfItemSelected);
            ConnectBtnClicked = new RelayCommand(connectToServer, checkConnection);
            Hardware = new ObservableCollection<string>();
            Menge = new ObservableCollection<int>();
            CreateEntries();

            
        }

        private bool checkConnection()
        {
            return !CheckIfConncted;
        }

        private bool checkIfItemSelected()
        {
            if(SelectedTotal!=0 && !(string.IsNullOrEmpty(SelectedHW)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void sendData()
        {
            Msg += SelectedHW;
            Msg += "$";
            Msg += SelectedTotal;
            //convert items to string

            //send data to server
            client.Send(Msg);
            SelectedHW = "";
            SelectedTotal = 0;
            Msg = "";
        }

        private void connectToServer()
        {
            client = new Client("127.0.0.1",10100, update);
            CheckIfConncted = true;
        }

        private void update(string obj)
        {
            throw new NotImplementedException();
        }

        private void CreateEntries()
        {
            Hardware.Add("Motherboard");
            Hardware.Add("Prozessor");
            Hardware.Add("Speicher");
            Hardware.Add("Festplatte");
            Hardware.Add("DVD RAM");

            for(int i = 1; i<=10; i++)
            {
                Menge.Add(i);
            }
            
        }
    }
}