using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoneyDraggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    Image image;


    public void OnInit(int amount)
    {
        switch (amount)
        {
            case 1000:

                break;
            case 5000:

                break;
            case 10000:

                break;
        }
    }

    void OnEnable()
    {

    }

    void OnDestroy()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().anchoredPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    void ButtonEvent() //flip
    {

    }

    
}