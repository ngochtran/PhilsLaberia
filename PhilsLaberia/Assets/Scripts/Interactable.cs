using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Interactable : MonoBehaviour
{
    public bool isCounter = false;

    // Ensures box collider is a trigger so trigger-based functions work
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();

    // On collision event, if collision is with player, it will show icon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && (!isCounter))
            collision.GetComponent<PlayerController>().OpenInteractableIcon();
    }

    // On collision event exit, if collision is with player, it will close icon
    private void OnTriggerExit2D (Collider2D collision)
    {
       if (collision.CompareTag("Player") && (!isCounter))
            collision.GetComponent<PlayerController>().CloseInteractableIcon();
    }
}
