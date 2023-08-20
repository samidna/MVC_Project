using Riode.Models;
using Riode.ViewModels.SliderVMs;

namespace Riode.Services.Interfaces
{
    public interface ISliderService
    {
        Task Create(CreateSliderVM sliderVM);
        Task Update(UpdateSliderVM sliderVM);
        Task Delete(int? id);
        Task<ICollection<Slider>> GetAll();
        Task<Slider> GetById(int? id);
    }
}
