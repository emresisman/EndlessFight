using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MarketItemClickAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private MarketManager mm;
    [HideInInspector]
    public bool isGun = true;
    [HideInInspector]
    public string nameGun;
    [HideInInspector]
    public string nameBody;
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public float fireRate;
    [HideInInspector]
    public int bulletSpeed;
    [HideInInspector]
    public int speed;
    [HideInInspector]
    public int health;

    private Text nameGunText, nameBodyText, damageText, fireRateText, bulletSpeedText, speedText, healthText;
    private GameObject popupgun, popupbody;

    private void Start()
    {
        mm = GameObject.Find("MarketManager").GetComponent<MarketManager>();
        popupgun = GameObject.Find("PopUpGun");
        popupbody = GameObject.Find("PopUpBody");
        nameGunText = popupgun.transform.GetChild(0).GetComponent<Text>();
        damageText = popupgun.transform.GetChild(1).GetComponent<Text>();
        fireRateText = popupgun.transform.GetChild(2).GetComponent<Text>();
        bulletSpeedText = popupgun.transform.GetChild(3).GetComponent<Text>();
        nameBodyText = popupbody.transform.GetChild(0).GetComponent<Text>();
        healthText = popupbody.transform.GetChild(1).GetComponent<Text>();
        speedText = popupbody.transform.GetChild(2).GetComponent<Text>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isGun)
        {
            mm.PopGun(true, this.gameObject);
            SetGunText();
        }
        else
        {
            mm.PopBody(true, this.gameObject);
            SetBodyText();
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isGun)
        {
            mm.PopGun(false, this.gameObject);
        }
        else
        {
            mm.PopBody(false, this.gameObject);
        }
    }

    public void SetGunText()
    {
        nameGunText.text = nameGun;
        damageText.text = "Damage : " + damage.ToString();
        fireRateText.text = "Fire Rate : " + fireRate.ToString();
        bulletSpeedText.text = "Bullet Speed : " + bulletSpeed.ToString();
    }

    public void SetBodyText()
    {
        nameBodyText.text = nameBody;
        healthText.text = "Health : " + health.ToString();
        speedText.text = "Speed : " + speed.ToString();
    }
}
