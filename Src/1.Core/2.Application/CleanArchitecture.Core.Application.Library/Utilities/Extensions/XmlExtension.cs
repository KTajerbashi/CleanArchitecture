using System.Xml.Linq;
using System.Xml.Serialization;

namespace CleanArchitecture.Core.Application.Library.Utilities.Extensions;
public static class XmlExtension
{
    public static T Deserialize<T>(this string xmlObject)
    {
        var serializer = new XmlSerializer(typeof(T));
        T result;

        using (TextReader reader = new StringReader(xmlObject))
        {
            result = (T)serializer.Deserialize(reader);
            return result;
        }
    }

    public static string ToXML<T>(this T value)
    {
        if (value == null)
        {
            return string.Empty;
        }
        try
        {
            var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(stringwriter, value);
            return stringwriter.ToString();
        }
        catch (Exception ex)
        {
            // throw new Exception("An error occurred", ex); 
        }
        return "";

    }

    public static string ArrayToXML(object[] value)
    {
        if (value == null)
        {
            return string.Empty;
        }
        try
        {
            XDocument doc = new XDocument();
            doc.Add(new XElement("root", value.Select(x => new XElement(x.ToString(), x))));
            return doc.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred", ex);
        }

    }
}
