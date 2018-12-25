using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SaveData",menuName ="SaveData",order =1)]
public class SaveState : ScriptableObject
{
    public int Score = 0;
}
