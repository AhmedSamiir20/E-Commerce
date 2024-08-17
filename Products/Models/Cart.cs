﻿namespace Products.Models;

public class Cart
{
	public Guid? Id { get; set; } = Guid.NewGuid();

	public Guid UserId { get; set; }

	public User? User { get; set; }

}
