using KinoPlus.Models;
using KinoPlus.Models.UpsertObjects;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IFITPasosService : ICRUDService<Fitpasos, FITPasosUpsertObject, FITPasosUpsertObject, FITPasosSearchObject>
    {
    }
}