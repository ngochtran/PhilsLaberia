using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour
{
    public Transform itemGrid;
    public GameObject inventoryUI;
    /*
    Storage storage;

    StorageSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        storage.onItemChangedCallback += UpdateUI;

        slots = itemGrid.GetComponentsInChildren<StorageSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < storage.items.Count)
            {
                slots[i].AddItem(storage.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }*/
}
