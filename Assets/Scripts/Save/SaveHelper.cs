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

    public static string Serialize<T>(bool[] toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(bool[]));
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

    public static bool[] Deserialize<T>(string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(bool[]));
        StringReader reader = new StringReader(toDeserialize);
        return (bool[])xml.Deserialize(reader);
    }

    public static void StopGame(int score, int cost)
    {
        SaveManager sm = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        sm.saveState.cost += cost;
        if (score > sm.saveState.highScore)
        {
            sm.saveState.highScore = score;
        }
        sm.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
