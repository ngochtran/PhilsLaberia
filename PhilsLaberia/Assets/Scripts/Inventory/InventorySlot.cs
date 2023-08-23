using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
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
        // Find description components
        descriptionTitle = GameObject.Find("Item Name").GetComponent<TextMeshProUGUI>();
        descriptionText = GameObject.Find("Item Description").GetComponent<TextMeshProUGUI>();
        itemImage = GameObject.Find("Item Image").GetComponent<Image>();
        
        // Makes slots initally not targetable
        icon.raycastTarget = false;

        // Set initial alpha values
        itemImage.color = normalColor;
        descriptionTitle.alpha = 0f;
        descriptionText.alpha = 0f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
        ClearSlot();
        SoundEffects.instance.playPop();
    }

    /* On Hover: if there is an item, display item information */
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

    /* Remove hover: make description hidden */
    public void OnPointerExit(PointerEventData eventData)
    {
        itemImage.color = normalColor;
        descriptionTitle.alpha = 0f;
        descriptionText.alpha = 0f;
    }

    /* When drop item: swaps item with each other and updates item information on each slot */
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
            if (item != null)
            {
                targetSlot.ClearSlot();
                targetSlot.AddItem(originalItem);

                originalSlot.ClearSlot();
                originalSlot.AddItem(targetItem);
                originalSlot.itemButton.interactable = targetButton;
                targetSlot.itemButton.interactable = originalButton;
                SoundEffects.instance.playPop();
            } else
            {
                originalSlot.ClearSlot();
                targetSlot.AddItem(originalItem);
                SoundEffects.instance.playPop();
            }
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
