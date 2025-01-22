using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ScreenNotification : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector2 offset;

    private void Update()
    {
        Vector2 targetScreenPoint = Camera.main.WorldToScreenPoint(target.position);
        bool isOffScreen = targetScreenPoint.x <= 0 || targetScreenPoint.x >= Screen.width || targetScreenPoint.y <= 0 || targetScreenPoint.y >= Screen.height;

        if (isOffScreen)
        {
            float xPosition = Mathf.Clamp(targetScreenPoint.x, 0 + offset.x, Screen.width - offset.x);
            float yPosition = Mathf.Clamp(targetScreenPoint.y, 0 + offset.y, Screen.height - offset.y);
            Vector2 clampScreenPoint = new Vector2(xPosition, yPosition);
            Vector2 clampPosition = Camera.main.ScreenToWorldPoint(clampScreenPoint);
            transform.position = clampPosition;
        }
    }
}
