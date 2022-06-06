using System;

namespace CVGenerator.Core.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
            : base("Доступ запрещен.") { }
    }
}