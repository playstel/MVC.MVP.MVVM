using GlobalContext.Configs;
using UnityEngine;

namespace GlobalContext.Models
{
    /// <summary>
    /// Model хранит данные.
    /// Model управляет бизнес-логикой (здесь это Mathf.Clamp()).
    /// Model триггерит событие OnHealthChanged при изменении данных. 
    /// Model независима от UI.
    /// </summary>
    public class HealthModel
    {
        public int CurrentHealth { get; private set; }

        public int MaxHealth { get; }

        public event System.Action<int> OnHealthChanged;

        public HealthModel(HealthConfig healthConfig)
        {
            MaxHealth = healthConfig.maxHealth;
            CurrentHealth = healthConfig.startHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
            NotifyHealthChanged();
        }

        public void Heal(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
            NotifyHealthChanged();
        }
        
        private void NotifyHealthChanged()
        {
            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }

}