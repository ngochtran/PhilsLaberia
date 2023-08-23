using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public List<Item> craftingSet = new List<Item>();

    public event Action<List<Item>> OnCraftingSetChanged;

    public void CraftAdd(Item item)
    {
        craftingSet.Add(item);
        OnCraftingSetChanged?.Invoke(craftingSet);
        SoundEffects.instance.playPop();
    }

    public void CraftRemove(Item item)
    {
        craftingSet.Remove(item);
        OnCraftingSetChanged?.Invoke(craftingSet);
        SoundEffects.instance.playPop();
    }

    public void ClearCraftingSet()
    {
        craftingSet.Clear();
        OnCraftingSetChanged?.Invoke(craftingSet);
    }

}
