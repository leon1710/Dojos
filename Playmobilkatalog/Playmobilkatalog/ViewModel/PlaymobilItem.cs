using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Playmobilkatalog.ViewModel
{
    public class PlaymobilItem
    {
        //wichtig dass Klasse public ist
        public PlaymobilItem(string description, int id, string ageRecommendation, int noOfParts, BitmapImage image, int x, int y)
        {
            Description = description;
            Id = id;
            AgeRecommendation = ageRecommendation;
            NoOfParts = noOfParts;
            Image = image;
            PosX = x;
            PosY = y;
        }

        public string Description { get; set; }
        public int Id { get; set; }
        public string AgeRecommendation { get; set; }

        //alles public weil wirs verändern wollen in der GUI
        public int NoOfParts { get; set; }
        public BitmapImage Image { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }


    }
}
