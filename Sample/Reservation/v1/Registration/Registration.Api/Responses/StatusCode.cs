﻿using System;
namespace Registration.Api.Responses
{
    public enum StatusCode
    {
        Success = 1,
        InvalidCredentials = 2,
        InvalidParameters = 3,
        InternalException = 4,
        Unknown = 5,
        FailedAction = 6
    }
}
