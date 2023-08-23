using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LabTourMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject imageFillerParent;

    [SerializeField]
    private Image imageFiller;

    [SerializeField]
    private TextMeshProUGUI machineName;

    [SerializeField]
    private Sprite centrifuge;

    [SerializeField]
    private Sprite nanodrop;

    [SerializeField]
    private Sprite waterbath;

    [SerializeField]
    private Sprite thermocycler;

    [SerializeField]
    private Sprite gelImager;

    [SerializeField]
    private Sprite fumeHood;

    [SerializeField]
    private Sprite PPE;

    [SerializeField]
    private Sprite turnIn;

    [SerializeField]
    private Sprite shaking;

    [SerializeField]
    private Sprite gelTank;

    [SerializeField]
    private Sprite pipettes;

    [SerializeField]
    private Sprite incubator;

    [SerializeField]
    private Sprite shower;

    [SerializeField]
    private Sprite fridge4;

    [SerializeField]
    private Sprite freezer20;

    [SerializeField]
    private Sprite freezer80;

    [SerializeField]
    private Sprite drawer;

    [SerializeField]
    private Sprite milliQ;

    [SerializeField]
    private Sprite iceMachine;

    private void Start()
    {
        imageFillerParent.gameObject.SetActive(false);
        Dialogue.instance.OnDialogueIndexChanged += ChangeMachineImage;
    }

    public void ChangeMachineImage(int newIndex)
    {
        if (newIndex == 3)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = drawer;
            machineName.text = "Drawer";
        }
        else if (newIndex == 9)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = PPE;
            machineName.text = "PPE Lab Coats";
        }
        else if (newIndex == 12)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = shower;
            machineName.text = "Shower/Eyewash";
        }
        else if (newIndex == 16)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = thermocycler;
            machineName.text = "Thermocycler";
        }
        else if (newIndex == 22)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = milliQ;
            machineName.text = "MilliQ Water Dispenser";
        }
        else if (newIndex == 25)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = shaking;
            machineName.text = "Shaking Incubator";
        }
        else if (newIndex == 27)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = fumeHood;
            machineName.text = "Fume Hood";
        }
        else if (newIndex == 30)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = freezer20;
            machineName.text = "-20° Freezer";
        }
        else if (newIndex == 31)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = fridge4;
            machineName.text = "+4° Fridge";
        }
        else if (newIndex == 32)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = waterbath;
            machineName.text = "Water Bath";
        }
        else if (newIndex == 34)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = gelTank;
            machineName.text = "Gel Tank";
        }
        else if (newIndex == 38)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = pipettes;
            machineName.text = "Workbench";
        }
        else if (newIndex == 43)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = centrifuge;
            machineName.text = "Centrifuge";
        }
        else if (newIndex == 49)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = freezer80;
            machineName.text = "-80° Freezer";
        }
        else if (newIndex == 52)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = iceMachine;
            machineName.text = "Ice Machine";
        }
        else if (newIndex == 56)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = gelImager;
            machineName.text = "Gel Imager";
        }
        else if (newIndex == 57)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = incubator;
            machineName.text = "Incubator";
        }
        else if (newIndex == 58)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = nanodrop;
            machineName.text = "Nanodrop";
        }
        else if (newIndex == 61)
        {
            imageFillerParent.SetActive(true);
            imageFiller.sprite = turnIn;
            machineName.text = "Conveyer Belt";
        }
        else
        {
            imageFillerParent.SetActive(false);
        }
    }
}
