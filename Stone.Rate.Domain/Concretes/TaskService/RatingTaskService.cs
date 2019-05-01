using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Concretes;
using Stone.Framework.Result.Enums;
using Stone.Rate.Domain.Abstractions.TaskService;
using Stone.Rate.Domain.Mappers;
using Stone.Rate.Models.Dto;
using Stone.Rate.ServiceProvider.Abstractions;
using System;
using System.Collections.Generic;
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

        public async Task<IDomainResult<List<ChargeDto>>> DoRateAsync()
        {
            IDomainResult<List<ChargeDto>> result = new DomainResult<List<ChargeDto>>();

            List<ClientDto> clients = await ClientServiceProvider.GetAsync();
            result.Data = RatingMapper.MapTo(clients, ConvertCpfToValue);

            bool registerResult = await ChargingServiceProvider.RegisterAsync(result.Data);

            if (registerResult)
                result.Messages.Add("All clients' charges were rated");
            else
            {
                result.Data.Clear();
                result.ResultType = DomainResultType.DomainError;
                result.Messages.Add("Something went wrong when performing rating");
            }

            return result;
        }

        private decimal ConvertCpfToValue(string cpf)
        {
            string value = string.Empty;

            value += cpf.Substring(0,2);
            value += cpf.Substring(cpf.Length - 2, 2);

            return Convert.ToDecimal(value);
        }
    }
}
