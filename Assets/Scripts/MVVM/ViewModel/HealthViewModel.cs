using Context.Models;
using UniRx;

namespace MVVM.ViewModel
{
    /// <summary>
    /// Заменяем Presenter на ViewModel – теперь ViewModel напрямую управляет состоянием UI.
    /// ViewModel не хранит ссылки на View – только данные, которые View привязывает через биндинги.
    /// Используем события и ReactiveProperty для уведомления View.
    /// </summary>
    public class HealthViewModel
    {
        private readonly HealthModel _model;

        // Реактивные свойства для UI
        public ReactiveProperty<int> CurrentHealth { get; }
        public ReactiveProperty<int> MaxHealth { get; }

        public HealthViewModel(HealthModel model)
        {
            _model = model;
            
            CurrentHealth = new ReactiveProperty<int>(_model.CurrentHealth);
            MaxHealth = new ReactiveProperty<int>(_model.MaxHealth);

            _model.OnHealthChanged += UpdateHealth;
        }

        private void UpdateHealth(int newHealth)
        {
            CurrentHealth.Value = newHealth;
        }

        public void TakeDamage(int damage)
        {
            _model.TakeDamage(damage);
        }

        public void Heal(int amount)
        {
            _model.Heal(amount);
        }
    }
}