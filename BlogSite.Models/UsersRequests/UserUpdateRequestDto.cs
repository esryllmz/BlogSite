

namespace BlogSite.Models.Dtos.UsersRequests;
public sealed record UserUpdateRequestDto(
    string FirstName,
    string LastName,
    string City,
    string Username
    );
