using System.IO;
using System.Xml.Serialization;

public static class SaveHelper
{
    public static string Serialize<T>(this SaveState toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(SaveState));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    public static string Serialize<T>(this GunState toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(GunState));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    public static string Serialize<T>(this BodyState toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(BodyState));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    public static SaveState DeserializeSave<T>(this string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(SaveState));
        StringReader reader = new StringReader(toDeserialize);
        return (SaveState)xml.Deserialize(reader);
    }
    public static GunState DeserializeGun<T>(this string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(GunState));
        StringReader reader = new StringReader(toDeserialize);
        return (GunState)xml.Deserialize(reader);
    }
    public static BodyState DeserializeBody<T>(this string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(BodyState));
        StringReader reader = new StringReader(toDeserialize);
        return (BodyState)xml.Deserialize(reader);
    }
}
