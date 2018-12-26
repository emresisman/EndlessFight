using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public static SaveState state;

    private void Awake()
    {
        //ResetData();
        Load();
        DontDestroyOnLoad(gameObject);
        Instance = this;
        
    }

    public static void Save()
    {
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(state));
    }

    public static void Save(int score)
    {
        state.highScore = score;
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(state));
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            state = SaveHelper.DeserializeSave<SaveState>(PlayerPrefs.GetString("Save"));
        }
        else
        {
            state = new SaveState();
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
