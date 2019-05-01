using Stone.Clients.Messages;
using Stone.Rate.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.ServiceProvider.Abstractions
{
    public interface IClientServiceProvider
    {
        Task<List<ClientDto>> GetAsync();
    }
}
