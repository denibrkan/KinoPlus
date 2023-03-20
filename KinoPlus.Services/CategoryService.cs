using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class CategoryService : BaseCRUDService<Category, CategoryInsertObject, CategoryUpdateObject, BaseSearchObject>, ICategoryService
    {
        public CategoryService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
