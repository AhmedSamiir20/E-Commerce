namespace Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	public readonly ApplicationDbContext _context;

	public ProductsController(ApplicationDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAsync()
	{
		var products = await _context.Products.Include(p => p.Category).Select(p => new ProductDto
		{
			Id = p.Id,
			Name = p.Name,
			Description = p.Description,
			ImageURL = p.ImageURL,
			Price = p.Price,
			Qty = p.Qty,
			CategoryId = p.Category.Id,
			CategoryName = p.Category.Name,
		}).ToListAsync();

		return Ok(products);
	}

	[HttpGet("id")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var product = await _context.Products.FindAsync(id);
		if (product == null)
			return NotFound();
		return Ok(await _context.Products.Include(p => p.Category).Select(p => new ProductDto
		{
			Id = p.Id,
			Name = p.Name,
			Description = p.Description,
			ImageURL = p.ImageURL,
			Price = p.Price,
			Qty = p.Qty,
			CategoryId = p.Category.Id,
			CategoryName = p.Category.Name,
		}).ToListAsync());
	}

	[HttpPost]
	public async Task<IActionResult> CreateAsync([FromForm] Product p)
	{
		var product = new Product
		{
			Name = p.Name,
			Description = p.Description,
			ImageURL = p.ImageURL,
			Price = p.Price,
			Qty = p.Qty,
			CategoryId = p.CategoryId,
		};
		await _context.Products.AddAsync(product);
		_context.SaveChanges();
		return Ok(product);
	}

	[HttpPut("id")]
	public async Task<IActionResult> UpdateAsync([FromForm] Guid id, [FromForm] Product p)
	{
		var product = await _context.Products.FindAsync(id);
		if (product == null)
			return NotFound();
		product.Name = p.Name;
		product.Description = p.Description;
		product.ImageURL = p.ImageURL;
		product.Price = p.Price;
		product.Qty = p.Qty;
		product.CategoryId = p.CategoryId;

		_context.SaveChanges();
		return Ok(product);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteAsync([FromForm] Guid id)
	{
		var product = await _context.Products.FindAsync(id);
		if (product == null)
			return NotFound();
		_context.Products.Remove(product);
		_context.SaveChanges();
		return Ok(product);
	}
}
