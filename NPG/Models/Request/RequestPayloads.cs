using System.Text.Json;
namespace NPG.Models.Request
{
    public class InvokePaymentRequest
    {
        public RequestHeader RequestHeader { get; set; }
        public Customer Customer { get; set; }
        public Customization Customization { get; set; }
        public MetaData MetaData { get; set; }
        public string FeeBearer { get; set; }
        public string TraceId { get; set; }
        public string ProductId { get; set; }
        public decimal Amount { get; set; } = 0m;
        public string Currency { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class RequestHeader
    {
        public string TerminalId { get; set; }
        public string MerchantId { get; set; }
        public int TimeStamp { get; set; }
        public string Signature { get; set; }
    }

    public class Customer
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string TokenUserId { get; set; }
        public string TokenId { get; set; }
        public string TokenPin { get; set; }
    }

    public class Customization
    {
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class MetaData
    {
        public int ValueKind { get; set; }
    }
}

