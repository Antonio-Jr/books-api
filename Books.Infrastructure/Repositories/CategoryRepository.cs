
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class CategoryRepository(DataContext context) : Repository<Category>(context), ICategoryRepository;