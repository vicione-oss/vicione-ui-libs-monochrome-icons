using System.Text;

namespace ViciOne.Ui.MonochromeIcons.Core.Extensions;

/// <summary>
/// Extension methods for <see cref="string"/>
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string in <see href="https://en.wikipedia.org/wiki/Letter_case#Camel_case">upper camel case</see> to
    /// <see href="https://en.wikipedia.org/wiki/Letter_case#Kebab_case">kebab case</see>.
    /// </summary>
    public static string ToDashCase(this string s)
    {
        // https://stackoverflow.com/a/57517576/3936440

        if (string.IsNullOrEmpty(s))
            return s;

        var sb = new StringBuilder();
        var processingDigits = false;

        foreach (var ch in s)
        {
            if (char.IsDigit(ch))
            {
                if (!processingDigits && sb.Length > 0)
                    sb.Append('-');

                sb.Append(ch);

                processingDigits = true;
            }
            else if (char.IsUpper(ch))
            {
                if (sb.Length > 0)
                    sb.Append('-');

                sb.Append(char.ToLowerInvariant(ch));

                processingDigits = false;
            }
            else
            {
                sb.Append(ch);

                processingDigits = false;
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Joins the given <paramref name="values"/> using a single space as separator.
    /// </summary>
    public static string ToSpaceSeparated(this IEnumerable<string> values)
        => string.Join(" ", values);
}
