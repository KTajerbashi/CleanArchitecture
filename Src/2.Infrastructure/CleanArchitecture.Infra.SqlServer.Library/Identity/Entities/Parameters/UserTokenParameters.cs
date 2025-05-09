﻿namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Entities.Parameters;

public record UserTokenParameters(
    long UserId,
    string LoginProvider,
    string Name,
    string Value,
    string RefreshToken
    );
