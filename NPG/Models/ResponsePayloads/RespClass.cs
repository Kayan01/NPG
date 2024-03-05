namespace NPG.Models.ResponsePayloads
{
    public class RespClass
    {
    }
    public class AuthResponse
    {
        public string token { get; set; }
        public string key { get; set; }
        public string status { get; set; }
    }


    public class ResponseHeader
    {
        public string signature { get; set; }
        public long timeStamp { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
    }

    public class MetaDataResponse
    {
        public int valueKind { get; set; }
    }

    public class InvokePaymentResponse
    {
        
         public ResponseHeader ResponseHeader { get; set; }
        public string transactionId { get; set; }
        public string traceId { get; set; }
        public string payPageLink { get; set; }
       // public MetaData metaData { get; set; }
    }
}


    public class GetAccountDetailsResponse
        {
            public string TraceId { get; set; }
            public long TimeStamp { get; set; }
            public string Signature { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public List<AccountDetail> AccountDetails { get; set; }
        }

        public class AccountDetail
        {
            public string BankCode { get; set; }
            public string AccountNumber { get; set; }
            public int AccountId { get; set; }
        }
        public class GetChargeResponse
        {
            public string TraceId { get; set; }
            public long TimeStamp { get; set; }
            public string Signature { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public decimal Vat { get; set; }
            public decimal Charge { get; set; }
        }

        public class ProfileMerchantResponse
        {
            public string TraceId { get; set; }

            public long TimeStamp { get; set; }

            public string Signature { get; set; }

            public string ResponseCode { get; set; }

            public string ResponseMessage { get; set; }
        }


        public class GetTokensResponse
        {
            public string TraceId { get; set; }
            public long TimeStamp { get; set; }
            public string Signature { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public List<TokenInfo> Tokens { get; set; }
        }

        public class TokenInfo
        {
            public string TokenId { get; set; }
            public string Pan { get; set; }
            public string TokenUserId { get; set; }
            public DateTime RegisteredDate { get; set; }
        }


    