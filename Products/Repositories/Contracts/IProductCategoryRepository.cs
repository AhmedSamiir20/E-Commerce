namespace Products.Repositories.Contracts;

public interface IProductCategoryRepository
{
	Task<IEnumerable<ProductCategory>> GetAll();
	Task<ProductCategory> GetById(Guid id);
	Task<ProductCategory> Create(ProductCategory c);
	ProductCategory Update(ProductCategory c);
	ProductCategory DeleteById(ProductCategory c);
	Task<bool> IsValidCategory(Guid id);
}
