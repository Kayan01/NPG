using NPG.Models.Request;
using System.ComponentModel.DataAnnotations;

namespace NPG.Models
{
   


    //public class RequestHeader
    //{
    //    public string MerchantId { get; set; }
    //    public string TerminalId { get; set; }
    //    public DateTime TimeStamp { get; set; }
    //    public string Signature { get; set; }
    //}

    //public class Customer
    //{
    //    public string Email { get; set; }
    //    public string Name { get; set; }
    //    public string Phone { get; set; }
    //    public string TokenUserId { get; set; }
    //    public string TokenId { get; set; }
    //    public string TokenPin { get; set; }
    //}

    //public class Customization
    //{
    //    public string LogoUrl { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //}

    //public class MetaData
    //{
    //    public string Data1 { get; set; }
    //    public string Data2 { get; set; }
    //    public string Data3 { get; set; }
    //}

    //public class SettlementInstruction
    //{
    //    public int AccountId { get; set; }
    //    public double Amount { get; set; }
    //}

    //public class Settlement
    //{
    //    public string SettlementType { get; set; }
    //    public string SplitCode { get; set; }
    //    public List<SettlementInstruction> SettlementInstruction { get; set; }
    //}

    //public class InvokePaymentRequest
    //{
    //    public RequestHeader RequestHeader { get; set; }
    //    public Customer Customer { get; set; }
    //    public Customization Customization { get; set; }
    //    public MetaData MetaData { get; set; }
    //    public string TraceId { get; set; }
    //    public string ProductId { get; set; }
    //    public string PartnerId { get; set; }
    //    public double Amount { get; set; }
    //    public string Currency { get; set; }
    //    public string FeeBearer { get; set; }
    //    public string ReturnUrl { get; set; }
    //    public Settlement Settlement { get; set; }
    //}
    //public class InvokePaymentRequest
    //{
    //    public RequestHeader RequestHeader { get; set; }
    //    public Customer Customer { get; set; }
    //    public Customization Customization { get; set; }
    //    public MetaData MetaData { get; set; }
    //    public string FeeBearer { get; set; }
    //    public string TraceId { get; set; }
    //    public string ProductId { get; set; }
    //    public double Amount { get; set; }
    //    public string Currency { get; set; }
    //    public string ReturnUrl { get; set; }
    //}

    //public string MerchantId { get; set; }

    //public string TerminalId { get; set; }


    //public long TimeStamp { get; set; }


    //public string Signature { get; set; }

    //public Customer Customer { get; set; }

    //public Customization Customization { get; set; }

    //public MetaData MetaData { get; set; }

    //public ResponseHeader ResponseHeader { get; set; }

    //public Settlement Settlement { get; set; }


    public class Customer
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string TokenUserId { get; set; }
        public string TokenId { get; set; }
        public string TokenPin { get; set; }

    }
    public class DynamicSettlementRequest
    {
        public RequestHeader RequestHeader { get; set; }
        public Customer Customer { get; set; }
        public Customization Customization { get; set; }
        public MetaData MetaData { get; set; }
        public string TraceId { get; set; }
        public string ProductId { get; set; }
        public string PartnerId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string FeeBearer { get; set; }
        public string ReturnUrl { get; set; }
        public Settlement Settlement { get; set; }
    }

    public class Settlement
    {
        public string SettlementType { get; set; }
        public string SplitCode { get; set; }
        public List<SettlementInstruction> SettlementInstruction { get; set; }
    }

    public class SettlementInstruction
    {
        public string AccountId { get; set; }
        public double Amount { get; set; }
    }
    //{
    //    public string Email { get; set; }

    //    public string Phone { get; set; }


    //    public string Name { get; set; }

    //    public string TokenUserId { get; set; }
    //}

    public class Customization
    //{

    //    public string Title { get; set; }


    //    public string Description { get; set; }

    //    public string Logo { get; set; }
    //}
    {
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    

  
}