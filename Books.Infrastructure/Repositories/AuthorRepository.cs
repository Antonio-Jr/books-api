using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class AuthorRepository(DataContext context) : Repository<Author>(context), IAuthorRepository;
