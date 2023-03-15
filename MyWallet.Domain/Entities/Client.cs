namespace MyWallet.Domain.Entities
{
    public sealed class Client
    {
        public Guid Id { get; private set; }
        public string ClientName { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<Project> Projects { get; private set; }
    }
}
