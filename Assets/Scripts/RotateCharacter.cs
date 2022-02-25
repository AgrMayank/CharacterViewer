using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotXY;

    public float rotateSpeedX = 0.1f;
    public float rotateSpeedY = 0.1f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rotXY = Quaternion.Euler(touch.deltaPosition.y * rotateSpeedX, -touch.deltaPosition.x * rotateSpeedY, 0f);
                transform.rotation = rotXY * transform.rotation;
            }
        }
    }
}
