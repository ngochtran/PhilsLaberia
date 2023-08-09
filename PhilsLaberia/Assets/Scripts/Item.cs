using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public string description;
    public Sprite icon;

    public virtual void Use()
    {
        Debug.Log("Using");
    }
}
