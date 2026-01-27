namespace Application.DTO
{
    public record UserUpdateDTO(string? FirstName, string? LastName, DateOnly? BirthDate, string? Status);
}
