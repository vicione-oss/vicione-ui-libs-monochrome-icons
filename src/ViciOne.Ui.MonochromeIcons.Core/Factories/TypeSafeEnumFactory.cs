using System.Reflection;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Core.Factories;

/// <summary>
/// Factory for creating instances of <typeparamref name="T"/>
/// </summary>
public static class TypeSafeEnumFactory<T> where T : struct, IEquatable<T>, ITypeSafeEnumImplementation<T>
{
    private static readonly T s_defaultValue = T.GetDefaultValue();

    private static readonly Dictionary<string, T> s_typeSafeEnumImplementationMap = typeof(T)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Select(f => f.GetValue(null) as T?)
        .Where(i => i is not null)
        .Select(i => (T)i!)
        .ToDictionary(i => i.GetName());

    /// <summary>
    /// Creates an instance of <typeparamref name="T"/> based on the given <paramref name="enumValueName"/>.
    /// </summary>
    public static T Create(string enumValueName)
    {
        if (s_typeSafeEnumImplementationMap.TryGetValue(enumValueName, out var result))
            return result;
        else
            return s_defaultValue;
    }

    /// <summary>
    /// Creates instances for all <typeparamref name="T"/> discovered.
    /// </summary>
    public static IReadOnlyCollection<T> CreateAll()
        => s_typeSafeEnumImplementationMap.Values;
}
