using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : Interactable
{
    private Item currentlyEquipped;

    [SerializeField]
    private GameObject emptyIcePrefab;

    [SerializeField]
    private GameObject filledIcePrefab;

    [SerializeField]
    private float yOffset = 0;

    [SerializeField]
    private float xOffset = 0;

    public override void Interact()
    {
        // Get the equipped item from EquippedItem script
        currentlyEquipped = EquippedItem.instance.GetEquippedItem();
        if (currentlyEquipped != null && currentlyEquipped.isPlaceable)
        {
            Vector3 spawnPosition = CalculateSpawnPosition();

            if (currentlyEquipped.id == "70")
            {
                Instantiate(emptyIcePrefab, spawnPosition, Quaternion.identity);
            }
            if (currentlyEquipped.id == "26")
            {
                Instantiate(filledIcePrefab, spawnPosition, Quaternion.identity);
            }

            EquippedItem.instance.RemoveFromEquipped();
        }
    }

    private Vector3 CalculateSpawnPosition()
    {
        // Assuming the counter has a BoxCollider2D, get the size and center
        BoxCollider2D counterCollider = GetComponent<BoxCollider2D>();
        Vector3 counterCenter = counterCollider.bounds.center;
        Vector2 counterSize = counterCollider.size;

        // Calculate spawn position on the counter's surface
        Vector3 spawnPosition = counterCenter + new Vector3(0 + xOffset, (counterSize.y / 2) + yOffset, 0);

        spawnPosition.z = -1;

        return spawnPosition;
    }
}
