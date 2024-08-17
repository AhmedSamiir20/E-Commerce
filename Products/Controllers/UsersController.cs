using System.Runtime.CompilerServices;

namespace Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly IUserRepository _userRepository;

	public UsersController(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}
	[HttpGet]
	public async Task<IActionResult> GetAll()=>Ok(await _userRepository.GetAll());

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromForm] Guid id)
	{
		var user=await _userRepository.GetById(id);
		if (user == null)
			return NotFound();
		return Ok(user);
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromForm] User u)
	{
		var user = new User
		{
			UserName = u.UserName,
		};
		await _userRepository.Create(user);
		return Ok(user);
	}


	[HttpPut]
	public async Task<IActionResult> Update([FromForm] Guid id, [FromForm] User u)
	{
		var user= await _userRepository.GetById(id);
		if(user == null) return NotFound();
		user.UserName = u.UserName;
		 _userRepository.Update(user);
		return Ok(user);
	}

	[HttpDelete]
	public async Task<IActionResult> Delete([FromForm]Guid id)
	{
		var user= await _userRepository.GetById(id);
		if (user == null) return NotFound();
		_userRepository.Delete(user);
		return Ok(user);
	}
}
