using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static int gunCount;
    public static int bodyCount;
    public static GunState[] guns;
    public static BodyState[] bodies;
    public static Sprite[] gunSprites;
    public static Sprite[] bodySprites;

    public static void Load(SaveState saveState)
    {
        gunSprites = Resources.LoadAll<Sprite>("Sprites/UI/Guns");
        bodySprites = Resources.LoadAll<Sprite>("Sprites/UI/Body");
        gunCount = guns.Length;
        bodyCount = bodies.Length;
        money = saveState.cost;
        highScore = saveState.highScore;
        level = saveState.level;
        experience = saveState.experience;
        damage = saveState.baseDamage + guns[saveState.gunID].damage;
        health = saveState.baseHealth + bodies[saveState.bodyID].health;
        speed = bodies[saveState.bodyID].movementSpeed;
        bulletSpeed = guns[saveState.gunID].bulletSpeed;
        fireRate = guns[saveState.gunID].fireRate;
    }

    public static void LoadGun(GunState[] gunState)
    {
        guns = gunState;
    }

    public static void LoadBody(BodyState[] bodyState)
    {
        bodies = bodyState;
    }

    void SetHealth(int health)
    {
        PlayerMovement pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        pm.Health = health;
    }
}
