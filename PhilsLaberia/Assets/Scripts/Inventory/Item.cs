using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public string description;
    public Sprite icon;

    public bool isPlaceable = false;

    public virtual void Use()
    {
        EquippedItem.instance.Equip(this);
        RemoveFromInventory();

    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
