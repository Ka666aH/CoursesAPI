namespace Application.DTO
{
    public record UserCreateDTO(string Name, string Email, string? FirstName, string? LastName, DateOnly? BirthDate, string? Status);
}
