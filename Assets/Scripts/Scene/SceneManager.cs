using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ResetClick()
    {
        sm.ResetData();
        //sm.Save();
        MarketClick();
    }

    public void BuyClick(GunState GunData, int index)
    {
        if (SaveReader.money >= GunData.cost && GunData.isLocked)
        {
            sm.guns[index].isLocked = false;
            GunData.isLocked = false;
            SaveReader.money -= GunData.cost;
            sm.Save();
            SaveReader.Load();
            mm.UpdateMarket();
        }
    }

    public void BuyClick(BodyState BodyData, int index)
    {
        if (SaveReader.money >= BodyData.cost && BodyData.isLocked)
        {
            sm.bodies[index].isLocked = false;
            BodyData.isLocked = false;
            SaveReader.money -= BodyData.cost;
            sm.Save();
            SaveReader.Load();
            mm.UpdateMarket();
        }
    }

    public void UseClick(GunState GunData)
    {
        if (!GunData.isLocked)
        {
            sm.saveState.gunID = GunData.id;
            SaveReader.gunIndex = GunData.id;
            sm.Save();
            SaveReader.Load();
            mm.UpdateMarket();
        }
    }

    public void UseClick(BodyState BodyData)
    {
        if (!BodyData.isLocked)
        {
            sm.saveState.bodyID = BodyData.id;
            SaveReader.bodyIndex = BodyData.id;
            sm.Save();
            SaveReader.Load();
            mm.UpdateMarket();
        }
    }
}
