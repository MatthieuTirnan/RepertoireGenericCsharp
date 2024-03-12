namespace FirstGenericRepository.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IActorRepository Actor { get; }

        IBiographyRepository Biography { get; }

        IGenreRepository Genre { get; }

        IMovieRepository Movie { get; }

        IUserRepository User { get; }
        int Save();
    }
}
