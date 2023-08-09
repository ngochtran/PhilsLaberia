using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion  

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 12;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        // Not Enough Space to Add Item
        if (items.Count >= space)
        {
            return false;
        }

        // Add Item if Enought Space
        items.Add(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void MoveItem(Item item, int targetIndex)
    {
        int currentIndex = items.IndexOf(item);
        if (currentIndex >= 0)
        {
            items[currentIndex] = items[targetIndex];
            items[targetIndex] = item;
            onItemChangedCallback?.Invoke();
        }
    }
}
