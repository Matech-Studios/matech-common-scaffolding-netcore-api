﻿using System;

namespace Matech.Common.Scaffolding.Core.CustomExceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BusinessException()
        {
        }
    }
}
