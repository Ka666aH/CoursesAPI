namespace Application.DTO
{
    public record UserDTO(string Name, string Email, string? FirstName, string? LastName, DateOnly? BirthDate, string? Status);
}
