using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyIndication : MonoBehaviour
{
    public static List<Transform> enemies = new();
    public Transform fountain;
    public GameObject[] indicators = new GameObject[3];

    [SerializeField, Range(0.0f, 1.0f)]
    private float offscreenOffset;
    [SerializeField]
    private Vector2 offset;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        enemies.Sort(delegate (Transform a, Transform b)
        {
            float aDist = (a.position - fountain.position).sqrMagnitude;
            float bDist = (b.position - fountain.position).sqrMagnitude;
            if (aDist < bDist)
            {
                return -1;
            }
            else if (aDist > bDist)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        });

        for (int i = 0; i < 3; i++)
        {
            if (enemies[i] != null)
            {

                Vector2 offsetPercentage = new(offscreenOffset * Screen.width, offscreenOffset * Screen.height);
                Vector2 targetScreenPoint = cam.WorldToScreenPoint(enemies[i].position);
                bool isOffScreen = targetScreenPoint.x <= 0 - offsetPercentage.x || targetScreenPoint.x >= Screen.width + offsetPercentage.x
                    || targetScreenPoint.y <= 0 - offsetPercentage.y || targetScreenPoint.y >= Screen.height + offsetPercentage.y;

                if (isOffScreen)
                {
                    float xPosition = Mathf.Clamp(targetScreenPoint.x, 0, Screen.width);
                    float yPosition = Mathf.Clamp(targetScreenPoint.y, 0, Screen.height);
                    Vector2 clampScreenPoint = new(xPosition, yPosition);
                    Vector2 clampPosition = GetClampedPosition(cam.ScreenToWorldPoint(clampScreenPoint));
                    transform.position = clampPosition;
                    indicators[i].SetActive(true);
                }
                else
                {
                    indicators[i].SetActive(false);
                }
            }
            else
            {
                indicators[i].SetActive(false);
            }
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
