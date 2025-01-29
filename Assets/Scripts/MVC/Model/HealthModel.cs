using UnityEngine;

namespace MVC.Model
{
    /// <summary>
    /// Модель хранит данные и управляет бизнес-логикой.
    /// Независима от UI.
    /// </summary>
    public class HealthModel
    {
        private int _currentHealth;
        private int _maxHealth;

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;

        public event System.Action OnHealthChanged;

        public HealthModel(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
            OnHealthChanged?.Invoke();
        }

        public void Heal(int amount)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
            OnHealthChanged?.Invoke();
        }
    }

}