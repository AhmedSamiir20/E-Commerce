namespace Products.Repositories.Contracts;

public interface IUserRepository
{
	 Task<IEnumerable<User>> GetAll();
	 Task<User> GetById(Guid id);
	 Task<User> Create(User u);
	 User Update(User u);
	 User Delete(User u);
	Task<bool> IsValidUser(Guid id);
}
