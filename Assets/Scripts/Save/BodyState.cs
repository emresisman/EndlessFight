using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BodyData",menuName ="Add Data/Body Data",order =1)]
[System.Serializable]
public class BodyState : ScriptableObject
{
    public int id;
    public string name;
    public int cost;
    public int health;
    public float movementSpeed;
    public bool isLocked;
}
