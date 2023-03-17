using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTasks.Domain.Entities;
using MyTasks.Dto.Dto;
using MyTasks.Infra.AppDbContext;
using MyTasks.Infra.Interface;

namespace MyTasks.Infra.Repository
{
    public class ProjectRepository : IBaseCrudRepository<ProjectDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Create(ProjectDto entity)
        {
            var project = _mapper.Map<Project>(entity);
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ProjectDto>> GetAll()
        {
            var projects = await _context.Projects.ToListAsync();
            return _mapper.Map<ICollection<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> GetById(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            return _mapper.Map<ProjectDto>(project);
        }

        public Task<ProjectDto> Update(ProjectDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
