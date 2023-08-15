using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquippedItem : MonoBehaviour
{
    #region Singleton
    public static EquippedItem instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

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
            bool notFull = Inventory.instance.Add(equippedItem); // Return the equipped item to inventory
            if (notFull)
            {
                equippedItem = null; // Clear the equipped item
                equippedItemImage.sprite = null; // Update the button's image to reflect no equipped item
                itemCarrying.SetActive(false);
            } 
        }
    }

    public void Equip(Item item)
    {
        if (equippedItem == null)
        {
            equippedItem = item;
        }
        else
        {
            Inventory.instance.Add(equippedItem);
            equippedItem = item;
        }

        equippedItemImage.sprite = equippedItem.icon;

        // Get the SpriteRenderer component attached to the itemCarrying GameObject
        SpriteRenderer itemCarryingSpriteRenderer = itemCarrying.GetComponent<SpriteRenderer>();

        itemCarryingSpriteRenderer.sprite = equippedItem.icon; // Set the sprite of the SpriteRenderer
        itemCarrying.SetActive(true);
    }

}

