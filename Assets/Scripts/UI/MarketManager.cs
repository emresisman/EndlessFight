using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    int money, position;
    int[] buyButtonWeapon, buyButtonBody;
    public Text moneyText, gunName;
    public Image itemPrefab;
    public GameObject gunPanel, bodyPanel;

    void Start()
    {
        position = 135;
        buyButtonWeapon = new int[SaveReader.gunCount];
        buyButtonBody = new int[SaveReader.bodyCount];
        money = SaveReader.money;
        moneyText.text = SaveReader.money.ToString();
        OnLoad();
    }

    void OnLoad()
    {
        //Visualization
        for (int i = 0; i < buyButtonWeapon.Length; i++)
        {
            Image gunitem = Instantiate(itemPrefab, gunPanel.transform);
            gunitem.rectTransform.anchoredPosition = new Vector3(position, 0, 0);
            Text name = gunitem.transform.GetChild(0).GetComponent<Text>();
            Text cost = gunitem.transform.GetChild(4).GetComponent<Text>();
            cost.text = SaveReader.guns[i].cost.ToString();
            name.text = SaveReader.guns[i].name;
            position+= 235;
        }
        position = 135;
        for (int i = 0; i < buyButtonBody.Length; i++)
        {
            Image gunitem = Instantiate(itemPrefab, bodyPanel.transform);
            gunitem.rectTransform.anchoredPosition = new Vector3(position, 0, 0);
            Text name = gunitem.transform.GetChild(0).GetComponent<Text>();
            Text cost = gunitem.transform.GetChild(4).GetComponent<Text>();
            cost.text = SaveReader.bodies[i].cost.ToString();
            name.text = SaveReader.bodies[i].name;
            position += 235;
        }
    }
}
