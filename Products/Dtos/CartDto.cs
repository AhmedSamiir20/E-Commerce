namespace Products.Dtos;

public class CartDto
{
	public Guid? Id { get; set; }
	public Guid UserId { get; set; }
	public string UserName { get; set; }
}
