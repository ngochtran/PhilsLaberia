using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CraftingManager : MonoBehaviour
{
    public List<Item> craftingSet = new List<Item>();

    public event Action<List<Item>> OnCraftingSetChanged;

    public void CraftAdd(Item item)
    {
        craftingSet.Add(item);
        OnCraftingSetChanged?.Invoke(craftingSet);
    }

    public void CraftRemove(Item item)
    {
        craftingSet.Remove(item);
        OnCraftingSetChanged?.Invoke(craftingSet);
    }

    public void ClearCraftingSet()
    {
        craftingSet.Clear();
        OnCraftingSetChanged?.Invoke(craftingSet);
    }

}
