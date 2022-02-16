using DeloitteProject.Domain.Models;

namespace DeloitteProject.UI.MVC.Models
{
    public class HotelViewModel
    {
        public IList<Hotel> Hotels { get; set; }

        public IList<int> Ratings { get; set; }

        public int SelectedRating { get; set; }

        public string Keyword { get; set; }
    }
}
