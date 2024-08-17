namespace Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoriesController : ControllerBase
{
	private readonly IProductCategoryRepository _repository;

	public ProductCategoriesController(IProductCategoryRepository repository)
	{
		_repository = repository;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		return Ok(await _repository.GetAll());
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromForm] Guid id)
	{
		return Ok(await _repository.GetById(id));
	}

	[HttpPost]
	public async Task<IActionResult> CreateAsync([FromForm] ProductCategory c)
	{
		return Ok(await _repository.Create(c));
	}

	[HttpPut]
	public async Task<IActionResult> UpdateAsync([FromForm] Guid id, [FromForm] ProductCategory c)
	{
		var category= await _repository.GetById(id);
		category.Name = c.Name;
		_repository.Update(category);
		return Ok(category);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteAsync([FromForm]Guid id)
	{
		var category=await _repository.GetById(id);
		_repository.DeleteById(category);
		return Ok(category);
	}
}
