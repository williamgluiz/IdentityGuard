using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IdentityGuard.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var dateBirthClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if(dateBirthClaim is null) 
                return Task.CompletedTask;

            var dtBirth = Convert.ToDateTime(dateBirthClaim.Value);

            var userAge = DateTime.Today.Year - dtBirth.Year;

            if (dtBirth > DateTime.Today.AddYears(-userAge))
                userAge--;

            if (userAge >= requirement.Age)
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}
