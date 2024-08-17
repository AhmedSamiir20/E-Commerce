

namespace Products.Repositories;

public class UserRepository : IUserRepository
{
	private readonly ApplicationDbContext _context;

	public UserRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<User> Create(User u)
	{
		
		await _context.Users.AddAsync(u);
		_context.SaveChanges();
		return u;
	}

	public User Delete(User u)
	{
		
		_context.Users.Remove(u);
		 _context.SaveChangesAsync();
		return u;

	}

	public async Task<IEnumerable<User>> GetAll()
	{
		return (await _context.Users.OrderBy(u=>u.UserName).ToListAsync());
		
	}
		
	

	public async Task<User> GetById(Guid id)
	{
		return await _context.Users.FindAsync(id);
	}

	public async Task<bool> IsValidUser(Guid id)
	{
		return await _context.Users.AnyAsync(m => m.Id == id);
	}

	public User Update(User u)
	{
		_context.Update(u);
		_context.SaveChanges();
		return u;
	}
}
