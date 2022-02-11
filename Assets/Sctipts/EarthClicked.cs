using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EarthClicked : MonoBehaviour, IPointerClickHandler
{
    public static event Action<Vector3> OnClick = delegate { };

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke(eventData.pointerPressRaycast.worldPosition);
    }
}
