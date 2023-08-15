using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class StorageSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image displayedIcon;
    public Button itemButton;

    private TextMeshProUGUI descriptionTitle;
    private TextMeshProUGUI descriptionText;
    private Image itemImage;

    private Color normalColor = new Color(1f, 1f, 1f, 0f); // Transparent color
    private Color highlightedColor = new Color(1f, 1f, 1f, 1f); // Fully opaque color

    void Start()
    {
        // Find description components
        descriptionTitle = GameObject.Find("Drawer Item Name").GetComponent<TextMeshProUGUI>();
        descriptionText = GameObject.Find("Drawer Item Description").GetComponent<TextMeshProUGUI>();
        itemImage = GameObject.Find("Drawer Item Image").GetComponent<Image>();

        // Set initial alpha values
        itemImage.color = normalColor;
        descriptionTitle.alpha = 0f;
        descriptionText.alpha = 0f;
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

    void Awake()
    {
        if (item != null)
        {
            displayedIcon.sprite = item.icon;
        } else
        {
            itemButton.interactable = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            Inventory.instance.Add(item);
        }
    }
}