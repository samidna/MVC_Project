using System.ComponentModel.DataAnnotations;

namespace Riode.Models
{
    public class Slider : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Description { get; set; }
        [Required, MaxLength(60)]
        public string Title { get; set; }
        [Required, MaxLength(40)]
        public string ButtonText { get; set; }
        [Required]
        public bool IsRight { get; set; }
        [Required]
        public string ImageName { get; set; }
    }
}
