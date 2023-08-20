using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
    public string id;
    public string itemName;
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
