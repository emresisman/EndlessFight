using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    private static Text _dangerText, _scoreText, _comboText;
    private static float _dangerTimer = 3;
    private static bool _isDanger = false;

    void Start()
    {
        _dangerText = this.transform.GetChild(2).GetComponent<Text>();
        _scoreText = this.transform.GetChild(3).GetComponent<Text>();
        _comboText = this.transform.GetChild(4).GetComponent<Text>();
        _dangerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_isDanger)
        {
            _dangerTimer -= Time.deltaTime;
            _dangerText.text = "You are in the Danger Zone \n You should leave in " + (int)_dangerTimer + " seconds.";
            _dangerText.gameObject.SetActive(true);
        }
        else {
            _dangerTimer = 3f;
            _dangerText.text = "";
            _dangerText.gameObject.SetActive(false);
        } 
        if (_dangerTimer <= 0) Time.timeScale = 0f;
    }

    public static void DangerText(bool isDanger)
    {
        _isDanger = isDanger;
    }

    public static void ScoreText(float _score)
    {
        _scoreText.text = "Score : " + (int)_score;
    }

    public static void ComboText(int _combo)
    {
        _comboText.text = "Combo : " + _combo;
    }
}
