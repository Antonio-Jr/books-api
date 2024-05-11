using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [NotMapped] public string FullName => $"{FirstName} {LastName}";
    public ICollection<Book> Books { get; set; } = new HashSet<Book>();
}