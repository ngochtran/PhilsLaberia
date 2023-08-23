using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIn : Interactable
{
    [SerializeField]
    private Item finalProduct;

    private Item currentlyEquipped;

    [SerializeField]
    private GameObject winScreen;

    public AudioSource bgMusic;

    public override void Interact()
    {
        // Get the equipped item from EquippedItem script
        currentlyEquipped = EquippedItem.instance.GetEquippedItem();

        if (currentlyEquipped == finalProduct)
        {
            winScreen.SetActive(true);
            bgMusic.Stop();
            SoundEffects.instance.playClap();
        }
    }
}
