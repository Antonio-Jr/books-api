using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public EStatus? Status { get; set; }
    public EBookType BookType { get; set; }
    public int TotalCopies { get; set; } = 0;
    public int CopiesInUse { get; set; } = 0;

    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }

    public Author Author { get; set; }
    public Category Category { get; set; }
}