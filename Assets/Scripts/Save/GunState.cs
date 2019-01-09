using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "ItemAdd/GunAdd", order = 1)]
public class GunState : ScriptableObject
{
    public new string[] name = { "stock gun", "first gun", "second gun" };
    public int[] cost = { 0, 30, 80 };
    public int[] damage = { 2, 4, 10 };
    public float[] fireRate = { 0.4f, 0.4f, 0.3f };
    public float[] bulletSpeed = { 1000, 1040, 1200 };
    public bool[] isLocked = { false, true, true };
    public bool[] isUse = { true, false, false };
}
