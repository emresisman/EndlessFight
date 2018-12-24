using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats", order = 1)]
public class PlayerStats_SO : ScriptableObject
{
    [System.Serializable]
    public class CharLevelUps
    {
        public int maxHealth;
        public int baseDamage;
        public int baseResistance;
    }

    public ItemPickUps armor { get; private set; }
    public ItemPickUps gun { get; private set; }

    public bool setManually = false;
    public bool saveDataOnClose = false;

    public int maxHealth = 0;
    public int baseHealth = 0;
    public int currentHealth = 0;

    public int BaseDamage = 0;
    public int currentDamage = 0;

    public int baseResistance = 0;
    public int currentResistance = 0;

    public int playerExperience = 0;
    public int playerLevel = 0;

    public CharLevelUps[] charLevelUps;

    public void ApplyHealth(int healthAmount)
    {
        if ((currentHealth + healthAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }

    public void EquipGun(ItemPickUps gunPickUp)
    {
        //player üzerindeki sprite'lar değişecek
        gun = gunPickUp;
        currentDamage = BaseDamage + gunPickUp.itemDefinition.damage;
    }

    public void EquipArmor(ItemPickUps armorPickUp)
    {
        //player üzerindeki sprite'lar değişecek
        armor = armorPickUp;
        maxHealth = baseHealth + armorPickUp.itemDefinition.health;
        currentResistance = baseResistance + armorPickUp.itemDefinition.resistance;
    }
}
