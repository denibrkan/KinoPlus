using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace KinoPlus.Services
{
    public class UserService : BaseCRUDService<User, UserInsertObject, UserUpdateObject, UserSearchObject>, IUserService
    {
        private readonly KinoplusContext _context;

        public UserService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override IQueryable<User> AddFilter(IQueryable<User> query, UserSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.NameFTS))
            {
                query = query.Where(l => (l.FirstName + " " + l.LastName).Contains(search.NameFTS) ||
                                        (l.LastName + " " + l.FirstName).Contains(search.NameFTS));
            }

            return query;
        }

        public async override Task<User> InsertAsync(UserInsertObject insert)
        {
            var user = await base.InsertAsync(insert);

            //insert user roles after saving user to the db
            foreach (var roleId in insert.RoleIds)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = roleId,
                };
                _context.UserRoles.Add(userRole);
            }

            _context.SaveChanges();

            //return full object with related entities
            return (await GetByIdAsync(user.Id))!;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var query = _context.Users.AsQueryable();

            query = AddInclude(query, null);

            return await query.SingleOrDefaultAsync(x => x.Username == username);
        }


        public override async Task<User?> GetByIdAsync(int id)
        {
            var query = _context.Users.AsQueryable();

            query = AddInclude(query, null);

            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public override IQueryable<User> AddInclude(IQueryable<User> query, UserSearchObject? search)
        {
            query = base.AddInclude(query, search);

            query = query
                .Include(u => u.UserRoles)
                .ThenInclude(u => u.Role)
                .Include(u => u.Tickets)
                .ThenInclude(t => t.Projection.Movie);

            return query;
        }

        public override async Task BeforeInsert(UserInsertObject insert, User entity)
        {
            await base.BeforeInsert(insert, entity);

            //create hashed password
            using var hmac = new HMACSHA512();

            entity.PasswordSalt = Convert.ToBase64String(hmac.Key);
            entity.PasswordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.Default.GetBytes(insert.Password)));
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
