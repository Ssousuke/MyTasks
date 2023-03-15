using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTasks.Dto.Dto;
using MyTasks.Infra.AppDbContext;
using MyTasks.Infra.Interface;

namespace MyTasks.Infra.Repository
{
    public class LogErrorRepository : ILogError
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LogErrorRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<LogErrorDto> Create(string message, string stackTrace, string source)
        {
            var logError = new LogErrorDto()
            {
                Message = message,
                Source = source,
                CreatedAt = DateTime.UtcNow
            };
            await _dbContext.AddAsync(logError);
            await _dbContext.SaveChangesAsync();
            return logError;
        }

        public async Task<ICollection<LogErrorDto>> GetAll()
        {
            var getAll = await _dbContext.LogErrors.ToListAsync();
            return _mapper.Map<ICollection<LogErrorDto>>(getAll);
        }
    }
}