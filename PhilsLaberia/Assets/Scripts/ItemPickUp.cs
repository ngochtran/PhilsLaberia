using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickUp : Interactable
{
    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        Destroy(gameObject);
    }
}
