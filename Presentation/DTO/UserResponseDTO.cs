namespace Application.DTO
{
    public record UserResponseDTO(Guid Id, string Name, string Email, string? FirstName, string? LastName, DateOnly? BirthDate, string? Status);
}
