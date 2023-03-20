using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class CategoriesController : BaseCRUDController<Category, CategoryDto, CategoryInsertObject, CategoryUpdateObject, BaseSearchObject>
    {

        public CategoriesController(ICategoryService service, IMapper mapper) : base(service, mapper)
        {
        }

    }
}
