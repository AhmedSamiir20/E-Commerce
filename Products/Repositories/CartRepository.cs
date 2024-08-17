using Microsoft.EntityFrameworkCore;

namespace Products.Repositories;

public class CartRepository : ICartRepository
{

	private readonly ApplicationDbContext _context;

	public CartRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Cart> Create(Cart c)
	{
		var cart = new Cart
		{
			UserId = c.UserId
		};
		await _context.Carts.AddAsync(cart);
		await _context.SaveChangesAsync();
		return cart;
	}

	public Cart DeleteById(Cart c)
	{
		_context.Carts.Remove(c);
		_context.SaveChanges();
		return c;
	}

	public async Task<IEnumerable<CartDto>> GetAll()
	{
		return (await _context.Carts.Include(c => c.User).Select(m=>new CartDto
		{
			Id = m.Id,
			UserId = m.UserId,
			UserName=m.User.UserName
		}).ToListAsync());	
	}

	public async Task<Cart> GetById(Guid id)
	{
		return (await _context.Carts.FirstOrDefaultAsync(c=>c.Id==id));
	}

	public  Cart Update(Cart c)
	{
		 _context.Update(c);
		_context.SaveChanges();
		return c; 
	}
}
