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
}
