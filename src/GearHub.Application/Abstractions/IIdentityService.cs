using GearHub.Application.Auth.Register;

namespace GearHub.Application.Abstractions;

public interface IIdentityService
{
    Task<RegisterUserResult> RegisterAsync(
        RegisterUserCommand command
    );
}