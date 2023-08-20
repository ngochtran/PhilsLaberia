using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MachineSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private Button itemButton;

    private Item item;

    public Slider slider;

    private float timer; // Timer for scaling the slider
    private float timeCycle; // Time cycle from the Machine script

    private Machine machine;

    private bool timerRunning = false;

    private RecipeManager recipeManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory.instance.Add(item);
        machine.DecreaseNumSlots();
        machine.CheckTimerCondition();
        Destroy(gameObject);
    }

    public void InitializeSlot(Item newItem, float cycleTime, Machine parentMachine, RecipeManager manager)
    {
        recipeManager = manager;

        machine = parentMachine;

        item = newItem;

        Color newColor = icon.color; // Get the current color
        newColor.a = 1.0f; // Set the alpha value to 1 for full opacity
        icon.color = newColor; // Apply the updated color

        icon.sprite = item.icon;
        icon.enabled = true;
        itemButton.interactable = true;

        timeCycle = cycleTime; // Store the time cycle from the Machine script

        timer = 0; // Reset the timer
        slider.value = 0; // Reset the slider value
    }

    private void Update()
    {
        if (item != null && timerRunning)
        {
            if (timer < timeCycle)
            {
                timer += Time.deltaTime; // Increment the timer
                slider.value = timer / timeCycle; // Scale the slider based on the timer progress
            }
            else
            {
                timerRunning = false;
                slider.fillRect.gameObject.SetActive(false);
                OnTimerComplete();
            }
        }
    }

    private void OnTimerComplete()
    {
        // Change the item and its corresponding image
        Item craftedItem = recipeManager.retrieveCraftedItem(item.id); // Get the crafted item from the recipe manager
        if (craftedItem != null)
        {
            item = craftedItem; // Update the item
            icon.sprite = item.icon; // Update the icon image
        }
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void PauseTimer()
    {
        timerRunning = false;
    }
}
