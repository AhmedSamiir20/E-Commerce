﻿namespace Products.Models;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Cart> Carts { get; set; }
    
    public DbSet<CartItem> CartItems { get; set; }

}

