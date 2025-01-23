using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ThresholdSpriteChange : MonoBehaviour
{
    [SerializeField]
    private TownDirtTracker tracker;

    [SerializeField]
    private SpriteRenderer target;

    [SerializeField]
    SpriteThresholdData[] Sprites;
    private int index;

    private void Awake()
    {
        if (target == null)
        {
            target = GetComponent<SpriteRenderer>();  
        }

        Array.Sort(Sprites, (x, y) => x.Threshold.CompareTo(y.Threshold));
        tracker.dirtinessAdded += UpdateSpriteOnAdd;
        tracker.dirtinessRemoved += UpdateSpriteOnRemove;
    }

    private void UpdateSpriteOnAdd(float value)
    {
        float newThreshold = GetThresholdValue(value);

        if (index >= Sprites.Length - 1)
        {
            return;
        }

        bool thresholdReached = false;
        SpriteThresholdData targetSprite = Sprites[index + 1];
        while (newThreshold >= targetSprite.Threshold && index < Sprites.Length - 1)
        {
            thresholdReached = true;
            index++;
            targetSprite = Sprites[Mathf.Min(index + 1, Sprites.Length - 1)];
        }

        if (thresholdReached)
        {
            SetSprite();
        }
    }

    private void UpdateSpriteOnRemove(float value)
    {
        float newThreshold = GetThresholdValue(value);

        bool thresholdReached = false;
        SpriteThresholdData currentSprite = Sprites[index];
        while (newThreshold < currentSprite.Threshold && index >= 0)
        {
            thresholdReached = true;
            index--;
            currentSprite = Sprites[index];
        }

        if (thresholdReached)
        {
            SetSprite();
        }
    }

    private float GetThresholdValue(float value)
    {
        return value / tracker.MaxDirtiness;
    }

    private void SetSprite()
    {
        target.sprite = Sprites[Mathf.Clamp(index, 0, Sprites.Length - 1)].Sprite;
    }
}

[Serializable]
public struct SpriteThresholdData
{
    [SerializeField, Range(0.0f, 1.0f)]
    private float threshold;
    public float Threshold => threshold;

    [SerializeField]
    private Sprite sprite;
    public Sprite Sprite => sprite;
}