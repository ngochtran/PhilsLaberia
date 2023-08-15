using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent; // slot which item belonged in before drag 
        transform.SetParent(transform.root); // detaches item icon from parent 
        transform.SetAsLastSibling(); // sets to the bottom, so it appears on top of other slots 
        image.raycastTarget = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag); // puts image back to previous parent if not dropped into a new slot
        image.raycastTarget = true;
    }

}
