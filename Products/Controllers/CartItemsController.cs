using Microsoft.EntityFrameworkCore;

namespace Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemsController : ControllerBase
{
	private readonly ApplicationDbContext _context;

	public CartItemsController(ApplicationDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAsync()
	{
		var cartItems=await _context.CartItems.Include(c=>c.Cart).Include(c=>c.Product).Select(c=>new CartItemDto
		{
			Id = c.Id,
			Qty = c.Qty,
			ProductId = c.ProductId,
			ProductName = c.Product.Name,
			CartId=c.CartId,
		}).ToListAsync();

		return Ok(cartItems);
	}
	
	
	[HttpPost]
	public async Task<IActionResult> CreateAsync([FromForm] CartItemDetailsDto dto)
	{
		//var cartItems = new CartItem
		//{

		//	Qty = Dto.Qty,
		//	ProductId = Dto.ProductId,
		//	CartId = Dto.ProductId,
		//};
		//await _context.CartItems.AddAsync(cartItems);
		//_context.SaveChanges();
		//return Ok(cartItems);
		var item=await (from product in _context.Products
						where product.Id==dto.ProductId
						select new CartItem
						{
							CartId=dto.CartId,
							ProductId=product.Id,	
							Qty=dto.Qty,
						}).SingleOrDefaultAsync();
		if (item!=null) { 
			var result = await _context.CartItems.AddAsync(item);
			_context.SaveChanges();
			return Ok(item);
		}
		return BadRequest();
	}
	[HttpGet("Id")]
	public async Task<IActionResult> GetById([FromForm]Guid id)
	{
		var item=await _context.CartItems.FindAsync(id);
		if (item == null)
			return NotFound();
		
		return Ok(item);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteAsync([FromForm] Guid id)
	{
		var item = await _context.CartItems.FindAsync(id);
		if(item == null)
			return NotFound();
		_context.CartItems.Remove(item);
		_context.SaveChanges();
		return Ok(item);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateAsync([FromForm] Guid id,[FromForm] CartItemDetailsDto dto)
	{
		var item = await _context.CartItems.FindAsync(id);
		if( item == null)
			return NotFound();
		item.ProductId = dto.ProductId;
		item.CartId = dto.CartId;
		item.Qty = dto.Qty;
		_context.Update(item);
		_context.SaveChanges();
		return Ok(item);
	}
}     

      

	
