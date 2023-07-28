using System.ComponentModel.DataAnnotations;

namespace MagicCottage_CottageAPI.Models.Dto
{
    public class CottageDTO
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public int Rate { get; set; }
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
