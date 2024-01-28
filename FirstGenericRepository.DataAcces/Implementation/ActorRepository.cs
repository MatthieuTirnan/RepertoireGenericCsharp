using FirstGenericRepository.DataAcces.Context;
using FirstGenericRepository.Domain.Entity;
using FirstGenericRepository.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace FirstGenericRepository.DataAcces.Implementation
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(FirstGenericRepositoryDbContext context) : base(context)
        {

        }

        public IEnumerable<Actor> GetActorsWithMovie()
        {
            var actorsWithMovies = _context.Actors.Include(u => u.Movies).ToList();
            return actorsWithMovies;
        }
    }
}
