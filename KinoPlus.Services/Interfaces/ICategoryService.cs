using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface ICategoryService : ICRUDService<Category, CategoryInsertObject, CategoryUpdateObject, CategorySearchObject>
    {
    }
}
