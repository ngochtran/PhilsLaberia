using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : Interactable
{
    [SerializeField]
    private Item compatibleItem;

    [SerializeField]
    private Item returnedItem;

    private Item currentlyEquipped;

    public override void Interact()
    {
        // Get the equipped item from EquippedItem script
        currentlyEquipped = EquippedItem.instance.GetEquippedItem();

        if (currentlyEquipped == compatibleItem)
        {
            // Dispense the returned item
            EquippedItem.instance.ChangeItem(returnedItem);

            if (currentlyEquipped.id == "70")
            {
                SoundEffects.instance.playIce();
            }
            else if (currentlyEquipped.id == "0")
            {
                SoundEffects.instance.playWater();
            }
        }
    }
}
