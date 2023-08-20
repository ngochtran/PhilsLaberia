using UnityEngine;
using UnityEngine.UI;

public class EquippedItem : MonoBehaviour
{
    public static EquippedItem instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    private Button equippedItemButton;

    [SerializeField]
    private GameObject itemCarrying;

    public Item equippedItem;

    [SerializeField]
    private Image equippedItemImage;

    private void Start()
    {
        equippedItemButton.onClick.AddListener(OnEquippedButtonClick);
    }

    private void OnEquippedButtonClick()
    {
        if (equippedItem != null)
        {
            bool notFull = Inventory.instance.Add(equippedItem); // Assuming Inventory.instance.Add() returns a bool
            if (notFull)
            {
                RemoveFromEquipped();
            }
        }
    }

    public void RemoveFromEquipped()
    {
        equippedItem = null;
        equippedItemImage.sprite = null;
        itemCarrying.SetActive(false);
    }

    public void Equip(Item item)
    {
        if (equippedItem != null)
        {
            Inventory.instance.Add(equippedItem); // Assuming Inventory.instance.Add() adds the item to the inventory
        }

        equippedItem = item;
        equippedItemImage.sprite = equippedItem.icon;

        SpriteRenderer itemCarryingSpriteRenderer = itemCarrying.GetComponent<SpriteRenderer>();

        itemCarryingSpriteRenderer.sprite = equippedItem.icon;
        itemCarrying.SetActive(true);
    }

    public void ChangeItem(Item newItem)
    {
        equippedItem = newItem;
        equippedItemImage.sprite = equippedItem.icon;

        SpriteRenderer itemCarryingSpriteRenderer = itemCarrying.GetComponent<SpriteRenderer>();

        itemCarryingSpriteRenderer.sprite = equippedItem.icon;
    }

    public Item GetEquippedItem()
    {
        return equippedItem;
    }
}
