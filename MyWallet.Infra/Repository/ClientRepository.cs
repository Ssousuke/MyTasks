using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWallet.Domain.Entities;
using MyWallet.Dto.Dto;
using MyWallet.Infra.AppDbContext;
using MyWallet.Infra.Interface;

namespace MyWallet.Infra.Repository
{
    public class ClientRepository : IBaseCrudRepository<ClientDto>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dBContext;
        private readonly ILogError _log;

        public ClientRepository(IMapper mapper, ApplicationDbContext context, ILogError log)
        {
            _dBContext = context;
            _mapper = mapper;
            _log = log;
        }

        public async Task<ClientDto> Create(ClientDto entity)
        {
            try
            {
                var createClient = _mapper.Map<Client>(entity);
                await _dBContext.Clients.AddAsync(createClient);
                await _dBContext.SaveChangesAsync();
                return _mapper.Map<ClientDto>(createClient);
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
                Client? deleteClient = await _dBContext.Clients.FindAsync(id);
                _dBContext.Clients.Remove(deleteClient);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _log.Create(ex.Message, ex.StackTrace, ex.Source);
                throw;
            }
        }

        public async Task<ICollection<ClientDto>> GetAll()
        {
            var getAll = await _dBContext.Clients.ToListAsync();
            return _mapper.Map<ICollection<ClientDto>>(getAll);
        }

        public async Task<ClientDto> GetById(Guid id)
        {
            var getById = await _dBContext.Clients.FindAsync(id);
            return _mapper.Map<ClientDto>(getById);
        }

        public async Task<ClientDto> Update(ClientDto entity)
        {
            try
            {
                var updateClient = _mapper.Map<Client>(entity);
                _dBContext.Clients.Update(updateClient);
                await _dBContext.SaveChangesAsync();
                return _mapper.Map<ClientDto>(updateClient);
            }
            catch (Exception ex)
            {
                await _log.Create(ex.Message, ex.StackTrace, ex.Source);
                throw;
            }
        }
    }
}
