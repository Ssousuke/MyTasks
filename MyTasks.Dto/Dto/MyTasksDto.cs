using System.ComponentModel.DataAnnotations;

namespace MyTasks.Dto.Dto
{
    public class MyTasksDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [MaxLength(75, ErrorMessage = "Máximo de caracteres é de 75")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "O campo é obrigatorio.")]
        [MaxLength(75, ErrorMessage = "Máximo de caracteres é de 150")]
        public string TaskDescription { get; set; }

        public bool IsActive { get; set; }

        public Guid ProjectId { get; set; }
    }
}
