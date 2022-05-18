using System;
using System.ComponentModel.DataAnnotations;

namespace Labb4MVC.Models;
public class Customer
{
    [Key] public int ID { get; init; }
    public string Name { get; set; }
    [StringLength(15)] public string Phonenumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public uint PostCode { get; set; }
    public List<LendPeriod> Lending { get; init; } = new();
}
