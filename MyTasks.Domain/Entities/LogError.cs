namespace MyTasks.Domain.Entities
{
    public sealed class LogError
    {
        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public string Source { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
