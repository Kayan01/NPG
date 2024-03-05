using NPG.Models;
using NPG.Models.Request;
using NPG.Models.ResponsePayloads;
using NPG.QueryTransaction;
using NPG.Tokens;

namespace NPG.Contracts
{
    public interface IPaymentService
    {
        Task<Response<InvokePaymentResponse>> InvokePayment(InvokePaymentRequest request);/*
        Task<Response<ProfileMerchantResponse>> ProfileMerchant(ProfileMerchantRequest request);
        Task<Response<TransactionQueryResponse>> TransactionQuery(TransactionQueryRequest request);
        Task<Response<GetTokensResponse>> GetTokens(GetTokensRequest request);
        Task<Response<DeleteTokensResponse>> DeleteTokens(DeleteTokensRequest request);
        Task<Response<GetChargeResponse>> GetCharge(GetChargeRequest request);
        Task<Response<GetAccountDetailsResponse>> GetAccountDetails(GetAccountDetailsRequest request);*/
        Task<Response<InvokePaymentResponse>> DynamicSettlement(DynamicSettlementRequest request);
    }
}
