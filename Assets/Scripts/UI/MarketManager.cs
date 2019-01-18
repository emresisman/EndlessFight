using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    int money, position;
    int[] buyButtonWeapon, buyButtonBody;
    public Text moneyText;
    public Image itemPrefab;
    public Image gunPanel, bodyPanel;
    public GameObject popUpGun, popUpBody;

    internal void PopGun(bool v, GameObject gameObject)
    {
        if (v)
        {
            popUpGun.transform.position = gameObject.transform.position;
            popUpGun.SetActive(true);           
        }
        else
        {
            popUpGun.SetActive(false);
        }
    }

    internal void PopBody(bool v, GameObject gameObject)
    {
        if (v)
        {
            popUpBody.transform.position = gameObject.transform.position;
            popUpBody.SetActive(true);
        }
        else
        {
            popUpBody.SetActive(false);
        }
    }

    void Start()
    {
        position = 135;
        buyButtonWeapon = new int[SaveReader.gunCount];
        buyButtonBody = new int[SaveReader.bodyCount];
        money = SaveReader.money;
        moneyText.text = SaveReader.money.ToString();
        OnLoad();
        //popUpGun.SetActive(false);
        //popUpBody.SetActive(false);
    }

    void OnLoad()
    {
        //Visualization
        for (int i = 0; i < buyButtonWeapon.Length; i++)
        {
            Image gunitem = Instantiate(itemPrefab, gunPanel.transform);
            gunitem.rectTransform.anchoredPosition = new Vector3(position, 0, 0);
            gunitem.GetComponent<MarketItemClickAction>().isGun = true;
            gunitem.GetComponent<MarketItemClickAction>().nameGun = SaveReader.guns[i].name;
            gunitem.GetComponent<MarketItemClickAction>().damage = SaveReader.guns[i].damage;
            gunitem.GetComponent<MarketItemClickAction>().fireRate = SaveReader.guns[i].fireRate;
            gunitem.GetComponent<MarketItemClickAction>().bulletSpeed = (int)SaveReader.guns[i].bulletSpeed;
            Text name = gunitem.transform.GetChild(0).GetComponent<Text>();
            Text cost = gunitem.transform.GetChild(3).GetComponent<Text>();
            Image sprite = gunitem.transform.GetChild(1).GetComponent<Image>();
            cost.text = SaveReader.guns[i].cost.ToString();
            name.text = SaveReader.guns[i].name;
            sprite.sprite = SaveReader.gunSprites[i];
            position+= 235;
        }
        position = 135;
        for (int i = 0; i < buyButtonBody.Length; i++)
        {
            Image gunitem = Instantiate(itemPrefab, bodyPanel.transform);
            gunitem.rectTransform.anchoredPosition = new Vector3(position, 0, 0);
            gunitem.GetComponent<MarketItemClickAction>().isGun = false;
            gunitem.GetComponent<MarketItemClickAction>().nameBody = SaveReader.bodies[i].name;
            gunitem.GetComponent<MarketItemClickAction>().health = SaveReader.bodies[i].health;
            gunitem.GetComponent<MarketItemClickAction>().speed = (int)SaveReader.bodies[i].movementSpeed;
            Text name = gunitem.transform.GetChild(0).GetComponent<Text>();
            Text cost = gunitem.transform.GetChild(3).GetComponent<Text>();
            Image sprite = gunitem.transform.GetChild(1).GetComponent<Image>();
            cost.text = SaveReader.bodies[i].cost.ToString();
            name.text = SaveReader.bodies[i].name;
            sprite.sprite = SaveReader.bodySprites[i];
            position += 235;
        }

        gunPanel.rectTransform.offsetMin = new Vector2(50, ((Screen.height - 240) / 2) + 190);
        bodyPanel.rectTransform.offsetMax = new Vector2(-50, -(((Screen.height - 240) / 2) + 100));
    }

    /*public void Popup(bool onClick, GameObject thisObject)
    {
        if (onClick)
        {
            popUpGun.transform.position = thisObject.transform.position;
            popUpGun.SetActive(true);
        }
        else
        {
            popUpGun.SetActive(false);
        }
    }*/
}
