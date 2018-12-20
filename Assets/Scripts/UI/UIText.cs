using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour {

    public static TextMeshProUGUI _dangerText, _scoreText, _comboText;
    //public static Text _dangerText;
    static float _dangerTimer = 3.9f;
    private static bool _isDanger = false;

    void Start()
    {
        _dangerText = this.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _scoreText = this.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        _comboText = this.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        _comboText.gameObject.SetActive(false);
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
            _dangerTimer = 3.9f;
            _dangerText.text = "";
            _dangerText.gameObject.SetActive(false);
        }
        if (_dangerTimer <= 0.9f) Time.timeScale = 0f;
    }

    public static void DangerText(bool isDanger)
    {
        _isDanger = isDanger;
    }

    public static void ScoreText()
    {

    }


}
