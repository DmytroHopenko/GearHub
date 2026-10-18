namespace GearHub.Application.Auth.Register;

public sealed record RegisterUserCommand(
    string Email,
    string UserName,
    string Password,
    string FirstName,
    string LastName
);
