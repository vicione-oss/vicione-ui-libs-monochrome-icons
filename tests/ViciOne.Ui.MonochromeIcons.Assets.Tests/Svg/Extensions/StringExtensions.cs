using Svg;
using System.IO;
using System.Xml;

namespace ViciOne.Ui.MonochromeIcons.Assets.Tests.Svg.Extensions;

internal static class StringExtensions
{
    public static SvgDocument ToSvgDocument(this string svgMarkup)
    {
        using var svgMarkupReader = new StringReader(svgMarkup);
        using var svgXmlReader = XmlReader.Create(svgMarkupReader);

        var svgDocument = SvgDocument.Open<SvgDocument>(svgXmlReader);

        return svgDocument;
    }
}
