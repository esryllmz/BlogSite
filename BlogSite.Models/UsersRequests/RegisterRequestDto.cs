
namespace BlogSite.Models.Dtos.UsersRequests;

public sealed record RegisterRequestDto
    (
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Username,
    string City
    );
