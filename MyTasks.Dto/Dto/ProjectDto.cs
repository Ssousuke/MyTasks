using MyTasks.Domain.Entities.Auxiliar.Enum;
using System.ComponentModel.DataAnnotations;

namespace MyTasks.Dto.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(75, ErrorMessage = "Máximo de caracteres é de 75")]
        public string ProjectName { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Máximo de caracteres é de 150")]
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "O campo é obrigatorio.")]
        public ProjectStep ProjectStep { get; set; }
    }
}
