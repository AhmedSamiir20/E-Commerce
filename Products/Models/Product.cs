namespace Products.Models;

public class Product
{
	public Guid Id { get; set; }= Guid.NewGuid();

	public string Name { get; set; }

	public string Description { get; set; } 

	public string ImageURL { get; set; }
	
	public decimal Price { get; set; }
	
	public int Qty { get; set; }
	
	public Guid? CategoryId { get; set; }

	public ProductCategory? Category { get; set; }
}
