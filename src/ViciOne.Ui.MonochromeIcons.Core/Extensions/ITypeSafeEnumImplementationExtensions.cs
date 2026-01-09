using System.Collections.Generic;
using System.Linq;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Core.Extensions;

/// <summary>
/// Extension methods for <see cref="ITypeSafeEnumImplementation{T}"/>
/// </summary>
public static class ITypeSafeEnumImplementationExtensions
{
    /// <summary>
    /// Gets the name of all enum values represented by the given <paramref name="typeSafeEnumImplementations"/>.
    /// </summary>
    public static IEnumerable<string> GetNames<T>(this IEnumerable<T> typeSafeEnumImplementations)
        where T : ITypeSafeEnumImplementation<T>
            => typeSafeEnumImplementations.Select(i => i.GetName());
}
