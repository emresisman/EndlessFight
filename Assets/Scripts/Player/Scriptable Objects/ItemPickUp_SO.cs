using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeDefininitons { GUN, ARMOR};

[CreateAssetMenu(fileName = "NewItem", menuName = "Spawnable Item/New Pick Up", order = 1)]
public class ItemPickUp_SO : ScriptableObject
{
    public ItemTypeDefininitons itemType = ItemTypeDefininitons.GUN;
    public string itemName;
    public int resistance = 0;
    public int health = 0;
    public int damage = 5;
}
