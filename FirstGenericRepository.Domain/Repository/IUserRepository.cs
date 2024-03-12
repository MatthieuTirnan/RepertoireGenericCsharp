using FirstGenericRepository.Domain.Entity;

namespace FirstGenericRepository.Domain.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetUserByUsername(string mail);
    }
}
