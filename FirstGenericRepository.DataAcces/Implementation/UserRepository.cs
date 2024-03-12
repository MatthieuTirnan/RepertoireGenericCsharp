using FirstGenericRepository.DataAcces.Context;
using FirstGenericRepository.Domain.Entity;
using FirstGenericRepository.Domain.Repository;

namespace FirstGenericRepository.DataAcces.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FirstGenericRepositoryDbContext context) : base(context)
        {

        }

        public User? GetUserByUsername(string username)
        {
            var userByUsername = _context.Users.FirstOrDefault(x => x.Username == username);

            return userByUsername;
        }
    }
}
