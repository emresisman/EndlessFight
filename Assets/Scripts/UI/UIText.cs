using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    public Text _dangerText;
    float _dangerTimer = 3;
    private bool _isDanger = false;

    public void DangerText(bool isDanger)
    {
        _isDanger = isDanger;
        if (isDanger)
        {
            _dangerText.text = "You are in the Danger Zone \n You should leave in "+ _dangerText +" seconds.";
            _dangerText.gameObject.SetActive(true);
        }
        else
        {
            _dangerTimer = 3f;
            _dangerText.text = "";
            _dangerText.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (_isDanger) _dangerTimer -= Time.deltaTime;
        else _dangerTimer = 3f;
        if (_dangerTimer <= 0) Time.timeScale = 0f;
    }
}
