using CodingDojo5_Client.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System;
using System.Net;
using System.Windows.Input;

namespace CodingDojo5_Client.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private Client client;
        private bool isConnected;
        private string chatName;
        private string msg;
        private ObservableCollection<string> chatMessages;
        private RelayCommand connectBtn;
        private RelayCommand sendBtn;

        #region Properties
        public string ChatName
        {
            get { return chatName; }
            set { chatName = value; }
        }

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        public ObservableCollection<string> ChatMessages
        {
            get
            {
                return chatMessages;
            }

            set
            {
                chatMessages = value;
            }
        }

        public RelayCommand ConnectBtn
        {
            get
            {
                return connectBtn;
            }

            set
            {
                connectBtn = value;
            }
        }

        public RelayCommand SendBtn
        {
            get
            {
                return sendBtn;
            }

            set
            {
                sendBtn = value;
            }
        }

        public bool IsConnected
        {
            get
            {
                return isConnected;
            }

            set
            {
                isConnected = value;
            }
        }
        #endregion
        public MainViewModel()
        {
            ChatMessages = new ObservableCollection<string>();
            Msg = "";

            //ConnectBtn = new RelayCommand(ConnectToServer, ()=> { return !isConnected; });
            ConnectBtn = new RelayCommand(ConnectToServer, CheckIfConnected);
            SendBtn = new RelayCommand(Send, CheckMsgLength);
        }

        private bool CheckIfConnected()
        {
            return !IsConnected;
        }

        //Checks if Msg Length > 1
        private bool CheckMsgLength()
        {
            return IsConnected && Msg.Length > 0;
            
        }

        //Adds Msg to Messages and sends to server
        private void Send()
        {
            client.Send(ChatName + ": " + Msg);
            ChatMessages.Add(ChatName+ ": "+Msg); 
        }

        private void ConnectToServer()
        {
            client = new Client("127.0.0.1", 8050, new Action<string>(ShowNewMessages), Disconnect);
            IsConnected = true;
        }

        private void Disconnect()
        {
            IsConnected = false;
            CommandManager.InvalidateRequerySuggested();
        }

        private void ShowNewMessages(string obj)
        {
            App.Current.Dispatcher.Invoke(() =>{ ChatMessages.Add(obj) ;});
        }
    }
}