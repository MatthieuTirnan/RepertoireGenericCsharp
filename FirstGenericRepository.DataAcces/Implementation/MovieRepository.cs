using FirstGenericRepository.DataAcces.Context;
using FirstGenericRepository.Domain.Entity;
using FirstGenericRepository.Domain.Repository;

namespace FirstGenericRepository.DataAcces.Implementation
{

    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(FirstGenericRepositoryDbContext context) : base(context)
        {

        }
    }
}
