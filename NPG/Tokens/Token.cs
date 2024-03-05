namespace NPG.Tokens
{
    public class Token
    {
    }
    public class DeleteTokensRequest
    {
        public RequestHeader RequestHeader { get; set; }
        public string TokenId { get; set; }
        public string TraceID { get; set; }
    }

    public class RequestHeader
    {
        public string MerchantId { get; set; }
        public long TimeStamp { get; set; }
        public string Signature { get; set; }
    }
    // DeleteTokensResponse Class
    public class DeleteTokensResponse
    {
        public string TraceId { get; set; }
        public long TimeStamp { get; set; }
        public string Signature { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

}
