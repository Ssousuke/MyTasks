﻿using MyWallet.Dto.Dto;
using MyWallet.Infra.Interface;

namespace MyWallet.Infra.Repository
{
    public class ProjectRepository : IBaseCrudRepository<ProjectDto>
    {
        public Task<ProjectDto> Create(ProjectDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProjectDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> Update(ProjectDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
