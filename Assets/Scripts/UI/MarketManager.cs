using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    int money, position;
    Image[] buyButtonWeapon, buyButtonBody;
    public Text moneyText, buttonText;
    public Image itemPrefab;
    public Image gunPanel, bodyPanel;
    public GameObject popUpGun, popUpBody;
    private Color useColor;
    public SceneManager sm;

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
        useColor = new Color(0.5f, 1f, 0.5f);
        position = 135;
        buyButtonWeapon = new Image[SaveReader.gunCount];
        buyButtonBody = new Image[SaveReader.bodyCount];
        OnLoad();
        UpdateMarket();
        //popUpGun.SetActive(false);
        //popUpBody.SetActive(false);
    }

    public void OnLoad()
    {
        //Visualization
        for (int i = 0; i < buyButtonWeapon.Length; i++)
        {
            GunState gun = SaveReader.guns[i];
            Image gunitem = Instantiate(itemPrefab, gunPanel.transform);
            buyButtonWeapon[i] = gunitem;
            gunitem.rectTransform.anchoredPosition = new Vector3(position, 0, 0);
            gunitem.GetComponent<MarketItemClickAction>().isGun = true;
            gunitem.GetComponent<MarketItemClickAction>().nameGun = gun.name;
            gunitem.GetComponent<MarketItemClickAction>().damage = gun.damage;
            gunitem.GetComponent<MarketItemClickAction>().fireRate = gun.fireRate;
            gunitem.GetComponent<MarketItemClickAction>().bulletSpeed = (int)gun.bulletSpeed;
            Text name = gunitem.transform.GetChild(0).GetComponent<Text>();
            Text cost = gunitem.transform.GetChild(3).GetComponent<Text>();
            Image sprite = gunitem.transform.GetChild(1).GetComponent<Image>();      
            cost.text = gun.cost.ToString();
            name.text = gun.name;
            sprite.sprite = SaveReader.gunSprites[i];
            position+= 235;
        }
        position = 135;
        for (int i = 0; i < buyButtonBody.Length; i++)
        {
            BodyState body = SaveReader.bodies[i];
            Image gunitem = Instantiate(itemPrefab, bodyPanel.transform);
            buyButtonBody[i] = gunitem;
            gunitem.rectTransform.anchoredPosition = new Vector3(position, 0, 0);
            gunitem.GetComponent<MarketItemClickAction>().isGun = false;
            gunitem.GetComponent<MarketItemClickAction>().nameBody = body.name;
            gunitem.GetComponent<MarketItemClickAction>().health = body.health;
            gunitem.GetComponent<MarketItemClickAction>().speed = (int)body.movementSpeed;
            Text name = gunitem.transform.GetChild(0).GetComponent<Text>();
            Text cost = gunitem.transform.GetChild(3).GetComponent<Text>();
            Image sprite = gunitem.transform.GetChild(1).GetComponent<Image>();
            cost.text = body.cost.ToString();
            name.text = body.name;
            sprite.sprite = SaveReader.bodySprites[i];
            position += 235;
        }
        int panelHeight = (Screen.height - 250) / 2;
        gunPanel.rectTransform.offsetMin = new Vector2(50, (panelHeight + 200));
        bodyPanel.rectTransform.offsetMax = new Vector2(-50, -(panelHeight + 100));
        //gunPanel.rectTransform.
    }

    public void UpdateMarket()
    {
        money = SaveReader.money;
        moneyText.text = SaveReader.money.ToString();
        for (int i = 0; i < buyButtonWeapon.Length; i++)
        {
            GunState gun = SaveReader.guns[i];
            Button btn = buyButtonWeapon[i].transform.GetChild(4).GetComponent<Button>();
            if (!gun.isLocked)
            {
                if (i == SaveReader.gunIndex)
                {
                    btn.transform.GetChild(0).GetComponent<Text>().text = " ";
                    btn.GetComponent<Image>().enabled = false;
                }
                else
                {
                    btn.transform.GetChild(0).GetComponent<Text>().text = "Use";
                    btn.GetComponent<Image>().enabled = true;
                }
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(delegate { sm.UseClick(gun); });
                btn.GetComponent<Image>().color = useColor;
            }
            else
            {
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(delegate { sm.BuyClick(gun, gun.id); });
            }
        }
        for (int i = 0; i < buyButtonBody.Length; i++)
        {
            BodyState body = SaveReader.bodies[i];
            Button btn = buyButtonBody[i].transform.GetChild(4).GetComponent<Button>();
            if (!body.isLocked)
            {
                if (i == SaveReader.bodyIndex)
                {
                    btn.transform.GetChild(0).GetComponent<Text>().text = " ";
                    btn.GetComponent<Image>().enabled = false;
                }
                else
                {
                    btn.transform.GetChild(0).GetComponent<Text>().text = "Use";
                    btn.GetComponent<Image>().enabled = true;
                }
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(delegate { sm.UseClick(body); });
                btn.GetComponent<Image>().color = useColor;
            }
            else
            {
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(delegate { sm.BuyClick(body, body.id); });
            }
        }
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
