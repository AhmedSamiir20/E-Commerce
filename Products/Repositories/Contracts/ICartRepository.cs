namespace Products.Repositories.Contracts;

public interface ICartRepository
{
	Task<IEnumerable<CartDto>> GetAll();
	Task<Cart> GetById(Guid id);
	Task<Cart> Create(Cart c);
	Cart Update(Cart c);
	Cart DeleteById(Cart c);
}
