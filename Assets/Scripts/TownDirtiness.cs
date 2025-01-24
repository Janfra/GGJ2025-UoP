using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownDirtiness : MonoBehaviour
{
    [SerializeField]
    private Animator fountainAnimator;

    public static TownDirtiness Instance;

    public float Dirtiness
    {
        get
        {
            return dirtiness;
        }
        set
        {
            if ((dirtiness < 25 && value >= 25) || (dirtiness < 50 && value >= 50) || (dirtiness < 75 && value >= 75) || value >= 100)
            {
                fountainAnimator.SetTrigger("dirtier");
            }
            else if ((dirtiness >= 75 && value < 75) || (dirtiness >= 50 && value < 50) || (dirtiness >= 25 && value < 25) || value <= 0)
            {
                fountainAnimator.SetTrigger("cleaner");
            }

            dirtiness = value;
        }
    }

    private float dirtiness;

    private void Start()
    {
        Instance = this;
    }
}
