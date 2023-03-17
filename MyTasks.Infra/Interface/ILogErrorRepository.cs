using MyTasks.Dto.Dto;

namespace MyTasks.Infra.Interface
{
    public interface ILogErrorRepository
    {
        Task<LogErrorDto> Create(string message, string stackTrace, string source);
        Task<ICollection<LogErrorDto>> GetAll();
    }
}
