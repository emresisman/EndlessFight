using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerStats_SO playerDefinition;

    public PlayerStats()
    {

    }

    void Start()
    {
        if (!playerDefinition.setManually)
        {
            playerDefinition.playerLevel = 1;
            playerDefinition.playerExperience = 0;

            playerDefinition.maxHealth = 50;
            playerDefinition.currentHealth = 50;

            playerDefinition.BaseDamage = 2;
            playerDefinition.currentDamage = playerDefinition.BaseDamage;

            playerDefinition.baseResistance = 0;
            playerDefinition.currentResistance = 0;
        }
    }
}
