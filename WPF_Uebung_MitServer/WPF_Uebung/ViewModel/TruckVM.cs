using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Uebung.ViewModels
{
    public class TruckVM
    {
        private string source;
        private int duration;
        private ObservableCollection<LoadVM> truckload;

        public string Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
            }
        }

        public ObservableCollection<LoadVM> Truckload
        {
            get
            {
                return truckload;
            }

            set
            {
                truckload = value;
            }
        }

        public TruckVM(string source, int duration, ObservableCollection<LoadVM> truckload)
        {
            this.Source = source;
            this.Duration = duration;
            this.Truckload = truckload;
        }

        public override string ToString()
        {
            return source + " " + duration;
        }
    }
}
