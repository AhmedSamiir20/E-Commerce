namespace Products.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
	
	private readonly ApplicationDbContext _context;

	public ProductCategoryRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<ProductCategory> Create(ProductCategory c)
	{
		var category = new ProductCategory
		{
			Name = c.Name,
		};
		await _context.ProductCategories.AddAsync(category);
		_context.SaveChanges();
		return category;
	}

	public ProductCategory DeleteById(ProductCategory c)
	{
		_context.ProductCategories.Remove(c);
		_context.SaveChangesAsync();
		return c;
	}

	public async Task<IEnumerable<ProductCategory>> GetAll()
	{
		return (await _context.ProductCategories.ToListAsync());
	}

	public async Task<ProductCategory> GetById(Guid id)
	{
		return (await _context.ProductCategories.SingleOrDefaultAsync(u=>u.Id==id));
	}

	public async Task<bool> IsValidCategory(Guid id)
	{
		return (await _context.ProductCategories.AnyAsync(c => c.Id == id));
	}

	public ProductCategory Update(ProductCategory c)
	{
		_context.Update(c);
		_context.SaveChanges();
		return c;
	}
}
