using Stone.Clients.Messages;
using Stone.Rate.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Rate.ServiceProvider.Mappers
{
    internal class ClientMapper
    {
        internal static ClientDto MapTo(ClientMessage message)
        {
            return new ClientDto() { Cpf = message.Cpf, Name = message.Name, State = message.State };
        }

        internal static List<ClientDto> MapTo(List<ClientMessage> messages) 
        {
            return messages.Select(MapTo).ToList();
        }
    }
}
