using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    public class CategoriesController : BaseCRUDController<Category, CategoryDto, CategoryInsertObject, CategoryUpdateObject, CategorySearchObject>
    {

        public CategoriesController(ICategoryService service, IMapper mapper) : base(service, mapper)
        {
        }

        [AllowAnonymous]
        public override Task<ActionResult<List<CategoryDto>>> Get([FromQuery] CategorySearchObject search)
        {
            return base.Get(search);
        }

    }
}
