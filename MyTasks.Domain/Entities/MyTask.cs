namespace MyTasks.Domain.Entities
{
    public sealed class MyTask
    {
        public Guid Id { get; private set; }
        public string TaskName { get; private set; }
        public string TaskDescription { get; private set; }
        public bool IsActive { get; private set; }
        public Guid ProjectId { get; private set; }
        public Project Projects { get; private set; }
    }
}
