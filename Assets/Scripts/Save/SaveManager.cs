using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; set; }
    public SaveState state;
    public Text highScore;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(state));
    }

    public void Save(int score)
    {
        state.Score = score;
        PlayerPrefs.SetString("Save", SaveHelper.Serialize<SaveState>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            state = SaveHelper.Deserialize<SaveState>(PlayerPrefs.GetString("Save"));
            highScore.text = state.Score.ToString();
        }
        else
        {
            state = new SaveState();
            Save();
        }
    }
}
