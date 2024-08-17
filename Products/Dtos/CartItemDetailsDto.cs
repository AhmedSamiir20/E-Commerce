namespace Products.Dtos;

public class CartItemDetailsDto
{
	public int Qty { get; set; }

	public Guid CartId { get; set; }

	public Guid ProductId { get; set; }

	
}
