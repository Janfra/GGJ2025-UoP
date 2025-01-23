using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IShootable
{
    [SerializeField]
    private PlayerScore playerScore;
    [SerializeField]
    private int onDeathScore = 5;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float health;

    [SerializeField]
    private float invulnerabilityTime = 0.25f;
    private bool isInvulnerable => invulnerabilityRoutine != null;
    private float duration;

    private Coroutine invulnerabilityRoutine;

    public void OnShot(ShootData data)
    {
        if (!isInvulnerable)
        {
            TakeDamage(data.damage);
        }
    }

    private void TakeDamage(float damage)
    {
        Debug.Log("ouch");
        health -= damage;

        if (IsDead())
        {
            // Replace with play animation that on event calls HandleDeath
            HandleDeath();
        }
        else
        {
            StartInvulnerabilityFrames();
            if (animator != null)
            {
                StartDamagedAnimation();
            }
        }
    }

    private void StartDamagedAnimation()
    {
        animator.SetTrigger("Hurted");
    }

    private void StartInvulnerabilityFrames()
    {
        invulnerabilityRoutine = StartCoroutine(InvulnerabilityTimer());
    }

    private IEnumerator InvulnerabilityTimer()
    {
        duration = 0.0f;

        while (duration < invulnerabilityTime && invulnerabilityTime > 0.0f)
        {
            duration += Time.deltaTime;
            yield return null;
        }

        invulnerabilityRoutine = null;
        yield return null;
    }

    private bool IsDead()
    {
        return health > 0.0f;
    }

    private void HandleDeath()
    {
        if (!playerScore)
        {
            throw new System.NullReferenceException($"The player score tracker has not been set in the health component for {name}, please set it.");
        }

        playerScore.AddScore(onDeathScore);
        gameObject.SetActive(false);
    }
}
