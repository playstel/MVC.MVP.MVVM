using GlobalContext.Models;
using UniRx;

namespace MVVM.ViewModel
{
    /// <summary>
    /// ViewModel не хранит ссылки на View.
    /// Используем события и ReactiveProperty для уведомления View.
    /// ViewModel легко тестировать без необходимости использования реального интерфейса
    /// </summary>
    public class HealthViewModel
    {
        private readonly HealthModel _healthModel;

        // Реактивное свойство автоматически обновляет View при изменении здоровья
        public ReactiveProperty<int> CurrentHealth { get; }
        public int MaxHealth { get; }

        public HealthViewModel(HealthModel healthModel)
        {
            _healthModel = healthModel;
            
            MaxHealth = _healthModel.MaxHealth;
            CurrentHealth = new ReactiveProperty<int>(_healthModel.CurrentHealth);

            _healthModel.OnHealthChanged += UpdateHealth;
        }

        private void UpdateHealth(int newHealth)
        {
            CurrentHealth.Value = newHealth;
        }

        public void TakeDamage(int damage)
        {
            _healthModel.TakeDamage(damage);
        }

        public void Heal(int amount)
        {
            _healthModel.Heal(amount);
        }
    }
}