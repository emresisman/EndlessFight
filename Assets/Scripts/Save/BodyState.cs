using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyData", menuName = "ItemAdd/BodyAdd", order = 2)]
public class BodyState : ScriptableObject
{
    public new string name;
    public int cost;
    public int health;
    public float movementSpeed;
}
