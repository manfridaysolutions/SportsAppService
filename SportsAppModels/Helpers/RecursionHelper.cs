using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MFS.SportsApp.Models.Helpers
{
    public class RecursionHelper
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo?> _keyPropertyCache = new();

        public static (string Name, object Value)? GetKeyPropertyInfo<T>(T entity) where T : class
        {
            if (entity == null) return null;

            var entityType = typeof(T);

            // Get or cache the key property for this type
            var keyProperty = _keyPropertyCache.GetOrAdd(entityType, type =>
                type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute)))
            );

            if (keyProperty == null)
                return null;

            var keyValue = keyProperty.GetValue(entity);
            return keyValue == null ? null : (keyProperty.Name, keyValue);
        }

        public static void CopyPrimitiveProperties(object source, object destination, params string[] ignoreKeys)
        {
            if (source == null || destination == null)
                return;

            var sourceType = source.GetType();
            var destType = destination.GetType();

            if (!destType.IsAssignableFrom(sourceType) && sourceType != destType)
                throw new InvalidOperationException($"Cannot copy properties: {sourceType.Name} → {destType.Name}");

            foreach (var sourceProp in sourceType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                try
                {
                    if (ignoreKeys.Contains(sourceProp.Name))
                        continue;

                    var destProp = destType.GetProperty(sourceProp.Name,
                        System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

                    if (destProp == null || !destProp.CanWrite)
                        continue;

                    if (!IsPrimitiveType(sourceProp.PropertyType))
                        continue;

                    var sourceValue = sourceProp.GetValue(source);

                    // Optional: Skip copying null over non-null (preserve existing values)
                    // if (sourceValue == null && destProp.GetValue(destination) != null) 
                    //     continue;

                    destProp.SetValue(destination, sourceValue);
                }
                catch (System.Reflection.TargetInvocationException ex)
                {
                    // Log warning but continue with other properties
                    Console.WriteLine($"Warning: Could not copy property '{sourceProp.Name}': {ex.InnerException?.Message}");
                }
            }
        }


        /// <summary>
        /// Determines if a type is a "primitive" for copying purposes:
        /// value types, string, or nullable wrappers of value types.
        /// </summary>
        private static bool IsPrimitiveType(Type type)
        {
            // Handle nullable value types: int?, DateTime?, etc.
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // Recurse to check the underlying type
                return IsPrimitiveType(Nullable.GetUnderlyingType(type));
            }

            // Base cases: true primitives + string + DateTime + Guid + decimal
            return type.IsPrimitive
                || type == typeof(string)
                || type == typeof(DateTime)
                || type == typeof(DateTimeOffset)
                || type == typeof(Guid)
                || type == typeof(decimal)
                || type == typeof(TimeSpan);
        }
    }
}
