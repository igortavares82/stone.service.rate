using Stone.Charging.Messages;
using Stone.Clients.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Rate.Domain.Mappers
{
    public class RatingMapper
    {
        public static List<ChargeMessage> MapTo(List<ClientMessage> clientMessages, Func<string, decimal> converter)
        {
            return clientMessages.Select(it => MapTo(it, converter)).ToList();
        }

        public static ChargeMessage MapTo(ClientMessage clientMessage, Func<string, decimal> converter)
        {
            ChargeMessage chargeMessage = new ChargeMessage()
            {
                Cpf = clientMessage.Cpf,
                Maturity = DateTime.Now.AddMonths(1),
                Value = converter(clientMessage.Cpf)
            };

            return chargeMessage;
        }
    }
}
