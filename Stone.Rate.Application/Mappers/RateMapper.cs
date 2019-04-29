using Stone.Charging.Messages;
using Stone.Rate.Messages;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Rate.Application.Mappers
{
    public class RateMapper
    {
        public static RateMessage MapTo(ChargeMessage message)
        {
            RateMessage rateMessage = new RateMessage()
            {
                Cpf = message.Cpf,
                Value = message.Value.Value
            };

            return rateMessage;
        }

        public static List<RateMessage> MapTo(List<ChargeMessage> messages)
        {
            return messages.Select(MapTo).ToList();
        }
    }
}
