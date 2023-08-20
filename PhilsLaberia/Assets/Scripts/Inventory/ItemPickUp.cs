using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    private void OnMouseDown()
    {
        PickUp();
    }

    void PickUp()
    {
        Machine machine = GetComponentInParent<Machine>(); // Get the parent Machine component
        if (machine != null && machine.numSlots == 0) // Check if numSlots is 0
        {
            if (EquippedItem.instance.GetEquippedItem() == null)
            {
                EquippedItem.instance.Equip(item);
                Destroy(gameObject);
            }
        }
    }
}