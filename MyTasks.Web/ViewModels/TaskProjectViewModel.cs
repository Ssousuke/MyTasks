using MyTasks.Dto.Dto;

namespace MyTasks.Web.ViewModels
{
    public class TaskProjectViewModel
    {
        public ProjectDto Projects { get; set; }
        public ICollection<MyTasksDto> MyTasksDtos { get; set; }
    }
}
