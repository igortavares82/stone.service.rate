using Stone.Charging.Messages;
using Stone.Clients.Messages;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Concretes;
using Stone.Framework.Result.Enums;
using Stone.Rate.Domain.Abstractions.TaskService;
using Stone.Rate.Domain.Mappers;
using Stone.Rate.Models.Dto;
using Stone.Rate.ServiceProvider.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.Rate.Domain.Concretes.TaskService
{
    public class RatingTaskService : IRatingTaskService
    {
        private IClientServiceProvider ClientServiceProvider { get; }
        private IChargingServiceProvider ChargingServiceProvider { get; }

        public RatingTaskService(IClientServiceProvider clientServiceProvider, IChargingServiceProvider chargingServiceProvider)
        {
            ClientServiceProvider = clientServiceProvider;
            ChargingServiceProvider = chargingServiceProvider;
        }

        public async Task<IDomainResult<List<RatingDto>>> DoRateAsync()
        {
            IDomainResult<List<RatingDto>> result = new DomainResult<List<RatingDto>>();

            List<ClientMessage> clients = await ClientServiceProvider.GetAsync();
            List<ChargeMessage> charges = RatingMapper.MapTo(clients, ConvertCpfToValue);

            bool registerResult = await ChargingServiceProvider.RegisterAsync(null);

            if (registerResult)
            {
                result.Data = null;
                result.Messages.Add("All clientes' charges were rated");
            }
            else
            {
                result.ResultType = DomainResultType.DomainError;
                result.Messages.Add("Something went wrong when performing rating");
            }

            return result;
        }

        private decimal ConvertCpfToValue(string cpf)
        {
            string value = string.Empty;

            value += cpf.Take(2);
            value += cpf.Reverse().Take(2);

            return Convert.ToDecimal(value);
        }
    }
}
