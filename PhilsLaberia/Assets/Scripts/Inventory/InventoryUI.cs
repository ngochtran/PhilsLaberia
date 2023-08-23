using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform itemGrid;
    
    [SerializeField]
    private GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemGrid.GetComponentsInChildren<InventorySlot>();

        if (inventory.items.Count > 0)
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if (inventory.items[i] != null)
                {
                    slots[i].AddItem(inventory.items[i]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            SoundEffects.instance.playMenu();
        }
    }

    void UpdateUI(Item item)
    {
        for (int i = 0; i < slots.Length; i++) 
        { 
            if (slots[i].item == null)
            {
                slots[i].AddItem(item);
                break;
            }
        }
    }
}
