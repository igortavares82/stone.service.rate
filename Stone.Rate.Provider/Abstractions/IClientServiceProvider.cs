using Stone.Clients.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.ServiceProvider.Abstractions
{
    public interface IClientServiceProvider
    {
        Task<List<ClientMessage>> GetAsync();
    }
}
