using Stone.Framework.Result.Abstractions;
using Stone.Rate.Domain.Abstractions.TaskService;
using Stone.Rate.Models.Dto;
using Stone.Rate.UnitTest.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Rate.UnitTest
{
    public class RateTaskServiceTest
    {
        [Fact]
        public async Task Rate_DoRating_ReturnsTrue()
        {
            // Arrange
            IRateTaskService taskService = RateTaskServiceHelper.GetMock();

            // Act
            IDomainResult<List<ChargeDto>> result = await taskService.DoRateAsync();

            // Assert
            Assert.Equal(result.Data[0].Value, ConvertCpfToValue(result.Data[0].Cpf));
            Assert.Equal(result.Data[1].Value, ConvertCpfToValue(result.Data[1].Cpf));
            Assert.Equal(result.Data[2].Value, ConvertCpfToValue(result.Data[2].Cpf));
        }

        private decimal ConvertCpfToValue(string cpf)
        {
            return Convert.ToDecimal(cpf.Substring(0,2) + cpf.Substring(cpf.Length - 2, 2));
        }
    }
}
