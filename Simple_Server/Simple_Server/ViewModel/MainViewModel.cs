using System;
using GalaSoft.MvvmLight;
using Simple_Server.Communication;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;

namespace Simple_Server.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        public String CurrentUser { get; set; }
        private ObservableCollection<string> messages;
        private RelayCommand sendClicked;

        public RelayCommand SendClicked
        {
            get { return sendClicked; }
            set { sendClicked = value; }
        }


        public ObservableCollection<string> Messages
        {
            get { return messages; }
            set { messages = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> user;

        public ObservableCollection<string> User
        {
            get { return user; }
            set { user = value;
                RaisePropertyChanged();
            }
        }

        public String Msg { get; set; }

        public MainViewModel()
        {
            if (IsInDesignMode)
            {

            }
            else
            {
                Server server = new Server(guiUpdate);
                User = new ObservableCollection<string>();
                Messages = new ObservableCollection<string>();
                SendClicked = new RelayCommand(ShowMsg);
            }
        }

        private void ShowMsg()
        {
            throw new NotImplementedException();
        }

        private void guiUpdate(string msg)
        {
            if (msg.Contains(":"))
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Messages.Add(msg);
                });
            }
            /*
            //switch thread to GUI thread to write to GUI
            App.Current.Dispatcher.Invoke(() =>
            {
                string name = msg.Split(':')[0];

                //add to list if doesnt exist
                if (!User.Contains(name))
                {
                    User.Add(name);
                }
                //add Message to list
                Messages.Add(msg);
                //update counter
                //RaisePropertyChanged("CntMessages");
            });
            */

        }

        
    }
}