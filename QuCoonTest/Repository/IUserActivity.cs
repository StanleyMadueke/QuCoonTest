using QuCoonTest.Model;

namespace QuCoonTest.Repository
{
    public interface IUserActivity
    {
        Task<string> CreateAccount(AccountDetails accountDetails);
        Task<string> GetCustomerNameById(int id);
        Task<string> GetCustomerBalanceById(int id);
        Task<string> TransferFunds(TransactionDetails transactionDetails);
        /*Task<string> GetTransactionStatus(int transId);
        Task<TransactionDetails> GetTransactionHistory(TransactionQueryRequest request);*/
    }
}
