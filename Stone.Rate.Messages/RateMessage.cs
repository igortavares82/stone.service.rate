using System.Runtime.Serialization;

namespace Stone.Rate.Messages
{
    [DataContract(Namespace = "http://www.stone.com/rate/rate/type")]
    public class RateMessage
    {
        [DataMember(Name = "cpf")]
        public string Cpf { get; set; }

        [DataMember(Name = "value")]
        public decimal Value { get; set; }
    }
}
