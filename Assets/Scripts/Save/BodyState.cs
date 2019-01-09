using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyData", menuName = "ItemAdd/BodyAdd", order = 2)]
public class BodyState : ScriptableObject
{
    public new string[] name = { "stock body", "first body", "second body" };
    public int[] cost = { 0, 50, 10 };
    public int[] health = { 0, 10, 20 };
    public float[] movementSpeed = { 6, 6, 8 };
    public bool[] isLocked = { false, true, true };
    public bool[] isUse = { true, false, false };
}
