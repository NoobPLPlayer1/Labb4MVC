using System.ComponentModel.DataAnnotations;

namespace Labb4MVC.Models;


public class BookType
{
    [Key, StringLength(13, MinimumLength = 10)] public string ISBN { get; init; }
    [StringLength(255)] public string Title { get; set; }
    public string Description { get; set; }
    public List<Book> Books { get; init; } = new();
}

public class Book
{
    [Key] public int ID { get; init; }
    public BookType BookType { get; set; }
    public string Status { get; set; }
    public List<LendPeriod> LentTo { get; init; } = new();
}