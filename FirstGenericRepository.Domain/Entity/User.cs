using Shared.Enums;

namespace FirstGenericRepository.Domain.Entity
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public RoleEnum Role { get; set; } = RoleEnum.Aucun;
    }
}
