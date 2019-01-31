using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    private static Text _dangerText, _scoreText, _comboText, _highScoreText;
    public Text _setdangerText, _setscoreText, _setcomboText, _sethighScoreText;
    private static float _dangerTimer = 3;
    private static bool _isDanger = false;

    void Start()
    {
        _dangerText = _setdangerText;
        _scoreText = _setscoreText;
        _comboText = _setcomboText;
        _highScoreText = _sethighScoreText;
        _highScoreText.text = "High Score : " + SaveReader.highScore.ToString() + " : Money : " + SaveReader.money.ToString();
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
        else
        {
            _dangerTimer = 3f;
            _dangerText.text = "";
            _dangerText.gameObject.SetActive(false);
        }
        if (_dangerTimer <= 0)
        {
            Score s = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
            SaveHelper.StopGame(s.GetScore(), s.GetMoney());
        }
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
