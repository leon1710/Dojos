using GalaSoft.MvvmLight;
using System;

namespace Example2.ViewModel
{
    public class MessageVM: ViewModelBase
    {
        
        private DateTime uhrzeit;
        private string msg;

        public MessageVM(string msg, DateTime uhrzeit)
        {
            //this.name = name;
            this.msg = msg;
            this.uhrzeit = uhrzeit;
        }

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }


        public DateTime Uhrzeit
        {
            get { return uhrzeit; }
            set { uhrzeit = value;}
        }


       

       
    }
}