using Models;
using UniRx;

namespace MVVM.ViewModel
{
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