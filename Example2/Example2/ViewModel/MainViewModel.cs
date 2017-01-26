using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System;
using Example2.Communication;
using System.Net.Sockets;

namespace Example2.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand startBtn;
        private ObservableCollection<UserVM> user;
        private ObservableCollection<string> chatMessages;
        private UserVM selectedUser;
        private bool isReceiving;




        #region
        public bool IsReceiving
        {
            get { return isReceiving; }
            set { isReceiving = value; }
        }
        public UserVM SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<string> ChatMessages
        {
            get { return chatMessages; }
            set { chatMessages = value; RaisePropertyChanged(); }
        }

        
        public ObservableCollection<UserVM> User
        {
            get { return user; }
            set { user = value; RaisePropertyChanged(); }
        }
        
        public RelayCommand StartBtn
        {
            get { return startBtn; }
            set { startBtn = value; }
        }
        #endregion
        public MainViewModel()
        {
            if (IsInDesignMode)
            {

            }
            else
            {
                User = new ObservableCollection<UserVM>();
                ChatMessages = new ObservableCollection<string>();
                startBtn = new RelayCommand(startServer, CheckIfClicked);
                createDemoData();
            }
        }

        private bool CheckIfClicked()
        {
            return !IsReceiving;
        }

        private void startServer()
        {
            Server server = new Server(informGUI);
        }

        public void createDemoData()
        {
            User.Add(new UserVM("Maxl",
                new ObservableCollection<MessageVM>()
                {
                    new MessageVM("Hallo wie gehts?", DateTime.Now),
                    new MessageVM("Blubb", DateTime.Now)

                }));
            //User[0].Messages.Add(new MessageVM("Hallo wie gehts euch?", DateTime.Now));

        }

        private void informGUI(string obj, Socket socket)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                
                string[] unformatted = obj.Split(' ');

                var messages = new ObservableCollection<MessageVM>();
                var name = unformatted[0];
                string msg = name + ": ";

                while (!msg.Contains("\r\n"))
                {
                    for (int i = 1; i < unformatted.Length; i++)
                    {
                        msg += unformatted[i]+" ";
                    }
                }
                
                messages.Add(new MessageVM(msg, DateTime.Now));
                ChatMessages.Add(msg);

                if (!ChatMessages.Contains(name))
                {
                    User.Add(new UserVM(name, messages));
                }
                
                
                
              

                //}
                
                
            });

        }
    }
}