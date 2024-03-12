using FirstGenericRepository.DataAcces.Context;
using FirstGenericRepository.Domain.Repository;

namespace FirstGenericRepository.DataAcces.Implementation
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly FirstGenericRepositoryDbContext _context;

        public UnitOfWork(FirstGenericRepositoryDbContext context)
        {
            _context = context;
            Actor = new ActorRepository(_context);
            Genre = new GenreRepository(_context);
            Movie = new MovieRepository(_context);
            Biography = new BiographyRepository(_context);
            User = new UserRepository(_context);
        }

        public IActorRepository Actor { get; private set; }

        public IBiographyRepository Biography { get; private set; }

        public IGenreRepository Genre { get; private set; }
        public IMovieRepository Movie { get; private set; }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
