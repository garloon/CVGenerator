using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Linq;
using System;

namespace CVGenerator.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetInstance<T>(this IConfiguration configuration, string key)
            where T : class, new()
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var instance = new T();
            var modelProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in modelProperties)
            {
                var propertyValue = configuration.GetChildren()
                    .FirstOrDefault(c => c.Key.Contains($"{key}_{property.Name}"));

                if (propertyValue == null)
                {
                    continue;
                }

                switch (Type.GetTypeCode(property.PropertyType))
                {
                    case TypeCode.Byte:
                        property.SetValue(instance, Convert.ToByte(propertyValue.Value));
                        break;
                    case TypeCode.Int16:
                        property.SetValue(instance, Convert.ToInt16(propertyValue.Value));
                        break;
                    case TypeCode.Int32:
                        property.SetValue(instance, Convert.ToInt32(propertyValue.Value));
                        break;
                    case TypeCode.Int64:
                        property.SetValue(instance, Convert.ToInt64(propertyValue.Value));
                        break;
                    case TypeCode.Boolean:
                        property.SetValue(instance, Convert.ToBoolean(propertyValue.Value));
                        break;
                    case TypeCode.Decimal:
                        property.SetValue(instance, Convert.ToDecimal(propertyValue.Value));
                        break;
                    case TypeCode.String:
                        property.SetValue(instance, Convert.ToString(propertyValue.Value));
                        break;
                    case TypeCode.DateTime:
                        property.SetValue(instance, Convert.ToDateTime(propertyValue.Value));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return instance;
        }
    }
}
