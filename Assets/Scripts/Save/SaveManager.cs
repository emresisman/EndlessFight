using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public static SaveState saveState;
    public static GunState gunState;
    public static BodyState bodyState;

    private void Awake()
    {
        //ResetData();
        Load();
        SaveReader.Load(gunState, bodyState, saveState);
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public static void Save()
    {
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(saveState));
        PlayerPrefs.SetString("SaveGun", SaveHelper.Serialize<GunState>(gunState));
        PlayerPrefs.SetString("SaveBody", SaveHelper.Serialize<BodyState>(bodyState));
    }

    public static void Save(int score)
    {
        saveState.highScore = score;
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(saveState));
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            saveState = SaveHelper.DeserializeSave<SaveState>(PlayerPrefs.GetString("Save"));
            gunState = SaveHelper.DeserializeGun<GunState>(PlayerPrefs.GetString("SaveGun"));
            bodyState = SaveHelper.DeserializeBody<BodyState>(PlayerPrefs.GetString("SaveBody"));
        }
        else
        {
            saveState = new SaveState();
            gunState = new GunState();
            bodyState = new BodyState();
            Save();
        }
    }

    public static SaveState LoadState()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            return SaveHelper.DeserializeSave<SaveState>(PlayerPrefs.GetString("Save"));
        }
        else
        {
            return new SaveState();
        }
    }

    public static void ResetData()
    {
        PlayerPrefs.DeleteKey("Save");
        PlayerPrefs.DeleteKey("SaveGun");
        PlayerPrefs.DeleteKey("SaveBody");
    }
}
