namespace RestaurantFrontend.Service
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;

    public class TokenExpirationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenExpirationClaim = context.HttpContext.User.FindFirst("exp");

            if (tokenExpirationClaim != null)
            {
                if (long.TryParse(tokenExpirationClaim.Value, out long expirationTime))
                {
                    var expirationDateTime = DateTimeOffset.FromUnixTimeSeconds(expirationTime).UtcDateTime;

                    if (DateTime.UtcNow >= expirationDateTime)
                    {
                        // Token has expired
                        context.HttpContext.Items["SessionExpired"] = true;
                    }
                }
                else
                {
                    // Handle invalid or unrecognized expiration claim value
                    // This could indicate a problem with the token format
                    // You might want to log an error or take appropriate action
                }
            }
        }
    }


}
