using FirstGenericRepository.DataAcces.Context;
using FirstGenericRepository.Domain.Entity;
using FirstGenericRepository.Domain.Repository;

namespace FirstGenericRepository.DataAcces.Implementation
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(FirstGenericRepositoryDbContext context) : base(context)
        {

        }
    }
}
