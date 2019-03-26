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
    public Image gunPrefab, bodyPrefab;
    public Image gunPanel, bodyPanel;
    public GameObject popUpGun, popUpBody;
    private Color useColor, buyColor;
    public SceneManager sm;
    public Button gun, body;

    internal void PopGun(bool v, GameObject gameObject)
    {
        if (v)
        {
            if (Camera.main.ScreenToWorldPoint(gameObject.transform.position).x < 0)
            {

                popUpGun.transform.position = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z);
                //popUpGun.transform.position = gameObject.transform.position;
            }
            else
            {
                popUpGun.transform.position = new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y, gameObject.transform.position.z);
                //popUpGun.transform.position = gameObject.transform.position;
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
            if (Camera.main.ScreenToWorldPoint(gameObject.transform.position).x < 0)
            {
                popUpBody.transform.position = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                popUpBody.transform.position = new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y, gameObject.transform.position.z);
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
        Func<string> greet = () => "Hello, World!";
        Debug.Log(greet);
        useColor = new Color(0.5f, 1f, 0.5f);
        buyColor = new Color(1, 1, 1);
        //position = 280;
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
            Image gunitem = Instantiate(gunPrefab, gunPanel.transform.GetChild(0).transform.GetChild(0).transform);
            buyButtonWeapon[i] = gunitem;
            FillSpecsGun(gunitem, gun, i);
            //gunitem.rectTransform.anchoredPosition = new Vector3(position, 0, 0);
            /*gunitem.GetComponent<MarketItemClickAction>().isGun = true;
            gunitem.GetComponent<MarketItemClickAction>().nameGun = gun.name;
            gunitem.GetComponent<MarketItemClickAction>().damage = gun.damage;
            gunitem.GetComponent<MarketItemClickAction>().fireRate = gun.fireRate;
            gunitem.GetComponent<MarketItemClickAction>().bulletSpeed = (int)gun.bulletSpeed;
            Text name = gunitem.transform.GetChild(0).GetComponent<Text>();
            Text cost = gunitem.transform.GetChild(3).GetComponent<Text>();
            Image sprite = gunitem.transform.GetChild(1).GetComponent<Image>();      
            cost.text = gun.cost.ToString();
            name.text = gun.name;
            sprite.sprite = SaveReader.gunSprites[i];*/
            //position+= 460;
        }
        //position = 280;
        for (int i = 0; i < buyButtonBody.Length; i++)
        {
            BodyState body = SaveReader.bodies[i];
            Image bodyitem = Instantiate(bodyPrefab, bodyPanel.transform.GetChild(0).transform.GetChild(0).transform);
            buyButtonBody[i] = bodyitem;
            FillSpecsBody(bodyitem, body, i);
            //gunitem.rectTransform.anchoredPosition = new Vector3(position, 0, 0);
            /*bodyitem.GetComponent<MarketItemClickAction>().isGun = false;
            bodyitem.GetComponent<MarketItemClickAction>().nameBody = body.name;
            bodyitem.GetComponent<MarketItemClickAction>().health = body.health;
            bodyitem.GetComponent<MarketItemClickAction>().speed = (int)body.movementSpeed;
            Text name = bodyitem.transform.GetChild(0).GetComponent<Text>();
            Text cost = bodyitem.transform.GetChild(3).GetComponent<Text>();
            Image sprite = bodyitem.transform.GetChild(1).GetComponent<Image>();
            cost.text = body.cost.ToString();
            name.text = body.name;
            sprite.sprite = SaveReader.bodySprites[i];*/
            //position += 460;
        }
        //gunPanel.color = new Color(0f, 0.5490f, 1f, 0.65f);
        //bodyPanel.color = new Color(0f, 0.5490f, 1f, 0.25f);
        ChangeActivityBody(false);
        ChangeActivityGun(true);
    }

    void FillSpecsGun(Image item, GunState gun, int index)
    {
        Text name = item.transform.GetChild(0).GetComponent<Text>();
        Text cost = item.transform.GetChild(3).GetComponent<Text>();
        Text damage = item.transform.GetChild(5).GetComponent<Text>();
        Text firerate = item.transform.GetChild(6).GetComponent<Text>();
        Text bulletspeed = item.transform.GetChild(7).GetComponent<Text>();
        Image sprite = item.transform.GetChild(1).GetComponent<Image>();
        name.text = gun.name;
        cost.text = gun.cost.ToString();
        damage.text = "Damage : " + gun.damage.ToString();
        firerate.text = "Fire Rate : " + gun.fireRate.ToString();
        bulletspeed.text="Bullet Speed : " + gun.bulletSpeed.ToString();
        sprite.sprite = SaveReader.gunSprites[index];
    }



    void FillSpecsBody(Image item, BodyState body, int index)
    {
        Text name = item.transform.GetChild(0).GetComponent<Text>();
        Text cost = item.transform.GetChild(3).GetComponent<Text>();
        Text health = item.transform.GetChild(5).GetComponent<Text>();
        Text speed = item.transform.GetChild(6).GetComponent<Text>();
        Image sprite = item.transform.GetChild(1).GetComponent<Image>();
        name.text = body.name;
        cost.text = body.cost.ToString();
        health.text = "Health : " + body.health.ToString();
        speed.text = "Speed : " + body.movementSpeed.ToString();
        sprite.sprite = SaveReader.bodySprites[index];
    }

    public void ChangeActivityBody(bool value)
    {
        if (value)
        {
            body.GetComponent<Image>().color = new Color(0f, 0.5490f, 1f, 1f);
            gun.GetComponent<Image>().color = new Color(0f, 0.5490f, 1f, 0.6980f);
            bodyPanel.gameObject.transform.SetSiblingIndex(2);
            gunPanel.color = new Color(0f, 0.5490f, 1f, 0.25f);
            bodyPanel.color = new Color(0f, 0.5490f, 1f, 0.65f);
        }
        else
        {
            bodyPanel.gameObject.transform.SetSiblingIndex(1);
            gunPanel.color = new Color(0f, 0.5490f, 1f, 0.65f);
            bodyPanel.color = new Color(0f, 0.5490f, 1f, 0.25f);
        }
        foreach (Image child in buyButtonBody)
        {
            child.gameObject.SetActive(value);
        }
    }

    public void ChangeActivityGun(bool value)
    {
        if (value)
        {
            gun.GetComponent<Image>().color = new Color(0f, 0.5490f, 1f, 1f);
            body.GetComponent<Image>().color = new Color(0f, 0.5490f, 1f, 0.6980f);
            gunPanel.gameObject.transform.SetSiblingIndex(2);
            gunPanel.color = new Color(0f, 0.5490f, 1f, 0.65f);
            bodyPanel.color = new Color(0f, 0.5490f, 1f, 0.25f);
        }
        else
        {
            gunPanel.gameObject.transform.SetSiblingIndex(1);
            gunPanel.color = new Color(0f, 0.5490f, 1f, 0.25f);
            bodyPanel.color = new Color(0f, 0.5490f, 1f, 0.65f);
        }
        foreach (Image child in buyButtonWeapon)
        {
            child.gameObject.SetActive(value);
        }
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
