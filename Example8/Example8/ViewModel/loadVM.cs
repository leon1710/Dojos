using System.Collections.ObjectModel;
namespace Example8.ViewModel
{
    public class loadVM
    {
        private string name;
        private int amount;
        private int weight;

        public loadVM(string name, int amount, int weight)
        {
            this.name = name;
            this.amount = amount;
            this.weight = weight;
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}