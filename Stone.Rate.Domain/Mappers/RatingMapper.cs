using Stone.Rate.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Rate.Domain.Mappers
{
    public class RatingMapper
    {
        public static List<ChargeDto> MapTo(List<ClientDto> clientDtos, Func<string, decimal> converter)
        {
            return clientDtos.Select(it => MapTo(it, converter)).ToList();
        }

        public static ChargeDto MapTo(ClientDto dto, Func<string, decimal> converter)
        {
            ChargeDto chargeMessage = new ChargeDto()
            {
                Cpf = dto.Cpf,
                Maturity = DateTime.Now.AddMonths(1),
                Value = converter(dto.Cpf)
            };

            return chargeMessage;
        }
    }
}
