using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    int money, position;
    Image[] buyButtonWeapon, buyButtonBody;
    public Text moneyText;
    public Image itemPrefab;
    public Image gunPanel, bodyPanel;
    public GameObject popUpGun, popUpBody;
    private Color useColor, buyColor;
    public SceneManager sm;

    internal void PopGun(bool v, GameObject gameObject)
    {
        if (v)
        {
            if (Camera.main.ScreenToWorldPoint(gameObject.transform.position).x < 0)
            {
                
                popUpGun.transform.position = new Vector3(gameObject.transform.position.x + 100, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                popUpGun.transform.position = new Vector3(gameObject.transform.position.x - 300, gameObject.transform.position.y, gameObject.transform.position.z);
            }
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
            if (gameObject.transform.position.x < Screen.width)
            {
                popUpBody.transform.position = new Vector3(gameObject.transform.position.x + 50, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                popUpBody.transform.position = new Vector3(gameObject.transform.position.x - 50, gameObject.transform.position.y, gameObject.transform.position.z);
            }
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
        buyColor = new Color(1, 1, 1);
        position = 160;
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
            position+= 230;
        }
        position = 160;
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
            position += 230;
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
                if (i == SaveReader.gunIndex)
                {
                    btn.transform.GetChild(0).GetComponent<Text>().text = " ";
                    btn.GetComponent<Image>().enabled = false;
                }
                else
                {
                    btn.transform.GetChild(0).GetComponent<Text>().text = "Buy";
                    btn.GetComponent<Image>().enabled = true;
                }
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(delegate { sm.BuyClick(gun, gun.id); });
                btn.GetComponent<Image>().color = buyColor;
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
                if (i == SaveReader.bodyIndex)
                {
                    btn.transform.GetChild(0).GetComponent<Text>().text = " ";
                    btn.GetComponent<Image>().enabled = false;
                }
                else
                {
                    btn.transform.GetChild(0).GetComponent<Text>().text = "Buy";
                    btn.GetComponent<Image>().enabled = true;
                }
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(delegate { sm.BuyClick(body, body.id); });
                btn.GetComponent<Image>().color = buyColor;
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
