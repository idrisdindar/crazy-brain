using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

enum Direction
{
    Left,
    Right,
    None
}

public class TouchButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Direction buttonDirection = Direction.None;
    internal static Direction direction = Direction.None;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(buttonDirection == Direction.Left)
        {
            direction = Direction.Left;
        }
        else if(buttonDirection == Direction.Right)
        {
            direction = Direction.Right;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
            direction = Direction.None;
    }
}
