﻿using Microsoft.AspNetCore.Identity;

namespace NzWalks.Api.Repositories
{
    public interface ITokenRepository
    {
      string  CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
