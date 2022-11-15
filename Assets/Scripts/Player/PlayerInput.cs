using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IPointerDownHandler, IDragHandler 
{
    public GameManager gameManager;
    public Transform player;
    public float dragSpeed;
    
    bool _isTouching;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isTouching = true;

        if(_isTouching == true)
        {
            EventManager.Broadcast(GameEvent.OnStart);
            EventManager.Broadcast(GameEvent.OnSingleThrow);
        }
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (gameManager.isDragging == true)
        {
            Vector3 pos = player.position;
            pos.x = Mathf.Clamp(pos.x + eventData.delta.x * dragSpeed, -1.8f, 1.8f);
            player.position = pos;
        }
    }

    
}
