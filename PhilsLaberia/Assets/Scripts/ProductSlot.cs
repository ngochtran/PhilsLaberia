using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ProductSlot : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public Image icon;
    public Button itemButton;
    public TextMeshProUGUI itemName;

    public CraftingManager craftingManager;
    public RecipeManager recipeManager;

    public WorkbenchSlot[] craftingSlots;


    private void Start()
    {
        craftingManager.OnCraftingSetChanged += UpdateProductSlot;
        itemButton.interactable = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            Inventory.instance.Add(item);
            craftingManager.ClearCraftingSet();
            ProductClearSlot();
            ClearAllCraftingSlots();

        }
    }

    private void ClearAllCraftingSlots()
    {
        foreach (WorkbenchSlot craftingSlot in craftingSlots)
        {
            craftingSlot.CraftClearSlot();
        }

    }

    private void UpdateProductSlot(List<Item> craftingSet)
    {
        string sortedItemNames = recipeManager.sortAndConcatenate(craftingSet);
        Item craftedItem = recipeManager.retrieveCraftedItem(sortedItemNames);

        if (craftedItem != null)
        {
            ProductAddItem(craftedItem);
        } else
        {
            ProductClearSlot();
        }
    }

    private void ProductAddItem(Item newItem)
    {
        item = newItem;

        itemName.text = item.itemName;
        icon.sprite = item.icon;
        icon.enabled = true;
        itemButton.interactable = true;

    }

    private void ProductClearSlot()
    {
        item = null;

        itemName.text = "";
        icon.sprite = null;
        icon.enabled = false;
        itemButton.interactable = false;

    }


}