namespace Products.Models;

public class User
{
	public Guid? Id { get; set; } = Guid.NewGuid();

	public string UserName { get; set; }
}
