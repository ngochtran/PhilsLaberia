using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryUI;

    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        SoundEffects.instance.playMenu();
    }
}
