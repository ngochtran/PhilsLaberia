using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeRenderer : Interactable
{
    public Sprite initial;
    public Sprite final;

    private SpriteRenderer sr;
    private bool isChanged;

    public override void Interact()
    {
        if (isChanged)
            sr.sprite = final;
        else
            sr.sprite = initial;

        isChanged = !isChanged;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = initial;
    }
}
