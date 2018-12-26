using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "ItemAdd/GunAdd", order = 1)]
public class GunState : ScriptableObject
{
    public new string name;
    public int cost;
    public int damage;
    public float fireRate;
    public float bulletSpeed;
    public bool locked;
}
