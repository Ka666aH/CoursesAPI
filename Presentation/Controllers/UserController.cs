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
        public async Task<IResult> AddUser([FromBody] UserDTO userDTO, CancellationToken ct)
        {

            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Profile = new UserProfile
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    BirthDate = userDTO.BirthDate,
                    Status = userDTO.Status
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
        public async Task<IResult> UpdateUser(Guid userId,[FromBody] UserDTO userDTO, CancellationToken ct)
        {
            await _userRepository.UpdateUserAsync(new User
            {
                Id = userId,
                Name = userDTO.Name,
                Email = userDTO.Email,
                Profile = new UserProfile
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    BirthDate = userDTO.BirthDate,
                    Status = userDTO.Status
                }
            }, ct);
            var changed = await _unitOfWork.SaveChangesAsync(ct);
            if (changed == 0) return Results.Problem("Failed to update user", statusCode: 500);
            return Results.NoContent();
        }
        [HttpDelete("{userId}")]
        public async Task<IResult> DeleteUser(Guid userId, CancellationToken ct)
        {
            var exitst = await _userRepository.DeleteUserByIdAsync(userId, ct);
            if(!exitst) return Results.Problem("User is not exist", statusCode: 404);
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
