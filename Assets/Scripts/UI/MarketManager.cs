using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    int money;
    int[] buyButtonWeapon, useButtonWeapon, buyButtonBody, useButtonBody;
    private SaveState state;
    private GunState Guns;
    public Text text;

    void Start()
    {
        buyButtonWeapon = new int[SaveReader.gunCount];
        useButtonWeapon = new int[SaveReader.gunCount];
        buyButtonBody = new int[SaveReader.bodyCount];
        useButtonBody = new int[SaveReader.bodyCount];
        state = SaveManager.LoadState();
        money = SaveReader.money;
        OnLoad();
        text.text = SaveReader.money.ToString();
    }

    void OnLoad()
    {

    }
}
