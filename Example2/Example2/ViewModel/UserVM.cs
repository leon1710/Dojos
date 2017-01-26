using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.ViewModel
{
    public class UserVM:ViewModelBase
    {
        private string name;
        private ObservableCollection<MessageVM> messages;

        public UserVM(string name, ObservableCollection<MessageVM>messages)
        {
            this.name = name;
            this.messages = messages;
        }

        public ObservableCollection<MessageVM> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
