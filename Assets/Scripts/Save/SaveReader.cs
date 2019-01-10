﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveReader
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

    public static void Load(SaveState saveState)
    {
        GunState[] guns = Resources.LoadAll<GunState>("DataFiles/Guns");
        BodyState[] bodies = Resources.LoadAll<BodyState>("DataFiles/Bodies");
        money = saveState.cost;
        highScore = saveState.highScore;
        level = saveState.level;
        experience = saveState.experience;
        damage = saveState.baseDamage + guns[saveState.gunID].damage;
        Debug.Log(saveState.gunID);
        Debug.Log(damage);
        health = saveState.baseHealth + bodies[saveState.bodyID].health;
        speed = bodies[saveState.bodyID].movementSpeed;
        bulletSpeed = guns[saveState.gunID].bulletSpeed;
        fireRate = guns[saveState.gunID].fireRate;
    }
}
