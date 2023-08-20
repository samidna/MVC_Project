using Riode.DataAccess;
using Riode.ExtentionServices.Interfaces;
using Riode.Models;
using Riode.Services.Interfaces;
using Riode.ViewModels.SliderVMs;

namespace Riode.Services.Implements
{
    public class SliderService : ISliderService
    {
        private readonly IFileService _fileService;
        private readonly RiodeDbContext _context;

        public SliderService(IFileService fileService, RiodeDbContext context)
        {
            _fileService=fileService;
            _context=context;
        }

        public async Task Create(CreateSliderVM sliderVM)
        {
            await _context.Sliders.AddAsync(new Slider
            {
                ImageName=await _fileService.UploadAsync(sliderVM.ImageFile, "image", Path.Combine("assets", "imgs"), 2),
                Title=sliderVM.Title,
                ButtonText=sliderVM.ButtonText,
                Description=sliderVM.Description,
                IsRight=sliderVM.IsRight
            });
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await GetById(id);
            _context.Sliders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Slider>> GetAll()
        {
            return _context.Sliders.ToList();
        }

        public async Task<Slider> GetById(int? id)
        {
            if (id<1 || id==null) throw new NullReferenceException();
            var entity = await _context.Sliders.FindAsync(id);
            if (entity==null) throw new ArgumentException();
            return entity;
        }

        public async Task Update(UpdateSliderVM sliderVM)
        {
            var entity = await GetById(sliderVM.Id);
            entity.Title=sliderVM.Title;
            entity.Description=sliderVM.Description;
            entity.IsRight=sliderVM.IsRight;
            entity.ButtonText=sliderVM.ButtonText;
            await _context.SaveChangesAsync();
        }
    }
}
