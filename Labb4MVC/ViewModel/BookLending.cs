using Labb4MVC.Models;

namespace Labb4MVC.ViewModel
{
    public class CustomerBooks
    {
        public IEnumerable<Book> Books { get; set; }
        public int Customer { get; set; }
    }
}
