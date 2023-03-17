namespace MyTasks.Dto.Dto
{
    public class MyTasksDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsActive { get; set; }
        public Guid ProjectId { get; set; }
    }
}
