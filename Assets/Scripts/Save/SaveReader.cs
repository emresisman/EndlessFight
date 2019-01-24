using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveReader
{
    //SaveState
    public static SaveState save;
    public static int money;
    public static int highScore;
    public static int level;
    public static int experience;
    public static int gunIndex;
    public static int bodyIndex;

    //GunState
    public static float bulletSpeed;
    public static float fireRate;

    //BodyState
    public static float speed;
    
    //Other
    public static int gunCount;
    public static int bodyCount;
    public static GunState[] guns;
    public static BodyState[] bodies;
    public static Sprite[] gunSprites;
    public static Sprite[] bodySprites;
    public static int damage;
    public static int health;

    public static void Load(SaveState saveState)
    {
        save = saveState;
        Load();
    }

    public static void Load()
    {
        gunSprites = Resources.LoadAll<Sprite>("Sprites/UI/Guns");
        bodySprites = Resources.LoadAll<Sprite>("Sprites/UI/Body");
        gunIndex = guns[save.gunID].id;
        bodyIndex = bodies[save.bodyID].id;
        gunCount = guns.Length;
        bodyCount = bodies.Length;
        money = save.cost;
        highScore = save.highScore;
        level = save.level;
        experience = save.experience;
        damage = save.baseDamage + guns[save.gunID].damage;
        health = save.baseHealth + bodies[save.bodyID].health;
        speed = bodies[save.bodyID].movementSpeed;
        bulletSpeed = guns[save.gunID].bulletSpeed;
        fireRate = guns[save.gunID].fireRate;
    }

    public static void LoadGun(GunState[] gunState)
    {
        guns = gunState;
    }

    public static void LoadBody(BodyState[] bodyState)
    {
        bodies = bodyState;
    }

    public static int GetHealth()
    {
        return health;
    }

    public static SaveState ReturnSave()
    {
        save.cost = money;
        save.highScore = highScore;
        save.level = level;
        save.experience = experience;
        save.gunID = gunIndex;
        save.bodyID = bodyIndex;
        return save;
    }
}
