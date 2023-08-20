using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindSomething : MonoBehaviour
{
    private Color defaultPlayerColor;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        defaultPlayerColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Color playerColor = spriteRenderer.color;
            playerColor.a = 0.5f;
            spriteRenderer.color = playerColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            spriteRenderer.color = defaultPlayerColor;
        }
    }
}
