using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public SaveState saveState;

    private void Awake()
    {
        Instance = this;
        Save();
        //ResetData();
        Load();
        SaveReader.Load(saveState);
        DontDestroyOnLoad(gameObject);
    }

    public void Save()
    {
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(saveState));

    }

    public void Save(int score)
    {
        saveState.highScore = score;
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(saveState));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            saveState = SaveHelper.DeserializeSave<SaveState>(PlayerPrefs.GetString("Save"));
        }
        else
        {
            saveState = new SaveState();
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

    }
}
