using QuCoonTest.Model;

namespace QuCoonTest.Repository
{
    public class UserActivity: IUserActivity
    {
        private static readonly List<AccountDetails> accountDetails = new List<AccountDetails>
        {
            new AccountDetails {
                Id = 1 ,
                FirstName = "Stanley",
                LastName = "Madueke",
                BVN = "11111111",
                Address = "Test Address",
                Gender = "Male",
                DateOfBirth = DateTime.UtcNow.ToString(),
                CreatedDate = DateTime.Now

            },
        };

        private static readonly List<AccountDetails> CustaccountDetails = new List<AccountDetails>();

        public async Task<string>CreateAccount(AccountDetails acctDetails)
        {
            string response  = null;
            AccountDetails details = new AccountDetails();
            details.Id = acctDetails.Id;
            details.FirstName = acctDetails.FirstName;
            details.LastName = acctDetails.LastName;
            details.BVN = acctDetails.BVN;
            details.Address = acctDetails.Address;
            details.Gender = acctDetails.Gender;
            details.DateOfBirth = acctDetails.DateOfBirth;
            details.CreatedDate = acctDetails.CreatedDate;
            CustaccountDetails.Add(details);

            response = "Account Created Successfully";

            return response;
        }

        public async Task<string> GetCustomerNameById(int id)
        {
            var result = CustaccountDetails.Where(x => x.Id == id).FirstOrDefault();

            return result.FirstName + " " + result.LastName;
        }

        public async Task<string> GetCustomerBalanceById(int id)
        {
            
            var customerBal = CustaccountDetails.Where(x => x.Id == id).FirstOrDefault();

            return customerBal.AccountBalance.ToString();
        }

        public async Task<string> TransferFunds(TransactionDetails transaction)
        {
            string response = null;
            //check customer balance first
            var CustDetails = CustaccountDetails.Where(x => x.Id == transaction.CustomerId).FirstOrDefault();
            
            if(CustDetails.AccountBalance < Convert.ToDecimal(transaction.TransferAmount))
            {
                response = "Insufficiebt Bal";
            }

            //Get recipients Account details and update the account balance
            //debit the bal of source account credit the bal of recipients account

            var recipientsInformation = CustaccountDetails.Where(x => x.Id == transaction.DestinationAccountId).FirstOrDefault();

            if(recipientsInformation != null)
            {
                recipientsInformation.AccountBalance = recipientsInformation.AccountBalance + 
                                                Convert.ToDecimal(transaction.TransferAmount);

                CustDetails.AccountBalance = CustDetails.AccountBalance  - Convert.ToDecimal(transaction.TransferAmount);

                response = "transaction Successful";
            }
            return response;
        }


    }
}
