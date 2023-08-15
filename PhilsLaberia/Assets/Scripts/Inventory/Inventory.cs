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

    public delegate void OnItemChanged(Item item);
    public OnItemChanged onItemChangedCallback;

    public int space = 12;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        // Not Enough Space to Add Item
        if (items.Count >= space)
        {
            return false;
        }

        // Add Item if Enough Space
        items.Add(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke(item);
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        //if (onItemChangedCallback != null)
            //onItemChangedCallback.Invoke();
    }
}