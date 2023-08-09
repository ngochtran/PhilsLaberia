using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image icon;
    public Button itemButton;

    private TextMeshProUGUI descriptionTitle;
    private TextMeshProUGUI descriptionText;
    private Image itemImage;

    private Color normalColor = new Color(1f, 1f, 1f, 0f); // Transparent color
    private Color highlightedColor = new Color(1f, 1f, 1f, 1f); // Fully opaque color

    void Start()
    {
        descriptionTitle = GameObject.Find("Item Name").GetComponent<TextMeshProUGUI>();
        descriptionText = GameObject.Find("Item Description").GetComponent<TextMeshProUGUI>();
        itemImage = GameObject.Find("Item Image").GetComponent<Image>();
        icon.raycastTarget = false;

        // Set initial alpha values
        itemImage.color = normalColor;
        descriptionTitle.alpha = 0f;
        descriptionText.alpha = 0f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            descriptionTitle.text = item.itemName;
            descriptionText.text = item.description;
            itemImage.sprite = item.icon;

            itemImage.color = highlightedColor;
            descriptionTitle.alpha = 1f;
            descriptionText.alpha = 1f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemImage.color = normalColor;
        descriptionTitle.alpha = 0f;
        descriptionText.alpha = 0f;
    }
public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            Transform originalParent = draggableItem.parentAfterDrag;
            Transform targetParent = transform;

            // Store Information from originalParent 
            InventorySlot originalSlot = originalParent.GetComponent<InventorySlot>();
            Item originalItem = originalSlot.item;
            bool originalButton = originalSlot.itemButton.interactable;


            //Store Information from targetParent 
            InventorySlot targetSlot = targetParent.GetComponent<InventorySlot>();
            Item targetItem = targetSlot.item;
            bool targetButton = targetSlot.itemButton.interactable;

            // Check if the target slot is empty
            bool targetSlotEmpty = (targetParent.childCount == 0);

            // If the target slot is not empty, swap the items
            if (!targetSlotEmpty)
            {
                Transform existingItem = targetParent.GetChild(0); // Assuming only one child in each slot
                existingItem.SetParent(originalParent);
                existingItem.SetAsLastSibling();
                originalSlot.item = targetItem;
                targetSlot.item = originalItem;
                originalSlot.itemButton.interactable = targetButton;
                targetSlot.itemButton.interactable = originalButton;
            }

            // Set the new parent for the dragged item
            draggableItem.parentAfterDrag = targetParent;
            dropped.transform.SetParent(targetParent);
            dropped.transform.SetAsLastSibling();
        }
    }


    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        itemButton.interactable = true;
        icon.raycastTarget = true;

    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        itemButton.interactable = false;
        icon.raycastTarget = false;

    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
