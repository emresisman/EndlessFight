using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Add Data/Gun Data", order = 1)]
[System.Serializable]
public class GunState : ScriptableObject
{
    public int id;
    public string name;
    public int cost;
    public int damage;
    public float fireRate ;
    public float bulletSpeed;
    public bool isLocked;
}
