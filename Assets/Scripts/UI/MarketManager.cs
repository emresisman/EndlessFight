using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    int money;
    private SaveState state;
    private GunState Guns;
    public Text text;

    void Start()
    {
        state = SaveManager.LoadState();
        money = SaveReader.money;
        CheckStats();
        text.text = SaveReader.money.ToString();
    }

    void CheckStats()
    {
        
    }
}
