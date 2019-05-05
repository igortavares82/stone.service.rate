using NSubstitute;
using NSubstitute.Core;
using Stone.Framework.Utils.Cpf;
using Stone.Rate.Models.Dto;
using Stone.Rate.ServiceProvider.Abstractions;
using System;
using System.Collections.Generic;

namespace Stone.Rate.UnitTest.Helpers
{
    internal class ClientServiceProviderHelper
    {
        internal static IClientServiceProvider GetMock()
        {
            IClientServiceProvider provider = Substitute.For<IClientServiceProvider>();
            provider.GetAsync().Returns(GetAsyncReturn);

            return provider;
        }

        private static List<ClientDto> GetAsyncReturn(CallInfo info)
        {
            List<ClientDto> clients = new List<ClientDto>()
            {
                new ClientDto() { Cpf = CpfGenerator.Generate(), Name = Guid.NewGuid().ToString(), State = "XX" },
                new ClientDto() { Cpf = CpfGenerator.Generate(), Name = Guid.NewGuid().ToString(), State = "XX" },
                new ClientDto() { Cpf = CpfGenerator.Generate(), Name = Guid.NewGuid().ToString(), State = "XX" }
            };

            return clients;
        }
    }
}
