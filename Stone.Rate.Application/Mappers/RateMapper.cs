using Stone.Charging.Messages;
using Stone.Rate.Messages;
using Stone.Rate.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Rate.Application.Mappers
{
    public class RateMapper
    {
        public static RateMessage MapTo(ChargeDto message)
        {
            RateMessage rateMessage = new RateMessage()
            {
                Cpf = message.Cpf,
                Value = message.Value
            };

            return rateMessage;
        }

        public static List<RateMessage> MapTo(List<ChargeDto> messages)
        {
            return messages.Select(MapTo).ToList();
        }
    }
}
