using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Models.UpsertObjects;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class FITPasosService : BaseCRUDService<Fitpasos, FITPasosUpsertObject, FITPasosUpsertObject, FITPasosSearchObject>, IFITPasosService
    {
        private readonly KinoplusContext _context;

        public FITPasosService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override IQueryable<Fitpasos> AddInclude(IQueryable<Fitpasos> query, FITPasosSearchObject? search)
        {
            base.AddInclude(query, search);

            query = query.Include(fitPasos => fitPasos.User);

            return query;
        }

        public override Task BeforeInsert(FITPasosUpsertObject insert, Fitpasos entity)
        {
            base.BeforeInsert(insert, entity);

            entity.DateIssued = DateTime.Now.Date;

            return Task.CompletedTask;
        }
    }
}
