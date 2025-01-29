using Config;
using UnityEngine;

namespace MVC.Model
{
    /// <summary>
    /// Модель хранит данные и управляет бизнес-логикой.
    /// Независима от UI.
    /// </summary>
    public class HealthModel
    {
        public int CurrentHealth { get; private set; }

        public int MaxHealth { get; }

        public event System.Action OnHealthChanged;

        public HealthModel(HealthConfig healthConfig)
        {
            MaxHealth = healthConfig.maxHealth;
            CurrentHealth = healthConfig.startHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
            OnHealthChanged?.Invoke();
        }

        public void Heal(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
            OnHealthChanged?.Invoke();
        }
    }

}