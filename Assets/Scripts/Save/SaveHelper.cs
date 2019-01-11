using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class SaveHelper
{
    public static string Serialize<T>(SaveState toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(SaveState));
        /*FileStream fs = new FileStream(Application.dataPath + "/test.xml", FileMode.Create);
        xml.Serialize(fs, toSerialize);
        fs.Close();*/
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    public static string Serialize<T>(GunState toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(GunState));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    public static string Serialize<T>(BodyState toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(BodyState));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    public static SaveState DeserializeSave<T>(string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(SaveState));
        StringReader reader = new StringReader(toDeserialize);
        return (SaveState)xml.Deserialize(reader);
    }
    public static GunState DeserializeGun<T>(string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(GunState));
        StringReader reader = new StringReader(toDeserialize);
        return (GunState)xml.Deserialize(reader);
    }
    public static BodyState DeserializeBody<T>(string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(BodyState));
        StringReader reader = new StringReader(toDeserialize);
        return (BodyState)xml.Deserialize(reader);
    }

    public static void StopGame(int score)
    {
        SaveManager sm = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        sm.saveState.cost = (int)score / 10;
        if (score > sm.saveState.highScore)
        {
            sm.saveState.highScore = score;
        }
        sm.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
