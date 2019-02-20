using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text _money;

    void Start()
    {
        _money.text = SaveReader.money.ToString();
    }
}