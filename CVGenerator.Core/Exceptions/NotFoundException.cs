using System;

namespace CVGenerator.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name)
            : base($"Объект \"{name}\" не найден.") { }

        public NotFoundException(string name, object key)
            : this($"{name} ({key})") { }
    }
}