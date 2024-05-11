using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class BookRepository(DataContext context) : Repository<Book>(context), IBookRepository;