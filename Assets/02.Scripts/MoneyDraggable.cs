using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoneyDraggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    Image image;


    public void OnInit()
    {

    }

    void OnEnable()
    {

    }

    void OnDestroy()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    
}