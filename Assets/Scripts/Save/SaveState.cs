using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveState
{
    public int cost = 0;
    public int highScore = 0;
    public int experience = 0;
    public int level = 1;
    public int baseDamage = 1;
    public int baseHealth = 5;
    public int gunID;
    public int bodyID;
}
