using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public MarketManager mm;
    public SaveManager sm;
    //In-game Buttons

    public void RetryClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    //Main Menu Buttons

    public void MarketClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void PlayClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    //Market Buttons

    public void MenuClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void BuyClick(GunState GunData)
    {
        if (SaveReader.money >= GunData.cost && GunData.isLocked)
        {
            GunData.isLocked = false;
            
            SaveReader.money -= GunData.cost;
            mm.UpdateMarket();
        }
    }

    public void BuyClick(BodyState BodyData)
    {
        if (SaveReader.money >= BodyData.cost && BodyData.isLocked)
        {
            BodyData.isLocked = false;
            SaveReader.money -= BodyData.cost;
            mm.UpdateMarket();
        }
    }

    public void UseClick(GunState GunData)
    {
        if (!GunData.isLocked)
        {
            GunData.isLocked = false;
            SaveReader.gunIndex = GunData.id;
            mm.UpdateMarket();
        }
    }

    public void UseClick(BodyState BodyData)
    {
        if (SaveReader.money >= BodyData.cost && BodyData.isLocked)
        {
            BodyData.isLocked = false;
            SaveReader.bodyIndex = BodyData.id;
            mm.UpdateMarket();
        }
    }
}
