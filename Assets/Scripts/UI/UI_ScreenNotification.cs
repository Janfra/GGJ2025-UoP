using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_ScreenNotification : MonoBehaviour
{
    [SerializeField]
    private Renderer pointerRenderer;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector2 offset;
    [SerializeField, Range(0.0f, 1.0f)]
    private float offscreenOffset;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        pointerRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (cam == null)
        {
            cam = Camera.main;
            return;
        }

        Vector2 offsetPercentage = new Vector2(offscreenOffset * Screen.width, offscreenOffset * Screen.height);
        Vector2 targetScreenPoint = cam.WorldToScreenPoint(target.position);
        bool isOffScreen = targetScreenPoint.x <= 0 - offsetPercentage.x || targetScreenPoint.x >= Screen.width + offsetPercentage.x
            || targetScreenPoint.y <= 0 - offsetPercentage.y || targetScreenPoint.y >= Screen.height + offsetPercentage.y;

        if (isOffScreen)
        {
            if (pointerRenderer && !pointerRenderer.enabled)
            {
                pointerRenderer.enabled = true;
            }

            float xPosition = Mathf.Clamp(targetScreenPoint.x, 0, Screen.width);
            float yPosition = Mathf.Clamp(targetScreenPoint.y, 0, Screen.height);
            Vector2 clampScreenPoint = new Vector2(xPosition, yPosition);
            Vector2 clampPosition = GetClampedPosition(cam.ScreenToWorldPoint(clampScreenPoint));
            transform.position = clampPosition;
        }
        else if (pointerRenderer)
        {
            pointerRenderer.enabled = false;
        }
    }

    private Vector2 GetClampedPosition(Vector2 worldPoint)
    {
        Vector2 bottomLeftCorner = cam.ScreenToWorldPoint(Vector2.zero);
        Vector2 topRightCorner = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        worldPoint.x = Mathf.Clamp(worldPoint.x, bottomLeftCorner.x + offset.x, topRightCorner.x - offset.x);
        worldPoint.y = Mathf.Clamp(worldPoint.y, bottomLeftCorner.y + offset.y, topRightCorner.y - offset.y);
        return worldPoint;
    }
}
