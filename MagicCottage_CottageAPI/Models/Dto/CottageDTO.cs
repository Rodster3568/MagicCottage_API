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
    }
}
