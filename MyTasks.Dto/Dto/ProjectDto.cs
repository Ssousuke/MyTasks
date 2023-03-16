using MyTasks.Domain.Entities;
using MyTasks.Domain.Entities.Auxiliar.Enum;

namespace MyTasks.Dto.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public ProjectStep ProjectStep { get; set; }
        public ICollection<MyTask> MyTasks { get; set; }
    }
}
