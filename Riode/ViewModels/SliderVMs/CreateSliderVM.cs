using System.ComponentModel.DataAnnotations;

namespace Riode.ViewModels.SliderVMs
{
    public record class CreateSliderVM
    {
        [Required]
        public string Description { get; set; }
        [Required, MaxLength(60)]
        public string Title { get; set; }
        [Required, MaxLength(40)]
        public string ButtonText { get; set; }
        [Required]
        public bool IsRight { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
