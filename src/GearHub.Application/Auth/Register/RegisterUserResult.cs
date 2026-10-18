namespace GearHub.Application.Auth.Register;

public sealed record RegistrationError(
    string Code,
    string Description
);

public sealed record RegisterUserResult(
    Guid? UserId,
    IReadOnlyList<RegistrationError> Errors
)
{
    public bool Succeeded => UserId.HasValue && Errors.Count == 0;
}