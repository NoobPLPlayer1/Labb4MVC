using System.ComponentModel.DataAnnotations;

namespace Labb4MVC.Models
{
    public class LendPeriod : IIdentifiableInt
    {
        [Key] public int ID { get; init; }
        public Customer Customer { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public bool HasBook { get; set; }
        [DataType(DataType.Date)]public DateTime Start { get; set; } = DateTime.Now;
        public int Days { get; set; }
        public DateTime End => Start + TimeSpan.FromDays(Days);
    }
}
