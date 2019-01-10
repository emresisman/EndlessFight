using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    int money;
    private SaveState state;
    private GunState Guns;
    Button btn;

    void Start()
    {
        state = SaveManager.LoadState();
        money = SaveReader.money;
        CheckStats();
        //Guns = GameObject.Find("GunClick").GetComponent<GunState>();
    }

    void CheckStats()
    {
        
    }
}
