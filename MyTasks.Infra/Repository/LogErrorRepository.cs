using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTasks.Domain.Entities;
using MyTasks.Dto.Dto;
using MyTasks.Infra.AppDbContext;
using MyTasks.Infra.Interface;

namespace MyTasks.Infra.Repository
{
    public class LogErrorRepository : ILogErrorRepository
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
            var log = _mapper.Map<LogError>(logError);
            await _dbContext.LogErrors.AddAsync(log);
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