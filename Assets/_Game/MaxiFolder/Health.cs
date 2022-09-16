using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField][Tooltip("Maximum amount of health")] 
    private int maxHealth = 100;

    public event Action OnConsumed;
    public event Action OnGained;
    public event Action OnDeath;
    
    public int CurrentHealth { get; private set; }
    public int MaxHealth => maxHealth;
    public float GetRatio => CurrentHealth / (float)MaxHealth;
    public int LastDamageTaken { get; private set; }
    
    public bool IsDead { get; private set; }
    public bool IsInvulnerable { get; private set; }

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void Heal(int healAmount)
    {
        var healthBefore = CurrentHealth;
        CurrentHealth += healAmount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

        // call OnHeal action
        var trueHealAmount = CurrentHealth - healthBefore;
        if (trueHealAmount > 0)
        {
            // use this to display amount healed on screen
            OnGained?.Invoke();
        }
    }
   
    public void TakeDamage(int damage)
    {
        if (IsDead || IsInvulnerable) return;
        var healthBefore = CurrentHealth;
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

        // call OnDamage action
        LastDamageTaken = healthBefore - CurrentHealth;
        if (LastDamageTaken > 0)
        {
            // use this to display on screen
            OnConsumed?.Invoke();
        }

        HandleDeath();
    }
    
    private void HandleDeath()
    {
        if (IsDead) return;

        // call OnDie action
        if (CurrentHealth <= 0)
        {
            IsDead = true;
            OnDeath?.Invoke();
        }
    }

    private void UnsetInvulnerable()
    {
        IsInvulnerable = false;
    }
    
    public void SetInvulnerable(float time)
    {
        IsInvulnerable = true;
        Invoke(nameof(UnsetInvulnerable), time);
    }

    public void ResetToMax()
    {
        Heal(maxHealth);
        IsDead = false;
    }

    public void BuffMaxHealth(int amount)
    {
        maxHealth += amount;
    }
}