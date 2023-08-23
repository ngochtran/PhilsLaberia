using System.Collections.Generic;
using UnityEngine;

public class Machine : Interactable
{

    [SerializeField]
    private SpriteRenderer machineSpriteRenderer;

    private Sprite originalSprite;

    [SerializeField]
    private Sprite finalSprite; // Reference to the final sprite if any

    [SerializeField]
    private Transform machineSlotParent; // Reference to the parent transform for machine slots

    [SerializeField]
    private MachineSlot machineSlotPrefab; // Reference to the prefab of the machine slot UI

    [SerializeField]
    private float timeCycle = 10.0f;

    [SerializeField]
    private int maxObjects = 4;

    [SerializeField]
    private int multiplier = 1;

    [SerializeField]
    private List<Item> compatibleItems = new List<Item>();

    [SerializeField]
    private RecipeManager recipeManager;

    public int numSlots = 0;

    private void Awake()
    {
        originalSprite = machineSpriteRenderer.sprite;
    }

    public override void Interact()
    {
        Item equippedItem = EquippedItem.instance.GetEquippedItem();

        if (equippedItem != null && compatibleItems.Contains(equippedItem) && numSlots < maxObjects)
        {
            EquippedItem.instance.RemoveFromEquipped();
            CreateMachineSlot(equippedItem);
            numSlots++;

            CheckTimerCondition();
        }
    }

    private void StartAllTimers()
    {
        MachineSlot[] slots = machineSlotParent.GetComponentsInChildren<MachineSlot>();
        foreach (MachineSlot slot in slots)
        {
            slot.StartTimer();
        }
    }

    private void PauseAllTimers()
    {
        MachineSlot[] slots = machineSlotParent.GetComponentsInChildren<MachineSlot>();
        foreach (MachineSlot slot in slots)
        {
            slot.PauseTimer();
        }
    }

    private void CreateMachineSlot(Item item)
    {
        MachineSlot newSlot = Instantiate(machineSlotPrefab, machineSlotParent);
        newSlot.InitializeSlot(item, timeCycle, this, recipeManager);
    }

    public void DecreaseNumSlots()
    {
        numSlots--;
    }

    public void CheckTimerCondition()
    {
        if (numSlots % multiplier == 0 && numSlots > 0)
        {
            StartAllTimers();
            ChangeMachineSprite(finalSprite); // Change sprite to the final sprite
        }
        else
        {
            PauseAllTimers();
            ChangeMachineSprite(originalSprite);
        }
    }

    private void ChangeMachineSprite(Sprite newSprite)
    {
        if (machineSpriteRenderer != null && newSprite != null)
        {
            machineSpriteRenderer.sprite = newSprite;
        }
    }

}
