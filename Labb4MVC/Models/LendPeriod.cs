using System.ComponentModel.DataAnnotations;

namespace Labb4MVC.Models
{
    public class LendPeriod
    {
        [Key] public int ID { get; init; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }
        public bool HasBook { get; set; }
        public DateTime Start { get; set; }
        public int Days { get; set; }
        public DateTime End => Start + TimeSpan.FromDays(Days);
    }
}
