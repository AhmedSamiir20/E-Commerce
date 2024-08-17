namespace Products.Dtos;

public class CartItemDto
{
	public Guid? Id { get; set; } = Guid.NewGuid();

	public int Qty { get; set; }

	public Guid CartId { get; set; }

	public Guid ProductId { get; set; }

	public string ProductName { get; set; }
}
