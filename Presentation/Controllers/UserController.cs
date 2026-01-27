using Domain.Entities;
using Application.Interfaces;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<IResult> AddUser([FromBody] UserCreateDTO dto, CancellationToken ct)
        {

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Profile = new UserProfile
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    BirthDate = dto.BirthDate,
                    Status = dto.Status
                }
            };
            await _userRepository.AddUserAsync(user, ct);
            var changes = await _unitOfWork.SaveChangesAsync(ct);
            if (changes == 0) return Results.Problem("Failed to save the user.", statusCode: 500);
            return Results.Created($"user/{user.Id}", ToUserResponseDTO(user));

        }
        [HttpGet]
        public async Task<IResult> GetUsers(CancellationToken ct)
        {
            var users = await _userRepository.GetAllUsersAsync(ct);
            return Results.Ok(ToUsersResponseDTO(users));
        }
        [HttpGet("{userId}")]
        public async Task<IResult> GetUsers(Guid userId, CancellationToken ct)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, ct);
            if (user == null) return Results.NotFound();
            return Results.Ok(ToUserResponseDTO(user));
        }
        [HttpPut("{userId}")]
        public async Task<IResult> UpdateUser(Guid userId, [FromBody] UserUpdateDTO dto, CancellationToken ct)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, ct);
            if (user == null) return Results.NotFound(user);

            var newUserProfile = new UserProfile
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Status = dto.Status,
            };
            await _userRepository.UpdateUserAsync(user, newUserProfile, ct);

            var changed = await _unitOfWork.SaveChangesAsync(ct);
            if (changed == 0) return Results.Problem("Failed to update user", statusCode: 500);
            return Results.Ok(ToUserResponseDTO(user));
        }
        [HttpDelete("{userId}")]
        public async Task<IResult> DeleteUser(Guid userId, CancellationToken ct)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, ct);
            if (user == null) return Results.NotFound(user);

            await _userRepository.DeleteUserByIdAsync(user, ct);

            var changed = await _unitOfWork.SaveChangesAsync(ct);
            if (changed == 0) return Results.Problem("Failed to delete user", statusCode: 500);
            return Results.NoContent();
        }

        private UserResponseDTO ToUserResponseDTO(User user)
        {
            return new UserResponseDTO(user.Id, user.Name, user.Email, user.Profile.FirstName, user.Profile.LastName, user.Profile.BirthDate, user.Profile.Status);
        }
        private List<UserResponseDTO> ToUsersResponseDTO(List<User> users)
        {
            return users.Select(u => new UserResponseDTO
            (
                u.Id,
                u.Name,
                u.Email,
                u.Profile.FirstName,
                u.Profile.LastName,
                u.Profile.BirthDate,
                u.Profile.Status
            )).ToList();
        }
    }
}
