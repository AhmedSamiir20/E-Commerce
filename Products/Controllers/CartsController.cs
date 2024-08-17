using Microsoft.Identity.Client;

namespace Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
	private readonly ICartRepository _cartRepository;

	public CartsController(ICartRepository cartRepository)
	{
		_cartRepository = cartRepository;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAsync()
	{
		return Ok(await _cartRepository.GetAll());
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetByIdAsync([FromForm]Guid id)
	{
		var cart=await _cartRepository.GetById(id);
		if(cart == null)
			return NotFound();
		return Ok(cart);
	}

	[HttpPost]
	public async Task<IActionResult> CreateAsync([FromForm] Cart c)
	{
		return Ok(await _cartRepository.Create(c));
	}

	[HttpPut]
	public async Task<IActionResult> UpdateAsync([FromForm] Guid id , [FromForm] Cart? c)
	{
		var cart=await _cartRepository.GetById(id);
		if( cart == null)
			return NotFound();
		cart.UserId = c.UserId;
		_cartRepository.Update(cart);
		return Ok(cart);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteAsync([FromForm] Guid id)
	{
		var cart= await _cartRepository.GetById(id);
		if(cart == null)
			return NotFound();
		_cartRepository.DeleteById(cart);
		return Ok(cart);
	}
}
