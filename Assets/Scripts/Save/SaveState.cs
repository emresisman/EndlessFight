using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SaveData",menuName ="SaveData",order =1)]
public class SaveState : ScriptableObject
{
    public int cost = 0;
    public int highScore = 0;
    public int experience = 0;
    public int level = 1;
    public int baseDamage = 1;
    public int baseHealth = 5;
    public int baseSpeed = 6;
    public int currentDamage = 1;
    public int currentHealth = 5;
    public int currentSpeed = 6;
    public string currentGun = "Gun1";
    public string currentBody = "Body1";
}
