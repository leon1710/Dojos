using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Uebung.ViewModels
{
    public class LoadVM //Felder kapseln Unterschied nur relevant wenn man Berechnungen im Property macht
    {
        private string name;
        private float weight;
        private int amount;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public float Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public LoadVM(string name, float weight, int amount)
        {
            this.name = name;
            this.weight = weight;
            this.amount = amount;
        }


    }
}
