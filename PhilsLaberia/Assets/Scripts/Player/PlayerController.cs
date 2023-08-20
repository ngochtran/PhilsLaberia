using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject interactIcon;

    // Start is called before the first frame update
    public float speed = 10.0f;

    private bool isPopUpActive = false;


    // Animation Variables 
    public Animator animator;
    private float moving;

    private Rigidbody2D rb;
    private Vector2 boxSize = new Vector2(0.1f, 1f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Initialize the Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        if (isPopUpActive)
        {
            moving = 0;
            animator.SetFloat("Speed", moving);
            rb.velocity = Vector2.zero;
        }

        if (!isPopUpActive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                moving = 1;
            }
            else
            {
                moving = 0;
            }

            // And move our character in the world. The bounding is automatically handled by KeepActorInBounds
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            rb.velocity = movement * speed;

            animator.SetFloat("Horizontal", horizontalInput);
            animator.SetFloat("Vertical", verticalInput);
            animator.SetFloat("Speed", moving);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
                animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
            CheckInteraction();

    }
    public void SetPopUpActive(bool active)
    {
        isPopUpActive = active;
    }

    public void OpenInteractableIcon()
    {
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactIcon.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0) { 
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
