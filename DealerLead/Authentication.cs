using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace DealerLead
{
    class Authentication
    {
        private async Task OnTokenValidatedFunc(TokenValidatedContext context)
        {
            // Custom code here
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
