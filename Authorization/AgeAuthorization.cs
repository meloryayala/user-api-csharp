using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace UserApi.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimumAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
    {
        var bornDateClaim = context
            .User
            .FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if (bornDateClaim is null)
        {
            return Task.CompletedTask;
        }

        var bornDate = Convert
            .ToDateTime(bornDateClaim.Value);

        var userAge = DateTime.Today.Year - bornDate.Year;

        if (bornDate > DateTime.Today.AddYears(-userAge))
        {
            userAge--;
        }

        if (userAge >= requirement.Age)
        
            context.Succeed(requirement);
        

        return Task.CompletedTask;
    }
}