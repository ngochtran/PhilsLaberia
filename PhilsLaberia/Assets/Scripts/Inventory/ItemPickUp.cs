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
        if (item.id == "26" && machine != null && machine.numSlots == 0)
        {
            if (EquippedItem.instance.GetEquippedItem() == null)
            {
                EquippedItem.instance.Equip(item);
                Destroy(gameObject);
            }
        }
        else if (item.id == "70")
        {
            if (EquippedItem.instance.GetEquippedItem() == null)
            {
                EquippedItem.instance.Equip(item);
                Destroy(gameObject);
            }
        }
    }
}