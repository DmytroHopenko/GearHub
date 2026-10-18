using GearHub.Application.Abstractions;
using GearHub.Application.Auth.Register;

using Microsoft.AspNetCore.Identity;

namespace GearHub.Infrastructure.Identity;

public sealed class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RegisterUserResult> RegisterAsync(RegisterUserCommand command)
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            UserName = command.UserName,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
        };

        var result = await _userManager.CreateAsync(
            user,
            command.Password
        );

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(error => new RegistrationError(error.Code, error.Description)).ToArray();

            return new RegisterUserResult(null, errors);
        }

        return new RegisterUserResult(
            user.Id,
            Array.Empty<RegistrationError>()
        );
    }
}