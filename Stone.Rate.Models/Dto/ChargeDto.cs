using System;

namespace Stone.Rate.Models.Dto
{
    public class ChargeDto
    {
        public string Cpf { get; set; }
        public DateTime Maturity { get; set; }
        public decimal Value { get; set; }
    }
}
