using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuCoonTest.Model;
using QuCoonTest.Repository;

namespace QuCoonTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountActivity : ControllerBase
    {
        private readonly IUserActivity _userActivity;
        public AccountActivity(IUserActivity userActivity)
        {
            _userActivity = userActivity;
        }


        [HttpPost("Create-Customer-Account")]
        public async Task<ActionResult<string>> CreateAccount([FromBody] AccountDetails accountDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _userActivity.CreateAccount(accountDetails);

            return response;

        }

        [HttpGet("Name-Enquiry/{id}")]
        public async Task<ActionResult<string>> GetCustomerName([FromRoute] int id)
        {
            if (id <= 0)
            {
                return NotFound("Customer not found");
            }
            var customer = await _userActivity.GetCustomerNameById(id);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }
            else
            {
                return customer;
            }

        }

        [HttpGet("Balance-Enquiry/{id}")]
        public async Task<ActionResult<string>> GetCustomerbalance([FromRoute] int id)
        {
            if (id <= 0)
            {
                return NotFound("Customer not found");
            }
            var customerBalance = await _userActivity.GetCustomerBalanceById(id);
            
            return customerBalance;          

        }

        [HttpGet("Transfer-Funds")]
        public async Task<ActionResult<string>> TransferFunds([FromBody] TransactionDetails transactionDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customerBalance = await _userActivity.TransferFunds(transactionDetails);

            return customerBalance;

        }


       /* [HttpGet("Get-Transaction-Status/{id}")]
        public async Task<ActionResult<string>> GetTransactionStatus([FromRoute] int transId)
        {
            
            var transactionStatus = await _userActivity.GetTransactionStatus(transId);

            return transactionStatus;

        }

        [HttpGet("Get-Transaction-History")]
        public async Task<ActionResult<TransactionDetails>> GetTransactionHistory([FromBody] TransactionQueryRequest request)
        {

            var transactionDetails = await _userActivity.GetTransactionHistory(request);

            return transactionDetails;

        }*/

    }
}
