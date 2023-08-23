using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{

    public static Dialogue instance;

    public delegate void DialogueIndexChangedEventHandler(int newIndex);
    public event DialogueIndexChangedEventHandler OnDialogueIndexChanged;

    private int currentLine = 0;

    [TextArea(3, 30)]
    public string[] dialogues;

    [SerializeField]
    private TextMeshProUGUI textBox;

    [SerializeField]
    private Button nextButton;

    [SerializeField]
    private Button previousButton;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        ShowCurrentText();

        // Set up button click events
        nextButton.onClick.AddListener(ShowNextText);
        previousButton.onClick.AddListener(ShowPreviousText);
    }

    private void Update()
    {
        // Check for keyboard input
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShowPreviousText();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            ShowNextText();
        }
    }

    private void ShowCurrentText()
    {
        // Enable or disable buttons based on currentLine index
        nextButton.interactable = currentLine < dialogues.Length - 1;
        previousButton.interactable = currentLine > 0;

        if (currentLine >= 0 && currentLine < dialogues.Length)
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogues[currentLine]));
        }
    }

    private void ShowNextText()
    {
        SoundEffects.instance.playMenu();
        if (currentLine < dialogues.Length - 1)
        {
            currentLine++;
            ShowCurrentText();
            OnDialogueIndexChanged?.Invoke(currentLine);
        }
    }

    private void ShowPreviousText()
    {
        SoundEffects.instance.playMenu();
        if (currentLine > 0)
        {
            currentLine--;
            ShowCurrentText();
            OnDialogueIndexChanged?.Invoke(currentLine);
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        textBox.text = "";
        foreach (char letter in sentence)
        {
            textBox.text += letter;
            yield return null; 
        }
    }
}
