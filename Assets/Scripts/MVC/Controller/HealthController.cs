using Context.Models;
using MVC.View;

namespace MVC.Controller
{
    /// <summary>
    /// 1) Controller получает команду от ButtonsView и обновляет Model.
    /// 2) Controller подписывается на обновление Model и обновляет HealthView.
    /// </summary>
    public class HealthController
    {
        private HealthModel _healthModel;
        private HealthView _healthView;

        public HealthController(HealthModel healthModel, HealthView healthView)
        {
            _healthModel = healthModel;
            _healthView = healthView;

            _healthModel.OnHealthChanged += UpdateView;
            
            UpdateView(_healthModel.CurrentHealth);
        }

        public void TakeDamage(int damage)
        {
            _healthModel.TakeDamage(damage);
        }

        public void Heal(int amount)
        {
            _healthModel.Heal(amount);
        }

        private void UpdateView(int currentHealth)
        {
            _healthView.UpdateHealthText(currentHealth, _healthModel.MaxHealth);
            _healthView.UpdateHealthSlider(currentHealth, _healthModel.MaxHealth);
            _healthView.UpdateHealthInfo(currentHealth);
        }
    }

}