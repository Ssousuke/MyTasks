using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTasks.Domain.Entities;
using MyTasks.Dto.Dto;
using MyTasks.Infra.AppDbContext;
using MyTasks.Infra.Interface;

namespace MyTasks.Infra.Repository
{
    public class MyTasksRepository : IBaseCrudRepository<MyTasksDto>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dBContext;
        private readonly ILogError _log;

        public MyTasksRepository(IMapper mapper, ApplicationDbContext context, ILogError log)
        {
            _dBContext = context;
            _mapper = mapper;
            _log = log;
        }

        public async Task<MyTasksDto> Create(MyTasksDto entity)
        {
            try
            {
                var createMyTasks = _mapper.Map<MyTask>(entity);
                await _dBContext.MyTasks.AddAsync(createMyTasks);
                await _dBContext.SaveChangesAsync();
                return _mapper.Map<MyTasksDto>(createMyTasks);
            }
            catch (Exception ex)
            {
                await _log.Create(ex.Message, ex.StackTrace, ex.Source);
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                MyTask deleteMyTasks = await _dBContext.MyTasks.FindAsync(id);
                _dBContext.MyTasks.Remove(deleteMyTasks);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _log.Create(ex.Message, ex.StackTrace, ex.Source);
                throw;
            }
        }

        public async Task<ICollection<MyTasksDto>> GetAll()
        {
            var getAll = await _dBContext.MyTasks.ToListAsync();
            return _mapper.Map<ICollection<MyTasksDto>>(getAll);
        }

        public async Task<MyTasksDto> GetById(Guid id)
        {
            var getById = await _dBContext.MyTasks.FindAsync(id);
            return _mapper.Map<MyTasksDto>(getById);
        }

        public async Task<MyTasksDto> Update(MyTasksDto entity)
        {
            try
            {
                var updateMyTasks = _mapper.Map<MyTask>(entity);
                _dBContext.MyTasks.Update(updateMyTasks);
                await _dBContext.SaveChangesAsync();
                return _mapper.Map<MyTasksDto>(updateMyTasks);
            }
            catch (Exception ex)
            {
                await _log.Create(ex.Message, ex.StackTrace, ex.Source);
                throw;
            }
        }
    }
}
