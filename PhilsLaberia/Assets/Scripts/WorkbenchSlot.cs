using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorkbenchSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public Item item;
    public Image icon;
    public Button itemButton;
    public TextMeshProUGUI itemName;

    public CraftingManager craftingSystemManager;

    void Start()
    {
        itemButton.interactable = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            Inventory.instance.Add(item);
            craftingSystemManager.CraftRemove(item);
            CraftClearSlot();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            Transform originalParent = draggableItem.parentAfterDrag;
            Transform craftingParent = transform;

            // Store Information from originalParent 
            InventorySlot originalSlot = originalParent.GetComponent<InventorySlot>();
            Item originalItem = originalSlot.item;

            //Store Information from craftingSlot 
            WorkbenchSlot craftingSlot = craftingParent.GetComponent<WorkbenchSlot>();

            // Check if the target slot is empty
            bool targetSlotEmpty = (craftingParent.childCount == 0);

            // If the crafting slot is empty, then add item into slot 
            if (item == null)
            {
                craftingSystemManager.CraftAdd(originalItem);
                CraftAddItem(originalItem);
                Inventory.instance.Remove(originalItem);
                originalSlot.ClearSlot();


            } else {
                // If the crafting slot is not empty, return the item to inventory
                originalSlot.AddItem(originalItem);
            }
        }
    }

    private void CraftAddItem(Item newItem)
    {
        item = newItem;

        itemName.text = item.itemName;  
        icon.sprite = item.icon;
        icon.enabled = true;
        itemButton.interactable = true;
        icon.raycastTarget = true;
    }

    public void CraftClearSlot()
    {
        item = null;

        itemName.text = "";
        icon.sprite = null;
        icon.enabled = false;
        itemButton.interactable = false;
        icon.raycastTarget = false;

    }

}