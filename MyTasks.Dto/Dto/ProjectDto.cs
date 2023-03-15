namespace MyTasks.Dto.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public bool IsActive { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }
}
