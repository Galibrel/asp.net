using SalesWebmvc.Models.Enums;

namespace SalesWebmvc.Models
{
    public class SalesRecord
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public SalesStatus Status { get; set; }

        public Saller Saller { get; set; }
        public SalesRecord() { }

        public SalesRecord(int iD, DateTime date, double amount, SalesStatus status, Saller saller)
        {
            ID = iD;
            Date = date;
            Amount = amount;
            Status = status;
            Saller = saller;
        }
    }
}
