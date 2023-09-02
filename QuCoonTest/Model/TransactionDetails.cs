namespace QuCoonTest.Model
{
    public class TransactionDetails
    {
        public string TransactionId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string TransferAmount { get; set; }
        public bool IsInstantTransfer { get; set; } 
        public string SourceAccount { get; set; }
        public int DestinationAccountId { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
