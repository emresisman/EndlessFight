using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveReader : MonoBehaviour
{
    public static int money;
    public static int highScore;
    public static int level;
    public static int experience;
    public static int damage;
    public static int health;
    public static float speed;
    public static float bulletSpeed;
    public static float fireRate;
    public static int gunIndex;
    public static int bodyIndex;

    public static void Load(GunState gunState, BodyState bodyState, SaveState saveState)
    {
        DetectGun(gunState);
        DetectBody(bodyState);
        money = saveState.cost;
        highScore = saveState.highScore;
        level = saveState.level;
        experience = saveState.experience;
        damage = saveState.baseDamage + gunState.damage[gunIndex];
        health = saveState.baseHealth + bodyState.health[bodyIndex];
        speed = bodyState.movementSpeed[bodyIndex];
        bulletSpeed = gunState.bulletSpeed[gunIndex];
        fireRate = gunState.fireRate[gunIndex];
    }

    static void DetectGun(GunState gunState)
    {
        for (int i = 0; i < gunState.isUse.Length; i++)
        {
            if (gunState.isUse[i])
            {
                gunIndex = i;
            }
        }
    }

    static void DetectBody(BodyState bodyState)
    {
        for (int i = 0; i < bodyState.isUse.Length; i++)
        {
            if (bodyState.isUse[i])
            {
                bodyIndex = i;
            }
        }
    }
}
