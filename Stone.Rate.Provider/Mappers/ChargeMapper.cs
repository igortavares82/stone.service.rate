using Stone.Charging.Messages;
using Stone.Rate.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Rate.ServiceProvider.Mappers
{
    internal class ChargeMapper
    {
        internal static ChargeMessage MapTo(ChargeDto message)
        {
            return new ChargeMessage() { Cpf = message.Cpf, Maturity = message.Maturity, Value = message.Value };
        }

        internal static List<ChargeMessage> MapTo(List<ChargeDto> messages)
        {
            return messages.Select(MapTo).ToList();
        }
    }
}
