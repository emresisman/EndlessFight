using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public SaveState saveState;
    public GunState[] guns;
    public BodyState[] bodies;
    public bool[] gun, body;

    private void Awake()
    {
        //ResetData();
        Instance = this;
        guns = Resources.LoadAll<GunState>("DataFiles/Guns");
        bodies = Resources.LoadAll<BodyState>("DataFiles/Bodies");
        Load();
        //ResetData();
        SaveReader.LoadGun(guns);
        SaveReader.LoadBody(bodies);
        SaveReader.Load(saveState);
        DontDestroyOnLoad(gameObject);
    }

    void ExportItem()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].isLocked = gun[i];
        }
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].isLocked = body[i];
        }
    }

    void FillItem()
    {
        gun = new bool[guns.Length];
        body = new bool[bodies.Length];
        for (int i = 0; i < guns.Length; i++)
        {
            gun[i] = guns[i].isLocked;
        }
        for (int i = 0; i < bodies.Length; i++)
        {
            body[i] = bodies[i].isLocked;
        }
    }

    public void Save()
    {
        saveState = SaveReader.ReturnSave();
        FillItem();
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(saveState));
        PlayerPrefs.SetString("Gun", SaveHelper.Serialize<bool[]>(gun));
        PlayerPrefs.SetString("Body", SaveHelper.Serialize<bool[]>(body));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Save") && PlayerPrefs.HasKey("Gun") && PlayerPrefs.HasKey("Body"))
        {
            saveState = SaveHelper.DeserializeSave<SaveState>(PlayerPrefs.GetString("Save"));
            gun = SaveHelper.Deserialize<bool[]>(PlayerPrefs.GetString("Gun"));
            body = SaveHelper.Deserialize<bool[]>(PlayerPrefs.GetString("Body"));
            ExportItem();
        }
        else
        {
            ResetData();
            saveState = new SaveState();
            Save();
        }
    }

    /*public static SaveState LoadState()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            return SaveHelper.DeserializeSave<SaveState>(PlayerPrefs.GetString("Save"));
        }
        else
        { 
            return new SaveState();
        }
    }*/

    public void ResetData()
    {
        FillItem();
        PlayerPrefs.DeleteKey("Save");
        PlayerPrefs.DeleteKey("Gun");
        PlayerPrefs.DeleteKey("Body");
        gun[0] = true;
        body[0] = true;
        for (int i = 1; i < guns.Length; i++)
        {
            gun[i] = false;
        }
        for (int i = 1; i < bodies.Length; i++)
        {
            body[i] = false;
        }
    }
}
