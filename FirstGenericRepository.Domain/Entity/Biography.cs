namespace FirstGenericRepository.Domain.Entity
{
    public class Biography
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public Actor? Actor { get; set; }
        public int ActorId { get; set; }
    }
}
