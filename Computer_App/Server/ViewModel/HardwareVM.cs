namespace ServerApp.ViewModel
{
    public class HardwareVM
    {
        private string hardware;
        private int menge;
        

        public HardwareVM(string hw, int total)
        {
            this.hardware = hw;
            this.menge = total;
        }

        public int Menge
        {
            get { return menge; }
            set { menge = value; }
        }


        public string Hardware
        {
            get { return hardware; }
            set { hardware = value; }
        }

    }
}