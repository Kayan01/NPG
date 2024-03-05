using System.ComponentModel.DataAnnotations;

namespace NPG.QueryTransaction
{
    public class TransactionQuery
    {
    }
    public class TransactionQueryRequest
    {
        public RequestHeader RequestHeader { get; set; }
        public string TraceId { get; set; }
        public string Channel { get; set; }
    }

    public class RequestHeader
    {
        [Required(ErrorMessage = "MerchantId is required")]
        public string MerchantId { get; set; }

        [Required(ErrorMessage = "TerminalId is required")]
        public string TerminalId { get; set; }

        [Required(ErrorMessage = "TimeStamp is required")]
        public long TimeStamp { get; set; }

        [Required(ErrorMessage = "Signature is required")]
        public string Signature { get; set; }
    }
    public class TransactionQueryResponse
    {
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public string TraceId { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Channel { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public string FeeBearer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long TimeStamp { get; set; }
        public string Signature { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ChannelTransactionId { get; set; }
        public string ProductId { get; set; }
    }
}
