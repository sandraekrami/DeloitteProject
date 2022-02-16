using System.ComponentModel.DataAnnotations;

namespace DeloitteProject.Domain.Models
{
    public class Hotel
    {
        // A unique identifier for hotel
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
    }
}
