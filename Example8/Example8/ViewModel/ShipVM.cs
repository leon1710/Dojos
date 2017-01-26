using System.Collections.ObjectModel;

namespace Example8.ViewModel
{
    public class ShipVM
    {
        private int shipID;
        private ObservableCollection<loadVM> load;
        private int weightSum;

        public int WeightSum
        {
            get { return weightSum; }
            set { weightSum = value; }
        }


        public ShipVM(int shipID, ObservableCollection<loadVM> load, int weightSum)
        {
            this.shipID = shipID;
            this.load = load;
            this.weightSum = weightSum;
        }
        

        public int ShipID
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