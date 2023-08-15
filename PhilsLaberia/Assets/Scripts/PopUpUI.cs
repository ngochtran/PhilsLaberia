using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUpUI : Interactable
{
    public GameObject popUp;
    public PlayerController playerController;

    public override void Interact()
    {
        bool newPopUpState = !popUp.activeSelf;

        // Set the active state of the pop-up UI
        popUp.SetActive(newPopUpState);

        // Update the player's pop-up UI state and movement
        playerController.SetPopUpActive(newPopUpState);
    }
}