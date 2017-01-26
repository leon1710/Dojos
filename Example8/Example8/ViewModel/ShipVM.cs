using System.Collections.ObjectModel;

namespace Example8.ViewModel
{
    public class ShipVM
    {
        private string shipID;
        private ObservableCollection<loadVM> load;

        public ShipVM(string shipID, ObservableCollection<loadVM> load)
        {
            this.shipID = shipID;
            this.load = load;
        }
        

        public string ShipID
        {
            get { return shipID; }
            set { shipID = value; }
        }

        public ObservableCollection<loadVM> Load
        {
            get
            {
                return load;
            }

            set
            {
                load = value;
            }
        }
    }
}