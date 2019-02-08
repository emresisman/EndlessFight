using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text _money, _highScore;

    void Start()
    {
        _money.text = "Money : " + SaveReader.money.ToString();
        _highScore.text = "High Score : " + SaveReader.highScore.ToString();
    }
}