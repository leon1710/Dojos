using GalaSoft.MvvmLight;
using System;

namespace Example1.ViewModel
{
    public class DataVM : ViewModelBase
    {
        public DateTime timestamp = DateTime.Now;

        private bool isToggled;

        public bool IsToggled
        {
            get { return isToggled; }
            set { isToggled = value; }
        }

    }
}