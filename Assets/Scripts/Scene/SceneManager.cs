using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    
    
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

    }

}
