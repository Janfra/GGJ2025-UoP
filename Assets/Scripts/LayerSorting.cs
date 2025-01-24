using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class LayerSorting : MonoBehaviour
{
    private void Update()
    {
        List<SpriteRenderer> sprites = FindObjectsByType<SpriteRenderer>(FindObjectsSortMode.None).ToList();
        sprites.Sort(delegate (SpriteRenderer a, SpriteRenderer b)
        {
            if (a.transform.position.y > b.transform.position.y)
            {
                return -1;
            }
            else
            {
                return a.transform.position.y < b.transform.position.y ? 1 : 0;
            }
        });
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].sortingOrder = i;
        }
    }
}
